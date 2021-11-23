using business.classes.Pessoas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas
{
    public partial class DadoPessoalLgpd : WFCrud
    {
        public DadoPessoalLgpd() : base()
        {
            InitializeComponent();
        }

        private void DadoPessoalLgpd_Load(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            try { txt_email.Text = pessoa.Email; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }


        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            pessoa.Email = txt_email.Text;
        }
    }
}
