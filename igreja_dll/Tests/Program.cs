using business.classes.Abstrato;
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
         
                   if(modelo.GetType().GetProperties().Where(pr => pr.ReflectedType ==
                   pr.DeclaringType && pr.Name == "Id").ToList().Count != 0)
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

            Console.WriteLine("------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("------------------------loop realizado com sucesso!!!------------------------------------");


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
            Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------------");
            Console.WriteLine("--------------------------loop realizado com sucesso!!!------------------------------------");

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

            Console.WriteLine("---------------------loop realizado com sucesso!!!-----------------------------------");
            Console.WriteLine("---------------------loop realizado com sucesso!!!-----------------------------------");
            Console.WriteLine("---------------------loop realizado com sucesso!!!-----------------------------------");
            Console.WriteLine("---------------------loop realizado com sucesso!!!-----------------------------------");
            Console.WriteLine("---------------------loop realizado com sucesso!!!-----------------------------------");


            Console.WriteLine("ok");
            Console.Read();
        }

        
    }
    
}
