using business.classes.Pessoas;
using System;
using System.Windows.Forms;

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

            Admin c = (Admin)modelo;
            try { maskedWhatsapp.Text = c.Telefone.Whatsapp; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { maskedTelefone.Text = c.Telefone.Fone; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtUsuario.Text = c.Email; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtNome.Text = c.Nome; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtSenha.Text = c.Password; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void maskedWhatsapp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Admin c = (Admin)modelo;
            try { c.Telefone.Whatsapp = maskedWhatsapp.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void maskedTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Admin c = (Admin)modelo;
            try { c.Telefone.Fone = maskedTelefone.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }


        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            try { c.Nome = txtNome.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            try { c.Password = txtSenha.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            Admin c = (Admin)modelo;
            try { c.Email = txtUsuario.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

    }
}
