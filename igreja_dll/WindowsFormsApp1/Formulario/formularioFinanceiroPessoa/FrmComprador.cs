using business.classes.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioFinanceiroPessoa
{
    public partial class FrmComprador : WFCrud
    {
        public FrmComprador()
            : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarComprador_Load(object sender, EventArgs e)
        {
            Comprador c = (Comprador)modelo;
            try { maskedWhatsapp.Text = c.Telefone.Whatsapp; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { maskedTelefone.Text = c.Telefone.Fone; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtEmail.Text = c.Email; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtNome.Text = c.NomePessoa; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void maskedWhatsapp_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Comprador c = (Comprador)modelo;
            c.Telefone.Whatsapp = maskedWhatsapp.Text;

        }

        private void maskedTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Comprador c = (Comprador)modelo;
            c.Telefone.Fone = maskedTelefone.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Comprador c = (Comprador)modelo;
            c.Email = txtEmail.Text;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            Comprador c = (Comprador)modelo;
            c.NomePessoa = txtNome.Text;
        }
    }
}
