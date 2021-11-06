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

namespace WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa
{
    public partial class DadoPessoalLgpd : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public DadoPessoalLgpd(PessoaLgpd P,
             bool Deletar, bool Atualizar, bool Detalhes)
             : base(P, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void DadoPessoalLgpd_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var pessoa = (PessoaLgpd)modelo;
                txt_email.Text = pessoa.Email;
            }
                
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            var pessoa = (PessoaLgpd)modelo;
            pessoa.Email = txt_email.Text;
        }
    }
}
