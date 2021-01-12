using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class ReunioesMinisteriosPessoa : WindowsFormsApp1.Formulario.FormCrudPessoa
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
                if(modelo is PessoaDado)
                {
                    var p = (PessoaDado)modelo;
                    p.celula_ = int.Parse(txt_celula.Text);
                }
                if (modelo is PessoaLgpd)
                {
                    var p = (PessoaLgpd)modelo;
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
