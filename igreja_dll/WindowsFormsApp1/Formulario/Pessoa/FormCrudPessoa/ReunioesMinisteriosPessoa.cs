using business.classes.Pessoas;
using database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class ReunioesMinisteriosPessoa : Formulario.FormCrudPessoa
    {
        public ReunioesMinisteriosPessoa()
        {
            InitializeComponent();
        }

        public ReunioesMinisteriosPessoa(bool Deletar, bool Atualizar, bool Detalhes,
        modelocrud modeloVelho, modelocrud modeloNovo)
           : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
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
            var pessoa = (business.classes.Abstrato.Pessoa)modelo;
            if(pessoa != null)
            if (pessoa.IdPessoa == 0)
            {
                txt_reunioes.Text = AddNaListaPessoaReunioes;
                txt_ministerios.Text = AddNaListaPessoaMinsterios;

                txt_celula.Text = pessoa.celula_.ToString();
            }
            else
            {
                
                var ministerios = pessoa.Ministerios;
                if (ministerios != null)
                    foreach (var item in ministerios)
                    {
                        var mini = listaMinisterios.First(i => i.IdMinisterio == item.MinisterioId);
                        txt_ministerios.Text += mini.IdMinisterio.ToString() + ", ";
                    }

                var reunioes = pessoa.Reuniao;
                if (reunioes != null)
                    foreach (var item in reunioes)
                    {
                        var reu = listaReuniao.First(i => i.IdReuniao == item.ReuniaoId);
                        txt_reunioes.Text += reu.IdReuniao.ToString() + ", ";
                    }
                        

                txt_celula.Text = pessoa.celula_.ToString();
            }


        }

        private void txt_reunioes_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var arr = txt_reunioes.Text.Replace(" ", "").Split(',');
                foreach (var valor in arr)
                {
                    if (valor != "") { int v = int.Parse(valor); }
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
                    if (valor != "")
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
                if (modelo is business.classes.Abstrato.Pessoa)
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
