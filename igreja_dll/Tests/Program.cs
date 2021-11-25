using business;
using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.financeiro;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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
        static int loop = 40;
        
        static void Main(string[] args)
        {    

            var types = modelocrud.listTypesSon(typeof(modelocrud));
            int num = 0;

          // Type teste = typeof(EmailPessoa);
          // var model = (modelocrud)Activator.CreateInstance(teste);
          //
          // try
          // {
          //     model.salvar();
          // }
          // catch (Exception ex)
          //   {
          //       Console.WriteLine(ex.Message);
          //       Console.WriteLine(model.GetType().Name + " - " + model.exibirMensagemErro(ex, 2));
          //   }




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
                }
                catch (Exception ex)
                {
                    Console.WriteLine(modelo.GetType().Name + " - " + ex.Message);
                    Console.WriteLine(modelo.GetType().Name + " - " + modelo.exibirMensagemErro(ex, 2));
                }
            }


            Console.WriteLine("ok");
            Console.Read();
        }

        

        public static void CadastrarMovimentacaoEntradaDizimo()
        {
            Dizimo dizimo = new Dizimo
            {
                Data = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")),
                DataRecebimento = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")),
                Pago = true,
                Valor = 25.35m                
            };

            dizimo.salvar();
        }

        #region People
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
                    Historicos = new List<Historico>(),
                    Ministerios = new List<PessoaMinisterio>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<Historico>(),
                    Ministerios = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    NomePessoa = arr[v1] + " " + arr2[v2],
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Email = arr2[v2].Replace(" ", "") + numeroGrande.ToString() + "@gmail.com",
                    Endereco = new Endereco
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
                    Historicos = new List<business.classes.Historico>(),
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
        #endregion

        #region Ministry
        public static void CadastrarLiderCelula()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Lider_Celula
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - "
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarLiderCelulaTreinamento()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Lider_Celula_Treinamento
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - "
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarLiderMinisterio()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Lider_Ministerio
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - "
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarLiderMinisterioTreinamento()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Lider_Ministerio_Treinamento
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - "
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarSupervisorCelula()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Supervisor_Celula
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - ",
                    Maximo_celula = randNum.Next(1, 5)
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarSupervisorCelulaTreinamento()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Supervisor_Celula_Treinamento
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - ",
                    Maximo_celula = randNum.Next(1, 5)
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarSupervisorMinisterio()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Supervisor_Ministerio
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - ",
                    Maximo_celula = randNum.Next(1, 5)
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarSupervisorMinisterioTreinamento()
        {
            Ministerio minis = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                minis = new Supervisor_Ministerio_Treinamento
                {
                    Celulas = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Maximo_pessoa = 5,
                    Ministro_ = null,
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Proposito = " - ",
                    Maximo_celula = randNum.Next(1, 5)
                };
                minis.salvar();
            }
            var ValorEsperado = minis.bd.GetUltimoRegistroMinisterio();
            var valorObtido = minis.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }
        #endregion

        #region Celula
        public static void CadastrarCelulaAdolescente()
        {
            Celula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new Celula_Adolescente
                {
                    Dia_semana = "Segunda",
                    Horario = new TimeSpan(randNum.Next(0, 23), randNum.Next(0, 59), 0),
                    Maximo_pessoa = randNum.Next(0, 50),
                    Ministerios = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<Pessoa>(),
                    EnderecoCelula = new EnderecoCelula
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    }
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroCelula();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCelulaCasados()
        {
            Celula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new Celula_Casado
                {
                    Dia_semana = "Terça",
                    Horario = new TimeSpan(randNum.Next(0, 23), randNum.Next(0, 59), 0),
                    Maximo_pessoa = randNum.Next(0, 50),
                    Ministerios = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<Pessoa>(),
                    EnderecoCelula = new EnderecoCelula
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    }
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroCelula();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCelulaJovem()
        {
            Celula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new Celula_Jovem
                {
                    Dia_semana = "Quarta",
                    Horario = new TimeSpan(randNum.Next(0, 23), randNum.Next(0, 59), 0),
                    Maximo_pessoa = randNum.Next(0, 50),
                    Ministerios = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<Pessoa>(),
                    EnderecoCelula = new EnderecoCelula
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    }
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroCelula();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCelulaCrianca()
        {
            Celula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new Celula_Crianca
                {
                    Dia_semana = "Quinta",
                    Horario = new TimeSpan(randNum.Next(0, 23), randNum.Next(0, 59), 0),
                    Maximo_pessoa = randNum.Next(0, 50),
                    Ministerios = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<Pessoa>(),
                    EnderecoCelula = new EnderecoCelula
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    }
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroCelula();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarCelulaAdulto()
        {
            Celula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new Celula_Adulto
                {
                    Dia_semana = "Sexta",
                    Horario = new TimeSpan(randNum.Next(0, 23), randNum.Next(0, 59), 0),
                    Maximo_pessoa = randNum.Next(0, 50),
                    Ministerios = new List<business.classes.Intermediario.MinisterioCelula>(),
                    Nome = arr[randNum.Next(0, 49)],
                    Pessoas = new List<Pessoa>(),
                    EnderecoCelula = new EnderecoCelula
                    {
                        Bairro = "Vila",
                        Cep = 36774016,
                        Cidade = "Cataguases",
                        Complemento = "residencia",
                        Estado = "MG",
                        Numero_casa = 117,
                        Pais = "Brasil",
                        Rua = "Jose"
                    }
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroCelula();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }
        #endregion

        #region Lists
        public static void CadastrarReunioes()
        {
            Reuniao cel = null;

            for (var i = 0; i < loop; i++)
            {
                int num = randNum.Next(0, 23);
                cel = new Reuniao
                {
                    Data_reuniao = new DateTime(2021, randNum.Next(8, 12), randNum.Next(5, 28)),
                    Horario_inicio = new TimeSpan(num, randNum.Next(0, 59), 0),
                    Horario_fim = new TimeSpan(num + 1, randNum.Next(0, 59), 0),
                    Pessoas = new List<ReuniaoPessoa>(),
                    Local_reuniao = " - "
                };
                cel.salvar();
            }
            var ValorEsperado = cel.bd.GetUltimoRegistroReuniao();
            var valorObtido = cel.Id;
            if (valorObtido == ValorEsperado)
                Console.WriteLine("Ok");
            else
                Console.WriteLine("aconteceu um erro.");
        }

        public static void CadastrarPessoasEmMinisterios()
        {
            PessoaMinisterio cel = null;
            var num = randNum.Next(100000000, 900000000);
            for (var i = 0; i < loop; i++)
            {
                cel = new PessoaMinisterio
                {
                    MinisterioId = randNum.Next(1, 16),
                    PessoaId = randNum.Next(2, 121)
                };
                cel.salvar();
            }
        }

        public static void CadastrarPessoasEmReunioes()
        {
            ReuniaoPessoa cel = null;
            var num = randNum.Next(100000000, 900000000);
            for (var i = 0; i < loop; i++)
            {
                cel = new ReuniaoPessoa
                {
                    ReuniaoId = randNum.Next(1, 50),
                    PessoaId = randNum.Next(2, 121)
                };
                cel.salvar();
            }
        }

        public static void CadastrarMinisteriosEmCelulas()
        {
            MinisterioCelula cel = null;
            var num = randNum.Next(100000000, 900000000);

            for (var i = 0; i < loop; i++)
            {
                cel = new MinisterioCelula
                {
                    MinisterioId = randNum.Next(1, 16),
                    CelulaId = randNum.Next(1, 15)
                };
                cel.salvar();
            }
        }
        #endregion
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cliente(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public Cliente()
        {
            this.Id = -1;
            this.Nome = string.Empty;
        }
        public void ImprimeID()
        {
            Console.WriteLine($"ID = {this.Id}");
        }
        public void ImprimeNome()
        {
            Console.WriteLine($"Nome = {this.Nome}");
        }
        public string GetNomeCompleto(string Nome, string Sobrenome)
        {
            return Nome + " " + Sobrenome;
        }
    }
}
