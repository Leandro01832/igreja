using business;
using business.classes.Pessoas;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmAutenticacao : Form
    {
        public FrmAutenticacao()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(FrmPrincipal.PrimeiroAdminEmail == txtEmail.Text && FrmPrincipal.PrimeiroAdminSenha == txtSenha.Text)
            {
                modelocrud.ativarAutenticacao = true;
                this.Dispose();
            }
            else
            if(modelocrud.Modelos.OfType<Atendente>()
            .FirstOrDefault(m => m.Senha == txtSenha.Text &&
            m.Email == txtEmail.Text) != null)
            {
                modelocrud.pessoa = modelocrud.Modelos.OfType<Atendente>()
                .First(m => m.Senha == txtSenha.Text &&
                m.Email == txtEmail.Text);
                this.Dispose();
            }
        }

        private void FrmAutenticacao_Load(object sender, EventArgs e)
        {
            FrmPrincipal.LoadForm(this);
        }
    }
}
