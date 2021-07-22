using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {

       static string[] arr = new string[50];
       static string[] arr2 = new string[10];
        static Random randNum = new Random();
       private static BDcomum  bd = new BDcomum();
        static int loop = 1000;
        

        static void Main(string[] args)
        {
            // arr[0] = "Paulo"; arr[10] = "Sandra"; arr[20] = "Sebastião"; arr[30] = "Thais"; arr[40] = "Adriana";
            // arr[1] = "Jorge"; arr[11] = "Jaco"; arr[21] = "Lucas"; arr[31] = "Pamela"; arr[41] = "Adriano";
            // arr[2] = "Maria"; arr[12] = "Rubens"; arr[22] = "Alice"; arr[32] = "Nayara"; arr[42] = "Alex";
            // arr[3] = "Pedro"; arr[13] = "Marta"; arr[23] = "Aline"; arr[33] = "Oliver"; arr[43] = "Fred";
            // arr[4] = "Sandro"; arr[14] = "Madalena"; arr[24] = "Zezé"; arr[34] = "Hugo"; arr[44] = "Tiago";
            // arr[5] = "Gustavo"; arr[15] = "Judas"; arr[25] = "Romulo"; arr[35] = "Icaro"; arr[45] = "Neymar";
            // arr[6] = "Henrique"; arr[16] = "Amanda"; arr[26] = "Geraldo"; arr[36] = "Bruno"; arr[46] = "Mariano";
            // arr[7] = "Isaque"; arr[17] = "Erik"; arr[27] = "Denis"; arr[37] = "Vinicius"; arr[47] = "Fabricio";
            // arr[8] = "Salomão"; arr[18] = "Leonardo"; arr[28] = "Gisele"; arr[38] = "Ramon"; arr[48] = "Felipe";
            // arr[9] = "Camila"; arr[19] = "Simone"; arr[29] = "Bianca"; arr[39] = "Charles"; arr[49] = "Carlos";
            //
            //
            // arr2[0] = "Silva Mendes";
            // arr2[1] = "Oliveira Prado";
            // arr2[2] = "Bitencourt Silva";
            // arr2[3] = "Chavier dos Santos";
            // arr2[4] = "Gomes Pereira";
            // arr2[5] = "Vasconcelos";
            // arr2[6] = "Magalhães";
            // arr2[7] = "Santos";
            // arr2[8] = "Menezes";
            // arr2[9] = "Reimon";

            // CadastrarMembroReconciliacaoDadoTest();
            // CadastrarMembroTransferenciaDadoTest();
            // CadastrarMembroBatismoDadoTest();
            // CadastrarMembroAclamacaoDadoTest();
            // CadastrarCriancaDadoTest();
            // CadastrarVisitanteDadoTest();
            //
            // CadastrarMembroReconciliacaoLgpdTest();
            // CadastrarMembroTransferenciaLgpdTest();
            // CadastrarMembroBatismoLgpdTest();
            // CadastrarMembroAclamacaoLgpdTest();
            // CadastrarCriancaLgpdTest();
            // CadastrarVisitanteLgpdTest();




            //  Type type = typeof(Leandro);
            //
            //  foreach (PropertyInfo property in type.GetProperties())
            //  {
            //      Console.WriteLine(property.PropertyType + " - " + property.Name);
            //      Console.WriteLine(property.ReflectedType.Name);
            //  }

            //var visitante = typeof(Visitante);

            //var v = new Visitante();

            //var pessoa = Activator.CreateInstance(v.GetType());

            //PropertyInfo property = visitante.GetProperty("Email");
            //property.SetValue(v, "Leo");
            //Console.WriteLine(property.GetValue(v, null));

            //foreach (var t in typeof(Pessoa).Assembly.GetTypes())
            //{
            //    Console.WriteLine("{0} derived from: ", t.Name);
            //    var derived = t;
            //    do
            //    {
            //        derived = derived.BaseType;
            //        if (derived != null)
            //            Console.WriteLine("   {0}", derived.Name);
            //    } while (derived != null);
            //    Console.WriteLine();
            //}

            Type pessoaLgpd = typeof(PessoaLgpd);

            Console.WriteLine(pessoaLgpd.BaseType.Name);

            Console.ReadLine();
        }
        
        public static void CadastrarVisitanteDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;              
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Visitante
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },                    
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Condicao_religiosa = " - ",
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Data_visita = DateTime.Now,
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    }
                };

                //Act - metodo sob teste
                pes.salvar();                
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCriancaDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;           
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Crianca
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    },
                    Nome_mae = " - ",
                    Nome_pai = " - "
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroAclamacaoDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_Aclamacao
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    },
                    Data_batismo = 1991,
                    Desligamento = false,
                    Denominacao = "Evagelico",
                    Motivo_desligamento = " - "                     
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroBatismoDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_Batismo
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    },
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - "                     
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroTransferenciaDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_Transferencia
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    },
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - ",
                    Estado_transferencia = "MG",
                    Nome_cidade_transferencia = "Cataguases",
                    Nome_igreja_transferencia = "Igreja"
                         
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroReconciliacaoDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_Reconciliacao
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new business.classes.Endereco
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    },
                    Estado_civil = "solteiro",
                    Falta = 0,
                    Falescimento = false,
                    Sexo_feminino = false,
                    Sexo_masculino = true,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Rg = "MG-" + numero.ToString(),
                    Status = "moro longe",
                    Telefone = new business.classes.Telefone
                    {
                        Celular = "(11)23412-8912",
                        Fone = "(21)29412-1917",
                        Whatsapp = "(31)34985-6734"
                    },
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - ",
                     Data_reconciliacao = 1991
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarVisitanteLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;            
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new VisitanteLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Condicao_religiosa = " - ",
                    Data_visita = DateTime.Now,
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>()
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCriancaLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new CriancaLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Nome_mae = " - ",
                    Nome_pai = " - "
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroAclamacaoLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_AclamacaoLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Data_batismo = 1991,
                    Desligamento = false,
                    Denominacao = "Evagelico",
                    Motivo_desligamento = " - "
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroBatismoLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_BatismoLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - "
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroTransferenciaLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_TransferenciaLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - ",
                    Estado_transferencia = "MG",
                    Nome_cidade_transferencia = "Cataguases",
                    Nome_igreja_transferencia = "Igreja"

                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarMembroReconciliacaoLgpdTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                int numeroGrande = randNum.Next(0, 999999999);
                long numero = (num * 100) + i;

                pes = new Membro_ReconciliacaoLgpd
                {
                    Codigo = bd.GetUltimoRegistroPessoa() + 1,
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                    Img = "",
                    Historico = new List<business.classes.Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Falta = 0,
                    Reuniao = new List<business.classes.Intermediario.ReuniaoPessoa>(),
                    Data_batismo = 1991,
                    Desligamento = false,
                    Motivo_desligamento = " - ",
                    Data_reconciliacao = 1991
                };

                //Act - metodo sob teste
                pes.salvar();
            }

            //Assert
            var ValorEsperado = pes.bd.GetUltimoRegistroPessoa();
            var valorObtido = pes.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }
    }

    class Leandro : Cida
    {
        public int numero { get; set; }
        public string texto { get; set; }
        public bool sexo { get; set; }
    }

    class Cida
    {
        public double dinheiro { get; set; }
    }
}
