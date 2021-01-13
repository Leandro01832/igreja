using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class ReunioesMinisteriosPessoa : Formulario.FormCrudPessoa
    {
        public ReunioesMinisteriosPessoa()
        {
            InitializeComponent();
        }

        public ReunioesMinisteriosPessoa(modelocrud p, bool Deletar, bool Atualizar, bool Detalhes)            
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void ReunioesMinisteriosPessoa_Load(object sender, EventArgs e)
        {
            this.Text = "Reuniões, celula e ministérios da pessoa.";

            if(modelo != null)
            {
                var pessoa = (business.classes.Abstrato.Pessoa)modelo;
                var ministerios = pessoa.Ministerios;
                if (ministerios != null)
                foreach (var item in ministerios)
                txt_ministerios.Text += item.Id.ToString() + ", ";

                var reunioes = pessoa.Reuniao;
                if (reunioes != null)
                foreach (var item in reunioes)
                txt_reunioes.Text += item.Id.ToString() + ", ";
            }
            
            
        }

        private void txt_reunioes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var arr = txt_reunioes.Text.Replace(" ", "").Split(',');
                foreach (var valor in arr)
                {
                    int v = int.Parse(valor);
                }
                AddNaListaPessoaReunioes = txt_reunioes.Text;
            }
            catch (Exception)
            {
                txt_reunioes.Text = "";
                MessageBox.Show("Informe numeros de identificação de reuniões.");
            }
        }

        private void txt_ministerios_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddNaListaPessoaMinsterios = "";
                var arr = txt_ministerios.Text.Replace(" ", "").Split(',');
                foreach (var valor in arr)
                {
                    if(valor != "")
                    {
                        int v = int.Parse(valor);
                    }
                    
                }
                AddNaListaPessoaMinsterios = txt_ministerios.Text;
            }
            catch (Exception)
            {
                AddNaListaPessoaMinsterios = "";
                txt_ministerios.Text = "";
                MessageBox.Show("Informe numeros de identificação de ministerios.");
            }
        }

        private void txt_celula_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(modelo is business.classes.Abstrato.Pessoa)
                {
                    var p = (business.classes.Abstrato.Pessoa)modelo;
                    p.celula_ = int.Parse(txt_celula.Text);
                }

            }
            catch (Exception)
            {
                txt_celula.Text = "";
                MessageBox.Show("Informe um numero de identificação de celula.");
            }
        }
    }
}
