using business.classes.Pessoas;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    public partial class FrmEmail : WFCrud
    {
        public FrmEmail() : base()
        {
            InitializeComponent();
        }

        private void DadoPessoalLgpd_Load(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            try { txt_email.Text = pessoa.Email; } catch (Exception ex)
            { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }


        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            try { pessoa.Email = txt_email.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }
    }
}
