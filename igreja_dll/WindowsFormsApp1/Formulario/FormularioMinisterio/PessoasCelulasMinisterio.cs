using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class PessoasCelulasMinisterio : FormCrudMinisterio
    {
        public PessoasCelulasMinisterio()
        {
            InitializeComponent();
        }
        List<business.classes.Abstrato.Pessoa> lista;

        public PessoasCelulasMinisterio(Ministerio p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas e pessoas do ministério.";
            lista = new List<business.classes.Abstrato.Pessoa>();
            lista = business.classes.Abstrato.Pessoa.recuperarTodos()
            .OfType<business.classes.Abstrato.Pessoa>().ToList();

            var ministerio = (Ministerio)modelo;
            if (ministerio.Id == 0)
            {
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                {
                    var arr = AddNaListaMinisterioPessoas.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        var modelo = lista.First(m => m.Id == int.Parse(item));
                        txt_pessoas.Text = modelo.Codigo.ToString() + ", ";
                    }

                }

                txt_celulas.Text = AddNaListaMinisterioCelulas;
            }

            else if (modelo != null)
            {
                var mini = (Ministerio)modelo;
                var celulas = mini.Celulas;
                if (celulas != null)
                    foreach (var item in celulas)
                        txt_celulas.Text += item.Id.ToString() + ", ";

                var pessoas = mini.Pessoas;
                if (pessoas != null)
                    foreach (var item in pessoas)
                        txt_pessoas.Text += item.Pessoa.Codigo.ToString() + ", ";
            }

        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }

        private void txt_pessoas_Leave(object sender, EventArgs e)
        {
            AddNaListaMinisterioPessoas = "";
            var arr = txt_pessoas.Text.Replace(" ", "").Split(',');

            foreach (var item in arr)
            {
                try
                {
                    int numero = int.Parse(item);
                    var modelo = lista.FirstOrDefault(i => i.Codigo == numero);
                    try
                    {
                        AddNaListaMinisterioPessoas += modelo.Id.ToString() + ", ";
                    }
                    catch
                    {
                        AddNaListaMinisterioPessoas = "";
                        txt_pessoas.Text = "";
                        MessageBox.Show("Este formulario não esta atualizado." +
                        " Para atualizar feche e abra novamente o formulario.");
                    }
                }
                catch
                {
                    AddNaListaMinisterioPessoas = "";
                    txt_pessoas.Text = "";
                    txt_pessoas.Focus();
                    MessageBox.Show("Informe numeros de identificação de pessoas.");
                }
            }
        }
    }
}
