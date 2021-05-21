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
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class ImprimirRelatorio
    {
        public ImprimirRelatorio(List<Pessoa> Pessoas, List<Ministerio> Ministerios,
            List<Celula> Celulas, List<Reuniao> Reuniao)
        {
            this.Pessoas = Pessoas;
            this.Ministerios = Ministerios;
            this.Celulas = Celulas;
            this.Reuniao = Reuniao;
        }

        public List<Pessoa> Pessoas { get; }
        public List<Ministerio> Ministerios { get; }
        public List<Celula> Celulas { get; }
        public List<Reuniao> Reuniao { get; }

        public void  imprimir(List<modelocrud> listamodelo, string tipo)
        {
         List<modelocrud> lista = new List<modelocrud>();
         PdfPTable table = null;
         var valorTipo = "";
         var porcentagem = "";
         var ListaPessoas = Pessoas;
         int totalPessoas = ListaPessoas.Count;
         var ListaMinisterios = Ministerios;
         int totalMinisterios = ListaMinisterios.Count;
         var ListaCelulas = Celulas;
         int totalCelulas = ListaCelulas.Count;

            if (listamodelo != null)
         if (listamodelo[0] != null && listamodelo[0] is Pessoa)
         {                
                lista = listamodelo;
                table = new PdfPTable(2);
                var quant = lista.Count;
             decimal p = (quant / totalPessoas);
             porcentagem = "A procentagem em relação ao total de pessoas é "
                 + p.ToString("F2") + "%. Quantidade de registros é: "
                 + quant;
         }

            if (listamodelo != null)
                if (listamodelo[0] != null && listamodelo[0] is Celula)
         {
                lista = listamodelo;
                var quant = lista.Count;
             decimal p = (quant / totalCelulas);
             porcentagem = "A procentagem em relação ao total de celulas é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
         }

            if (listamodelo != null)
                if (listamodelo[0] != null && listamodelo[0] is Ministerio)
         {
                lista = listamodelo;
                var quant = lista.Count;
                decimal p = (quant / totalMinisterios);
                porcentagem = "A procentagem em relação ao total de ministérios é "
                 + p.ToString("f2") + "%. Quantidade de registros é: "
                 + quant;
         }

            if (listamodelo != null)
                if (listamodelo[0] is Reuniao)
             table = new PdfPTable(3);

         

         if (tipo == "Pessoa" && listamodelo == null)
         {
             table = new PdfPTable(2);
                foreach (var item in Pessoas)
                lista.Add(item);
         }

         if (tipo == "MembroLgpd" && listamodelo == null)
         {
             table = new PdfPTable(2);
                foreach (var item in Pessoas.OfType<MembroLgpd>())
                    lista.Add(item);
            }

         if (tipo == "Membro" && listamodelo == null)
         {
             table = new PdfPTable(2);
                foreach (var item in Pessoas.OfType<Membro>())
                    lista.Add(item);
            }

         if (tipo == "Ministerio" && listamodelo == null)
         {
             table = new PdfPTable(2);
                foreach (var item in Ministerios)
                    lista.Add(item);
            }

         if (tipo == "Celula" && listamodelo == null)
         {
             table = new PdfPTable(2);
                foreach (var item in Celulas)
                    lista.Add(item);
         }

         if(listamodelo[0] is MudancaEstado)
         table = new PdfPTable(4);

            if (tipo != "")
             valorTipo = tipo;
         else
             valorTipo = listamodelo[0].GetType().Name;

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



         foreach (var item in lista.OfType<Reuniao>())
         {
             table.AddCell("Id: " + item.IdReuniao.ToString());
             table.AddCell("Data da reunião: " + item.Data_reuniao.ToString());
         }

         foreach (var item in lista.OfType<PessoaDado>())
         {
             table.AddCell("ID: " + item.Codigo.ToString());
             table.AddCell("Nome: " + item.NomePessoa.ToString());
         }

            foreach (var item in lista.OfType<PessoaLgpd>().ToList())
            {
                table.AddCell("ID: " + item.Codigo.ToString());
                table.AddCell("Email: " + item.Email.ToString());
            }

            foreach (var item in lista.OfType<Ministerio>())
         {
             table.AddCell("Id: " + item.IdMinisterio.ToString());
             table.AddCell("Data da reunião: " + item.Nome.ToString());
         }

         foreach (var item in lista.OfType<Celula>())
         {
             table.AddCell("Id: " + item.IdCelula.ToString());
             table.AddCell("Data da reunião: " + item.Nome.ToString());
         }

         foreach (var item in lista.OfType<Historico>())
         {
             table.AddCell("Data de inicio: " + item.Data_inicio.ToString());
             table.AddCell("Data final: " + item.Data_inicio.AddDays(60).ToString());
             table.AddCell("Faltas: " + item.Falta.ToString());
         }

            foreach (var item in lista.OfType<MudancaEstado>())
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
