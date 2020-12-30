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

namespace WindowsFormsApp1.Formulario.Ministerio
{
    public partial class PessoasCelulasMinisterio : FormCrudMinisterio
    {
        public PessoasCelulasMinisterio()
        {
            InitializeComponent();
        }

        public PessoasCelulasMinisterio(business.classes.Abstrato.Ministerio p, bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }
        
               
        private void PessoasCelulasMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas e pessoas do ministério.";
        }

        private void txt_pessoas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioPessoas = txt_pessoas.Text;
        }

        private void txt_celulas_TextChanged(object sender, EventArgs e)
        {
            AddNaListaMinisterioCelulas = txt_celulas.Text;
        }
    }
}
