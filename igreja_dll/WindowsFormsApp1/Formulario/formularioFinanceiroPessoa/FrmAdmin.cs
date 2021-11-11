using business.Classe.financeiro;
using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1.formulario.formularioFinanceiroPessoa
{
    public partial class FrmAdmin : WFCrud
    {
        public FrmAdmin() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarAdmin_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
        }

        private void maskedWhatsapp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Admin c = (Admin)modelo;
            c.Telefone.Whatsapp = maskedWhatsapp.Text;

        }

        private void maskedTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Admin c = (Admin)modelo;
            c.Telefone.Fone = maskedTelefone.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            c.Email = txtEmail.Text;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            c.NomePessoa = txtNome.Text;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            c.Password = txtSenha.Text;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            c.Email = txtUsuario.Text;
        }
        
    }
}
