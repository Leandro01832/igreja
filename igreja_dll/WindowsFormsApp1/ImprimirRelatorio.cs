using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public class ImprimirRelatorio
    {
        public ImprimirRelatorio(List<Pessoa> Pessoas, List<Ministerio> Ministerios,
            List<Celula> Celulas, List<Reuniao> Reuniao, List<MudancaEstado> MudancaEstado)
        {
            this.Pessoas = Pessoas;
            this.Ministerios = Ministerios;
            this.Celulas = Celulas;
            this.Reuniao = Reuniao;
            this.MudancaEstado = MudancaEstado;
        }

        public List<Pessoa> Pessoas { get; }
        public List<Ministerio> Ministerios { get; }
        public List<Celula> Celulas { get; }
        public List<Reuniao> Reuniao { get; }
        public List<MudancaEstado> MudancaEstado { get; }

        public void imprimir(Type Tipo)
        {
            PdfPTable table = null;
            var valorTipo = "";
            var porcentagem = "";
            int totalPessoas = Pessoas.Count;
            int totalMinisterios = Ministerios.Count;
            int totalCelulas = Celulas.Count;

            if (Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                table = new PdfPTable(2);
                var quant = Pessoas.Where(i =>  i.GetType().Name == Tipo.Name).ToList().Count;
                decimal p = (quant / totalPessoas);
                porcentagem = "A procentagem em relação ao total de pessoas é "
                    + p.ToString("F2") + "%. Quantidade de registros é: "
                    + quant;
            }

            if (Tipo.IsSubclassOf(typeof(Celula)))
            {
                var quant = Celulas.Where(i => i.GetType().Name == Tipo.Name).ToList().Count;
                decimal p = (quant / totalCelulas);
                porcentagem = "A procentagem em relação ao total de celulas é "
                    + p.ToString("f2") + "%. Quantidade de registros é: "
                    + quant;
            }

            if (Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                var quant = Ministerios.Where(i => i.GetType().Name == Tipo.Name).ToList().Count;
                decimal p = (quant / totalMinisterios);
                porcentagem = "A procentagem em relação ao total de ministérios é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
            }

            if (Tipo == typeof(Reuniao)) table = new PdfPTable(3);

            if (Tipo.IsSubclassOf(typeof(Pessoa))) table = new PdfPTable(2);

            if (Tipo == typeof(Ministerio)) table = new PdfPTable(2);

            if (Tipo == typeof(Celula)) table = new PdfPTable(2);

            if (Tipo == typeof(MudancaEstado)) table = new PdfPTable(4);

            if (Tipo.IsAbstract)
                valorTipo = Tipo.Name;
            else
                valorTipo = Tipo.Name;

            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);

            string path = Directory.GetCurrentDirectory();

            string caminho = path + @"\relatorio\" + "relatorio-" + valorTipo + "-" + DateTime.Now.ToString("dd-MM-yyyy") + ".pdf";

            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add("Relatório \n\n");
            doc.Add(titulo);



            Paragraph paragrafo = new Paragraph("", new Font(Font.NORMAL, 12));
            string conteudo = "Este é um relatório do dia " + DateTime.Now.ToString("dd/MM/yyyy") +
            " cujo o conteudo é referente a " + valorTipo + $". {porcentagem} \n\n";

            paragrafo.Add(conteudo);
            doc.Add(paragrafo);


            if(Tipo == typeof(Reuniao))
            foreach (var item in Reuniao)
            {
                table.AddCell("Id: " + item.IdReuniao.ToString());
                table.AddCell("Data da reunião: " + item.Data_reuniao.ToString());
                table.AddCell("Horario de inicio: " + item.Horario_inicio.ToString());
            }


            if (Tipo == typeof(Pessoa))
            {
                foreach (var item in Pessoas)
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    if(Tipo.IsSubclassOf(typeof(PessoaDado)))
                    table.AddCell("Nome: " + item.NomePessoa.ToString());
                    if (Tipo.IsSubclassOf(typeof(PessoaLgpd)))
                        table.AddCell("Email: " + item.Email.ToString());
                }
            }
            else if (Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                foreach (var item in Pessoas.Where(i => i.GetType().Name == Tipo.Name))
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    if (Tipo.IsSubclassOf(typeof(PessoaDado)))
                        table.AddCell("Nome: " + item.NomePessoa.ToString());
                    if (Tipo.IsSubclassOf(typeof(PessoaLgpd)))
                        table.AddCell("Email: " + item.Email.ToString());
                }
            }

            if (Tipo == typeof(PessoaDado))
            {
                foreach (var item in Pessoas.OfType<PessoaDado>())
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    table.AddCell("Nome: " + item.NomePessoa.ToString());
                } 
            }
            else if (Tipo.IsSubclassOf(typeof(PessoaDado)))
            {
                foreach (var item in Pessoas.Where(i => i.GetType().Name == Tipo.Name))
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    table.AddCell("Nome: " + item.NomePessoa.ToString());
                }
            }


            if (Tipo == typeof(PessoaLgpd))
            {
                foreach (var item in Pessoas.OfType<PessoaLgpd>().ToList())
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    table.AddCell("Email: " + item.Email.ToString());
                } 
            }
            else if (Tipo.IsSubclassOf(typeof(PessoaLgpd)))
            {
                foreach (var item in Pessoas.Where(i => i.GetType().Name == Tipo.Name))
                {
                    table.AddCell("ID: " + item.Codigo.ToString());
                    table.AddCell("Email: " + item.Email.ToString());
                }
            }


            if (Tipo == typeof(Ministerio))
            {
                foreach (var item in Ministerios)
                {
                    table.AddCell("Id: " + item.IdMinisterio.ToString());
                    table.AddCell("Nome do ministério: " + item.Nome.ToString());
                } 
            }
            else if (Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                foreach (var item in Ministerios.Where(i => i.GetType().Name == Tipo.Name))
                {
                    table.AddCell("Id: " + item.IdMinisterio.ToString());
                    table.AddCell("Nome do ministério: " + item.Nome.ToString());
                }
            }


            if (Tipo == typeof(Celula))
            {
                foreach (var item in Celulas)
                {
                    table.AddCell("Id: " + item.IdCelula.ToString());
                    table.AddCell("Nome da celula: " + item.Nome.ToString());
                } 
            }
            else if (Tipo.IsSubclassOf(typeof(Celula)))
            {
                foreach (var item in Celulas.Where(i => i.GetType().Name == Tipo.Name))
                {
                    table.AddCell("Id: " + item.IdCelula.ToString());
                    table.AddCell("Nome da celula: " + item.Nome.ToString());
                }
            }

            if (Tipo == typeof(MudancaEstado))
            foreach (var item in MudancaEstado.OfType<MudancaEstado>())
            {
                table.AddCell("Data da mudança: " + item.DataMudanca.ToString("dd/MM/yyyy"));
                table.AddCell("antigo estado: " + item.velhoEstado);
                table.AddCell("novo estado: " + item.novoEstado);
                table.AddCell("Id da pessoa: " + item.CodigoPessoa);
            }

            doc.Add(table);

            string caminhoImg =
            "http://www.clickfamilia.org.br/oikos2015/wp-content/uploads/2019/07/what-is-family-ministry-lead-300x225.jpg";
            Image img = Image.GetInstance(caminhoImg);

            doc.Add(img);

            doc.Close();

            System.Diagnostics.Process.Start(caminho);
        }
    }
}
