using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
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

        public void imprimir(modelocrud modelo, string tipo)
        {
         List<modelocrud> lista = new List<modelocrud>();
         PdfPTable table = null;
         var valorTipo = "";
         var porcentagem = "";
         int totalPessoas = Pessoa.recuperarTodos().Count;
         int totalMinisterios = Ministerio.recuperarTodosMinisterios().Count;
         int totalCelulas = Celula.recuperarTodasCelulas().Count;

         if (modelo != null)
             lista = modelo.recuperar(null);
         foreach(var item in lista)
         {
             var i = 0;
             lista[i] = item.recuperar(item.Id)[0];
             i++;
         }

         if (modelo != null && modelo is Pessoa)
         {
             var quant = modelo.recuperar(null).Count;
             decimal p = (quant / totalPessoas);
             porcentagem = "A procentagem em ralação ao total de pessoas é "
                 + p.ToString("F2") + "%. Quantidade de registros é: "
                 + quant;
         }

         if (modelo != null && modelo is Celula)
         {
             var quant = modelo.recuperar(null).Count;
             decimal p = (quant / totalCelulas);
             porcentagem = "A procentagem em ralação ao total de celulas é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
         }

         if (modelo != null && modelo is Ministerio)
         {
         var quant = modelo.recuperar(null).Count;
             decimal p = (quant / totalMinisterios);
             porcentagem = "A procentagem em ralação ao total de ministérios é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
         }

         if (modelo is Reuniao)
             table = new PdfPTable(3);

         

         if (tipo == "Pessoa" && modelo == null)
         {
             lista = Pessoa.recuperarTodos();
             table = new PdfPTable(2);
                foreach (var item in lista)
                {
                    var i = 0;
                    lista[i] = item.recuperar(item.Id)[0];
                    i++;
                }
            }

         if (tipo == "MembroLgpd" && modelo == null)
         {
             lista = MembroLgpd.recuperarTodosMembros();
             table = new PdfPTable(2);
                foreach (var item in lista)
                {
                    var i = 0;
                    lista[i] = item.recuperar(item.Id)[0];
                    i++;
                }
            }

         if (tipo == "Membro" && modelo == null)
         {
             lista = Membro.recuperarTodosMembros();
             table = new PdfPTable(2);
                foreach (var item in lista)
                {
                    var i = 0;
                    lista[i] = item.recuperar(item.Id)[0];
                    i++;
                }
            }

         if (tipo == "Ministerio" && modelo == null)
         {
             lista = Ministerio.recuperarTodosMinisterios();
             table = new PdfPTable(2);
                foreach (var item in lista)
                {
                    var i = 0;
                    lista[i] = item.recuperar(item.Id)[0];
                    i++;
                }
            }

         if (tipo == "Celula" && modelo == null)
         {
             lista = Celula.recuperarTodasCelulas();
             table = new PdfPTable(2);
                foreach (var item in lista)
                {
                    var i = 0;
                    lista[i] = item.recuperar(item.Id)[0];
                    i++;
                }
            }

         if (tipo != "")
             valorTipo = tipo;
         else
             valorTipo = modelo.GetType().Name;

         Document doc = new Document(PageSize.A4);
         doc.SetMargins(40, 40, 40, 80);

         string path = Directory.GetCurrentDirectory();

         string caminho = path + @"\relatorio\" + "relatorio-" + valorTipo + "-" + DateTime.Now.ToString() + ".pdf";

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



         foreach (var item in lista.OfType<Reuniao>())
         {
             table.AddCell("Id: " + item.Id.ToString());
             table.AddCell("Data da reunião: " + item.Data_reuniao.ToString());
         }

         foreach (var item in lista.OfType<PessoaDado>())
         {
             table.AddCell("Id: " + item.Id.ToString());
             table.AddCell("Email: " + item.Nome.ToString());
         }

            foreach (var item in lista.OfType<PessoaLgpd>())
            {
                table.AddCell("Id: " + item.Id.ToString());
                table.AddCell("Email: " + item.Email.ToString());
            }

            foreach (var item in lista.OfType<Ministerio>())
         {
             table.AddCell("Id: " + item.Id.ToString());
             table.AddCell("Data da reunião: " + item.Nome.ToString());
         }

         foreach (var item in lista.OfType<Celula>())
         {
             table.AddCell("Id: " + item.Id.ToString());
             table.AddCell("Data da reunião: " + item.Nome.ToString());
         }

         foreach (var item in lista.OfType<Historico>())
         {
             table.AddCell("Data de inicio: " + item.Data_inicio.ToString());
             table.AddCell("Data final: " + item.Data_inicio.AddDays(60).ToString());
             table.AddCell("Faltas: " + item.Falta.ToString());
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
