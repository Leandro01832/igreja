using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.financeiro;
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
        private static int loop = 2;

        static void Main(string[] args)
        {
            arr[0] = "Paulo"; arr[10] = "Sandra"; arr[20] = "Sebastião"; arr[30] = "Thais"; arr[40] = "Adriana";
            arr[1] = "Jorge"; arr[11] = "Jaco"; arr[21] = "Lucas"; arr[31] = "Pamela"; arr[41] = "Adriano";
            arr[2] = "Maria"; arr[12] = "Rubens"; arr[22] = "Alice"; arr[32] = "Nayara"; arr[42] = "Alex";
            arr[3] = "Pedro"; arr[13] = "Marta"; arr[23] = "Aline"; arr[33] = "Oliver"; arr[43] = "Fred";
            arr[4] = "Sandro"; arr[14] = "Madalena"; arr[24] = "Zezé"; arr[34] = "Hugo"; arr[44] = "Tiago";
            arr[5] = "Gustavo"; arr[15] = "Judas"; arr[25] = "Romulo"; arr[35] = "Icaro"; arr[45] = "Neymar";
            arr[6] = "Henrique"; arr[16] = "Amanda"; arr[26] = "Geraldo"; arr[36] = "Bruno"; arr[46] = "Mariano";
            arr[7] = "Isaque"; arr[17] = "Erik"; arr[27] = "Denis"; arr[37] = "Vinicius"; arr[47] = "Fabricio";
            arr[8] = "Salomão"; arr[18] = "Leonardo"; arr[28] = "Gisele"; arr[38] = "Ramon"; arr[48] = "Felipe";
            arr[9] = "Camila"; arr[19] = "Simone"; arr[29] = "Bianca"; arr[39] = "Charles"; arr[49] = "Carlos";


            arr2[0] = "Silva Mendes";
            arr2[1] = "Oliveira Prado";
            arr2[2] = "Bitencourt Silva";
            arr2[3] = "Chavier dos Santos";
            arr2[4] = "Gomes Pereira";
            arr2[5] = "Vasconcelos";
            arr2[6] = "Magalhães";
            arr2[7] = "Santos";
            arr2[8] = "Menezes";
            arr2[9] = "Reimon";


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
            pessoa1.Ministerio = new List<PessoaMinisterio>();
            pessoa1.Ministerio.Add(new PessoaMinisterio
            {
                Ministerio = ministerio1,
                MinisterioId = ministerio1.Id,
                PessoaId = pessoa1.Id,
                Pessoa = pessoa1
            });
            pessoa1.salvar();
            Pessoa pessoa2 = new Crianca();
            pessoa2.Email = "pessoa2";
            pessoa2.Codigo = 4;
            PessoaDado pessoadado2 = (PessoaDado)pessoa2;
            pessoadado2.Cpf = "00000000002";
            pessoa2.Ministerio = new List<PessoaMinisterio>();
            pessoa2.Ministerio.Add(new PessoaMinisterio
            {
                Ministerio = ministerio1,
                MinisterioId = ministerio1.Id,
                PessoaId = pessoa2.Id,
                Pessoa = pessoa2
            });
            pessoa2.salvar();
            Pessoa pessoa3 = new Crianca();
            pessoa3.Email = "pessoa3";
            pessoa3.Codigo = 5;
            PessoaDado pessoadado3 = (PessoaDado)pessoa3;
            pessoadado3.Cpf = "00000000003";
            pessoa3.Ministerio = new List<PessoaMinisterio>();
            pessoa3.Ministerio.Add(new PessoaMinisterio
            {
                Ministerio = ministerio1,
                MinisterioId = ministerio1.Id,
                PessoaId = pessoa3.Id,
                Pessoa = pessoa3
            });
            pessoa3.salvar();
            Celula celula1 = new Celula_Adulto();
            celula1.Ministerios = new List<MinisterioCelula>();
            var pr = celula1.GetType().GetProperty("Ministerios");
            pr.SetValue(celula1, new List<MinisterioCelula>
            {
                new MinisterioCelula { Ministerio = ministerio1, MinisterioId = ministerio1.Id,
                    CelulaId = celula1.Id, Celula = celula1 },
                new MinisterioCelula { Ministerio = ministerio2, MinisterioId = ministerio2.Id,
                    CelulaId = celula1.Id, Celula = celula1 }
            });
            celula1.Pessoas = new List<Pessoa>();
            celula1.Pessoas.Add(pessoa2);
            celula1.Pessoas.Add(pessoa3);
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
                pessoa2
            });

            celula1.alterar(celula1.Id);

            for (var i = 0; i < loop; i++)
            {
                foreach (var item in types)
                {
                    num++;
                    var modelo = (modelocrud)Activator.CreateInstance(item);
                    try
                    {
                        if (modelo is Pessoa)
                        {
                            var p = (Pessoa)modelo;
                            p.Codigo = num;
                            p.Email = num + "@gmail.com";
                            p.Nome = arr[randNum.Next(0, 49)] + " " + arr[randNum.Next(0, 9)];
                        }
                        if (modelo is PessoaDado)
                        {
                            var p = (PessoaDado)modelo;
                            p.Data_nascimento = new DateTime(randNum.Next(1900, 2020), randNum.Next(1, 12), randNum.Next(1, 28));
                            p.Estado_civil = arr[randNum.Next(0, 49)];
                            p.Falescimento = randNum.Next(0, 10) > randNum.Next(0, 10);
                            p.Falta = randNum.Next(0, 100);
                            p.Sexo_feminino = randNum.Next(0, 10) > randNum.Next(0, 10);
                            p.Sexo_masculino = !p.Sexo_feminino;
                            p.Status = arr[randNum.Next(0, 49)];
                            if (num.ToString().Length == 1)
                                p.Cpf = "0000000000" + num;
                            if (num.ToString().Length == 2)
                                p.Cpf = "000000000" + num;
                            if (num.ToString().Length == 3)
                                p.Cpf = "00000000" + num;
                            if (num.ToString().Length == 4)
                                p.Cpf = "0000000" + num;
                            if (num.ToString().Length == 5)
                                p.Cpf = "000000" + num;
                            p.Rg = p.Cpf;
                        }
                        if (modelo is Ministerio)
                        {
                            var p = (Ministerio)modelo;
                            p.CodigoMinisterio = num;
                            p.Nome = arr[randNum.Next(0, 49)];
                        }

                        if (modelo is Celula)
                        {
                            var p = (Celula)modelo;
                            p.Nome = arr[randNum.Next(0, 49)];
                            p.Dia_semana = arr[randNum.Next(0, 49)];
                            p.Horario = new TimeSpan(randNum.Next(1, 12), randNum.Next(1, 12), randNum.Next(1, 12));
                            p.Maximo_pessoa = randNum.Next(0, 49);
                            var prop = modelo.GetType().GetProperty("Ministerios");
                            prop.SetValue(modelo, new List<MinisterioCelula>
                        {
                            new MinisterioCelula { Ministerio = ministerio1, MinisterioId = ministerio1.Id },
                            new MinisterioCelula { Ministerio = ministerio2, MinisterioId = ministerio2.Id }
                        });
                        }

                        if (modelo is Movimentacao)
                        {
                            var p = (Movimentacao)modelo;
                            p.Valor = randNum.Next(10, 1000);
                            p.Data = new DateTime(randNum.Next(2021, 2025), randNum.Next(1, 12), randNum.Next(1, 28));
                            p.Pago = randNum.Next(1, 10) > randNum.Next(1, 10);

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

            }


            foreach (var item in lista)
            {
                try
                {
                    if (item.Id != 0)
                        item.alterar(item.Id);
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

                    if (item.GetType().GetProperties().Where(pro => pro.ReflectedType ==
                        pro.DeclaringType && pro.Name == "Id").ToList().Count != 0)
                        continue;

                    if (item.GetType().BaseType == typeof(modelocrud) &&
                        item.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType).ToList().Count == 4 &&
                        item.GetType().GetProperties().Where(e => e.ReflectedType == e.DeclaringType &&
                        e.PropertyType == typeof(int)).ToList().Count == 2)
                        continue;


                    try
                    {
                        item.excluir(item.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("Dados apagados com sucesso.");

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

            try
            {
                ministerio1.excluir(ministerio1.Id);
                Console.WriteLine("Dados apagados com sucesso");

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                ministerio2.excluir(ministerio2.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                ministerio3.excluir(ministerio3.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                pessoa1.excluir(pessoa1.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                pessoa2.excluir(pessoa2.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                pessoa3.excluir(pessoa3.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                celula1.excluir(celula1.Id);
                Console.WriteLine("Dados apagados com sucesso");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            Console.WriteLine("ok");

            Console.Read();
        }


    }

}
