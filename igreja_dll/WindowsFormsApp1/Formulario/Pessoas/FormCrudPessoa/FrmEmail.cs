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
            PessoaLgpd p = null;
            if (modelo != null)
                p = (PessoaLgpd)modelo;
            else
                p = (PessoaLgpd)ModeloNovo;
            try { txt_email.Text = p.Email; } catch (Exception ex)
            { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }


        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            try { pessoa.Email = txt_email.Text; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
        }
    }
}
