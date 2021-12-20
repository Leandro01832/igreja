using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmVersiculo : WFCrud
    {
        List<Book> listaLivro;
        List<Chapter> listaCapitulo;
        Book livro;
        Objeto obj;

        public FrmVersiculo() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarVersiculo_Load(object sender, EventArgs e)
        {
            buscarVersiculosBiblia();

            var v = (business.classes.Fontes.Versiculo)modelo;
            try { txt_texto.Text = v.Texto; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { combo_livro.Text = v.Livro; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { combo_capitulo.Text = v.Capitulo.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void txt_texto_TextChanged(object sender, EventArgs e)
        {
            var v = (business.classes.Fontes.Versiculo)modelo;
            try { v.Texto = txt_texto.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }


        private async void buscarVersiculosBiblia()
        {
            HttpClient cliente = new HttpClient();
            listaLivro = new List<Book>();

            try
            {
                var resultado = await cliente.GetStringAsync("https://www.abibliadigital.com.br/api/books");

                var livrosJson = JsonConvert.DeserializeObject<Book[]>(resultado);
                foreach (var livroJson in livrosJson)
                {
                    listaLivro.Add(new Book
                    {
                        author = livroJson.author,
                        group = livroJson.group,
                        name = livroJson.name,
                        testament = livroJson.testament,
                        chapters = livroJson.chapters,
                        abbrev = new Abbrev
                        {
                            en = livroJson.abbrev.en,
                            pt = livroJson.abbrev.pt
                        }
                    });
                }

                foreach (var item in listaLivro)
                {
                    combo_livro.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na leitura dos dados: " + ex.Message);

            }
        }

        private void combo_livro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = (business.classes.Fontes.Versiculo)modelo;
            try { v.Livro = combo_livro.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

            combo_capitulo.Items.Clear();
            livro = listaLivro.First(i => i.name == combo_livro.Text);
            int capitulos = livro.chapters;
            int[] numeros = new int[capitulos];

            int indice = 0;
            foreach (int item in numeros)
            {
                indice++;
                combo_capitulo.Items.Add(indice);
            }
        }

        private async void combo_capitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = (business.classes.Fontes.Versiculo)modelo;
            try { v.Capitulo = int.Parse(combo_capitulo.Text); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

            combo_versiculo.Items.Clear();
            HttpClient cliente = new HttpClient();
            listaCapitulo = new List<Chapter>();
            var l = livro.abbrev.pt;
            var cap = combo_capitulo.Text;

            try
            {
                var resultado =
                await cliente
                .GetStringAsync("https://www.abibliadigital.com.br/api/verses/nvi/"
                    + l + "/" + cap);

                obj = JsonConvert.DeserializeObject<Objeto>(resultado);


                for (int i = 1; i < obj.chapter.verses; i++)
                {
                    combo_versiculo.Items.Add(i);
                }

                foreach (var item in obj.verses)
                {
                    txt_texto.Text += item.number.ToString() + " - " + item.text + "\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na leitura dos dados: " + ex.Message);

            }
        }

        private void combo_versiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modelo = obj.verses.First(i => i.number == int.Parse(combo_versiculo.Text));
            txt_texto.Text = modelo.number + " - " + modelo.text + "\r\n";
        }
    }

    public class Objeto
    {
        public Book book { get; set; }
        public Chapter chapter { get; set; }
        public List<Vers> verses { get; set; }
    }

    public class Abbrev
    {
        public string pt { get; set; }
        public string en { get; set; }
    }

    public class Book
    {
        public Abbrev abbrev { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string group { get; set; }
        public string version { get; set; }
        public int chapters { get; set; }
        public string testament { get; set; }

        public override string ToString()
        {
            return this.name;
        }
    }

    public class Chapter
    {
        public int number { get; set; }
        public int verses { get; set; }
    }

    public class Vers
    {
        public int number { get; set; }
        public string text { get; set; }
    }
}
