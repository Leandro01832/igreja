using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class CadastroMembroBatismo : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public CadastroMembroBatismo(business.classes.Abstrato.PessoaLgpd p, bool Atualizar, bool Deletar, bool Detalhes)
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
            P = p;
        }

        public business.classes.Abstrato.PessoaLgpd P { get; }

        private void CadastroMembroBatismo_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por batismo.";
        }

    }
}
