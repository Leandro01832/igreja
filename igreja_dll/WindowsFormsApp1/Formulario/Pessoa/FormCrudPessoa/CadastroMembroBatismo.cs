using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;
using business.classes.Pessoas;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroMembroBatismo : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroMembroBatismo(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroBatismo(PessoaDado p, bool Atualizar, bool Deletar, bool Detalhes)            
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
            P = p;
        }

        public CadastroMembroBatismo(PessoaLgpd p, bool Atualizar, bool Deletar, bool Detalhes)            
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
        }

        public PessoaDado P { get; }

        private void CadastroMembroBatismo_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por batismo.";
        }

    }
}
