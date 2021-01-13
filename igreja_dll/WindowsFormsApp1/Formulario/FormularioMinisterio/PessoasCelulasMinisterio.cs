using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        public PessoasCelulasMinisterio(business.classes.Abstrato.Ministerio p,
            bool Deletar, bool Atualizar, bool Detalhes)
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
        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
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
                    catch { }
                }
                catch {}
            }


        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }
    }
}
