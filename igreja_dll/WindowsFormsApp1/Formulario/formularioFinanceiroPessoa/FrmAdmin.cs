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
            LoadCrudForm();
            FormPadrao.LoadForm(this);

            Admin c = (Admin)modelo;
            try { maskedWhatsapp.Text = c.Telefone.Whatsapp; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { maskedTelefone.Text = c.Telefone.Fone; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtUsuario.Text = c.Email; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtNome.Text = c.NomePessoa; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtSenha.Text = c.Password; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
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
