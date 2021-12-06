using business.classes.Abstrato;
using business.classes.Pessoas;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Igreja.Test
{
    [TestFixture]
    class CadastrarPessoaTeste
    {
        [Test]
        public void CadastrarVisitanteDadoTest()
        {
            //Arranje - cenario
            Pessoa pes = null;
            string[] arr = new string[50];
            arr[0] = "Paulo";    arr[10] = "Sandra";  arr[20] = "Sebastião";  arr[30] = "Thais";         arr[40] = "Adriana";
            arr[1] = "Jorge";    arr[11] = "Jaco";   arr[21] = "Lucas";    arr[31] = "Pamela";      arr[41] = "Adriano";
            arr[2] = "Maria";    arr[12] = "Rubens";   arr[22] = "Alice";    arr[32] = "Nayara";      arr[42] = "Alex";
            arr[3] = "Pedro";    arr[13] = "Marta";   arr[23] = "Aline";    arr[33] = "Oliver";      arr[43] = "Fred";
            arr[4] = "Sandro";    arr[14] = "Madalena";   arr[24] = "Zezé";    arr[34] = "Hugo";      arr[44] = "Tiago";
            arr[5] = "Gustavo";    arr[15] = "Judas";   arr[25] = "Romulo";    arr[35] = "Icaro";      arr[45] = "Neymar";
            arr[6] = "Henrique";    arr[16] = "Amanda";   arr[26] = "Geraldo";    arr[36] = "Bruno";      arr[46] = "Mariano";
            arr[7] = "Isaque";    arr[17] = "Erik";   arr[27] = "Denis";    arr[37] = "Vinicius";      arr[47] = "Fabricio";
            arr[8] = "Salomão";    arr[18] = "Leonardo";   arr[28] = "Gisele";    arr[38] = "Ramon";      arr[48] = "Felipe";
            arr[9] = "Camila";    arr[19] = "Simone";   arr[29] = "Bianca";    arr[39] = "Charles";      arr[49] = "Carlos";

            string[] arr2 = new string[10];
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

            Random randNum = new Random();
            
            for(var i = 0; i < 150; i++)
            {
                int v1 = randNum.Next(0, 49);
                int v2 = randNum.Next(0, 9);
                int ano = randNum.Next(0, 100);
                var numero = 91111111111 + i;

                pes = new Visitante
                {
                    celula_ = null,
                    Chamada = new business.classes.Chamada
                    {
                        Data_inicio = DateTime.Now,
                        Numero_chamada = 0
                    },
                  //  Codigo = Pessoa.recuperarTodos().OfType<Pessoa>().OrderBy(p => p.Id).Last().Id + 1,
                    Img = "",
                    Historicos = new List<business.classes.Historico>(),
                    Ministerio = new List<business.classes.Intermediario.PessoaMinisterio>(),
                    Nome = arr[v1] + " " + arr2[v2],
                    Condicao_religiosa = " - ",
                    Cpf = numero.ToString(),
                    Data_nascimento = DateTime.Now.AddYears(-ano),
                    Data_visita = DateTime.Now,
                    Email = arr2[v2].Replace(" ", "") + "@gmail.com",
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
           // var ValorEsperado = Pessoa.recuperarTodos().OfType<Pessoa>().OrderBy(p => p.Id).Last().Id;
            var valorObtido = pes.Id;
            Assert.AreEqual(0, valorObtido);
        }


    }
}
