using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        static string[] arr = new string[50];
        static string[] arr2 = new string[10];
        static Random randNum = new Random();
        private static BDcomum bd = new BDcomum();

        static void Main(string[] args)
        {
            BDcomum.podeAbrir = true;
            var types = modelocrud.listTypesSon(typeof(modelocrud));
            List<modelocrud> lista = new List<modelocrud>();
            int num = 0;

            // try save with list

            Ministerio ministerio1 = new Lider_Celula();
            ministerio1.CodigoMinisterio = 1;
            Ministerio ministerio2 = new Lider_Celula_Treinamento();
            ministerio2.CodigoMinisterio = 2;
            Ministerio ministerio3 = new Lider_Celula_Treinamento();
            ministerio3.CodigoMinisterio = 6;
            ministerio1.salvar();
            ministerio2.salvar();
            ministerio3.salvar();
            Pessoa pessoa1 = new Visitante();
            pessoa1.Email = "pessoa1";
            pessoa1.Codigo = 3;
            PessoaDado pessoadado1 = (PessoaDado)pessoa1;
            pessoadado1.Cpf = "00000000001";
            pessoa1.Ministerios = new List<PessoaMinisterio>();
            pessoa1.Ministerios.Add(new PessoaMinisterio { Ministerio = ministerio1, MinisterioId = ministerio1.Id });
            pessoa1.salvar();
            Pessoa pessoa2 = new Crianca();
            pessoa2.Email = "pessoa2";
            pessoa2.Codigo = 4;
            PessoaDado pessoadado2 = (PessoaDado)pessoa2;
            pessoadado2.Cpf = "00000000002";
            pessoa2.Ministerios = new List<PessoaMinisterio>();
            pessoa2.Ministerios.Add(new PessoaMinisterio { Ministerio = ministerio1, MinisterioId = ministerio1.Id });
            pessoa2.salvar();
            Pessoa pessoa3 = new Crianca();
            pessoa3.Email = "pessoa3";
            pessoa3.Codigo = 5;
            PessoaDado pessoadado3 = (PessoaDado)pessoa3;
            pessoadado3.Cpf = "00000000003";
            pessoa3.Ministerios = new List<PessoaMinisterio>();
            pessoa3.Ministerios.Add(new PessoaMinisterio { Ministerio = ministerio1, MinisterioId = ministerio1.Id });
            pessoa3.salvar();
            Celula celula1 = new Celula_Adulto();
            celula1.Ministerios = new List<MinisterioCelula>();
            var pr = celula1.GetType().GetProperty("Ministerios");
            pr.SetValue(celula1, new List<MinisterioCelula>
            {
                new MinisterioCelula { Ministerio = ministerio1, MinisterioId = ministerio1.Id },
                new MinisterioCelula { Ministerio = ministerio2, MinisterioId = ministerio2.Id }
            });
            celula1.Pessoas = new List<Pessoa>();
            celula1.Pessoas.Add(pessoa1);
            celula1.Pessoas.Add(pessoa2);
            celula1.salvar();
            

            // try update with list

            var teste = celula1.GetType().GetProperty("Ministerios");
            teste.SetValue(celula1, new List<MinisterioCelula>
            {
                new MinisterioCelula { Ministerio = ministerio1, MinisterioId = ministerio1.Id },
                new MinisterioCelula { Ministerio = ministerio2, MinisterioId = ministerio2.Id },
                new MinisterioCelula { Ministerio = ministerio3, MinisterioId = ministerio3.Id }
            });

            var teste2 = celula1.GetType().GetProperty("Pessoas");
            teste2.SetValue(celula1, new List<Pessoa>
            {
                pessoa1
            });

            celula1.alterar(celula1.Id);


            lista.Add(ministerio1);
            lista.Add(ministerio2);
            lista.Add(ministerio3);
            lista.Add(pessoa1);
            lista.Add(pessoa2);
            lista.Add(pessoa3);
            lista.Add(celula1);


               foreach (var item in types)
               {
                   num++;
                   var modelo = (modelocrud) Activator.CreateInstance(item);
                   try
                   {
                       if(modelo is Pessoa)
                       {
                           var p = (Pessoa)modelo;
                           p.Codigo = num;
                           p.Email = num + "@gmail.com";
                       }
                       if (modelo is PessoaDado)
                       {
                           var p = (PessoaDado)modelo;
                           p.Cpf = "000000000" + num;
                       }
                       if (modelo is Ministerio)
                       {
                           var p = (Ministerio)modelo;
                           p.CodigoMinisterio = num;
                       }

                    if (modelo is Celula)
                    {
                        var p = (Celula)modelo;
                        var prop = modelo.GetType().GetProperty("Ministerios");
                        prop.SetValue(modelo, new List<MinisterioCelula>
                        {
                            new MinisterioCelula { Ministerio = ministerio1, MinisterioId = ministerio1.Id },
                            new MinisterioCelula { Ministerio = ministerio2, MinisterioId = ministerio2.Id }
                        });
                    }

                    if (modelo.GetType().GetProperties().Where(pro => pro.ReflectedType ==
                       pro.DeclaringType && pro.Name == "Id").ToList().Count != 0)
                           continue;
             
                       if (modelo.GetType().BaseType == typeof(modelocrud) &&
                           modelo.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count == 4 &&
                           modelo.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
                           e.PropertyType == typeof(int)).ToList().Count == 2)
                           continue;
             
                       modelo.salvar();
                       Console.WriteLine("dados salvos com sucesso. " + num);
                       lista.Add(modelo);
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine(modelo.GetType().Name + " - " + ex.Message);
                       Console.WriteLine(modelo.GetType().Name + " - " + modelo.exibirMensagemErro(ex, 2));
                   }
               }
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                
                foreach (var item in lista)
               {
                   try
                   {
                       if (item.Id != 0)
                       {
                           item.Select_padrao = $"select * from {item.GetType().Name} as C where C.Id='{item.Id}'";
                           item.Delete_padrao = $" delete from {item.GetType().Name} where Id='{item.Id}' ";
                           item.alterar(item.Id);
                       }
                       Console.WriteLine("Dados alterados com sucesso.");
                   }
                   catch (Exception ex)
                   {
                       Console.WriteLine(item.GetType().Name + " - " + ex.Message);
                       Console.WriteLine(item.GetType().Name + " - " + item.exibirMensagemErro(ex, 2));
                   }
               }
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
            
                foreach (var item in lista)
                {
                    try
                    {
                        if (item.Id != 0)
                        {
                            item.Select_padrao = $"select * from {item.GetType().Name} as C where C.Id='{item.Id}'";
                            item.Delete_padrao = $" delete from {item.GetType().Name} where Id='{item.Id}' ";
                            item.excluir(item.Id);
                            Console.WriteLine("Dados apagados com sucesso.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(item.GetType().Name + " - " + ex.Message);
                        Console.WriteLine(item.GetType().Name + " - " + item.exibirMensagemErro(ex, 2));
                    }
                }
            
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
                Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------");
            Console.WriteLine("ok");
            Console.Read();
        }


    }

}
