using business;
using business.classes;
using business.classes.Abstrato;
using business.classes.Esboco;
using business.classes.Esboco.Abstrato;
using business.classes.financeiro;
using business.classes.Pessoas;
using business.implementacao;
using database;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1
{
    public class ImprimirRelatorio
    {
        public ImprimirRelatorio()
        {
        }

        public void imprimir(Type Tipo)
        {
            PdfPTable table = null;
            var valorTipo = "";
            var porcentagem = "";
            int totalPessoas = modelocrud.Modelos.OfType<Pessoa>().ToList().Count;
            int totalMinisterios = modelocrud.Modelos.OfType<Ministerio>().ToList().Count;
            int totalCelulas = modelocrud.Modelos.OfType<Celula>().ToList().Count;
            var Modelos = modelocrud.Modelos.Where(i => i.GetType().Name == Tipo.Name ||
                i.GetType().IsSubclassOf(Tipo)).ToList();

            if (Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                table = new PdfPTable(2);
                var quant = Modelos.Count;
                decimal p = (quant / totalPessoas);
                porcentagem = "A procentagem em relação ao total de pessoas é "
                    + p.ToString("F2") + "%. Quantidade de registros é: "
                    + quant;
            }

            if (Tipo.IsSubclassOf(typeof(Celula)))
            {
                var quant = Modelos.Count;
                decimal p = (quant / totalCelulas);
                porcentagem = "A procentagem em relação ao total de celulas é "
                    + p.ToString("f2") + "%. Quantidade de registros é: "
                    + quant;
            }

            if (Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                var quant = modelocrud.Modelos.Where(i => i.GetType().Name == Tipo.Name ||
                i.GetType().IsSubclassOf(Tipo)).ToList().Count;
                decimal p = (quant / totalMinisterios);
                porcentagem = "A procentagem em relação ao total de ministérios é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
            }

            if (Tipo == typeof(Reuniao)) table = new PdfPTable(3);

            if (Tipo.IsSubclassOf(typeof(Pessoa))) table = new PdfPTable(2);

            if (Tipo.IsSubclassOf(typeof(PessoaLgpd))) table = new PdfPTable(3);

            if (Tipo == typeof(Ministerio)) table = new PdfPTable(2);

            if (Tipo == typeof(Celula)) table = new PdfPTable(2);

            if (Tipo == typeof(MudancaEstado)) table = new PdfPTable(5);

            if (Tipo == typeof(Movimentacao)) table = new PdfPTable(5);

            if (Tipo == typeof(Mensagem)) table = new PdfPTable(2);

            if (Tipo == typeof(Fonte)) table = new PdfPTable(2);

            if (Tipo == typeof(Email)) table = new PdfPTable(3);

            if (Tipo == typeof(Permissao)) table = new PdfPTable(2);

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


            if (Tipo == typeof(Reuniao))
                foreach (var item in Modelos)
                {
                    table.AddCell("Id: " + item.Id.ToString());

                    var props = item.GetType().GetProperties();

                    if (item.GetType().GetProperty("Nome") != null)
                    {
                        var p = item.GetType().GetProperty("Nome");
                        table.AddCell("Nome: " + p.GetValue(item).ToString());
                    }

                    if (item.GetType().GetProperty("Data") != null)
                    {
                        var p = item.GetType().GetProperty("Data");
                        table.AddCell("Data: " + p.GetValue(item).ToString());
                    }

                    if (item is Reuniao)
                    {
                        var m = (Reuniao)item;
                        table.AddCell("Data da reunião: " + m.Data_reuniao.ToString());
                        table.AddCell("Horario de inicio: " + m.Horario_inicio.ToString());
                    }

                    if (item is PessoaLgpd)
                    {
                        var m = (PessoaLgpd)item;
                        table.AddCell("Email: " + m.Email.ToString());
                    }

                    if (item is MudancaEstado)
                    {
                        var m = (MudancaEstado)item;
                        table.AddCell("antigo estado: " + m.velhoEstado);
                        table.AddCell("novo estado: " + m.novoEstado);
                        table.AddCell("Codigo: " + m.Codigo);
                    }

                    if (item is Movimentacao)
                    {
                        var m = (Movimentacao)item;
                        table.AddCell("Valor: " + m.Valor);
                        table.AddCell("Tipo: " + m.GetType().Name);
                    }

                    if (item is Mensagem)
                    {
                        var m = (Mensagem)item;
                        table.AddCell("Tipo: " + m.Tipo);
                    }

                    if (item is Fonte)
                    {
                        var m = (Fonte)item;
                        table.AddCell("Mensagem Id: " + m.MensagemId);
                    }

                    if (item is Email)
                    {
                        var m = (Email)item;
                        table.AddCell("Assunto: " + m.Assunto);
                    }

                    if (item is Permissao)
                    {
                        var m = (Permissao)item;
                        table.AddCell("Nome: " + m.Nome);
                    }
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
