using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using business.classes.Abstrato;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class DadoPessoal : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public DadoPessoal(business.classes.Pessoas.PessoaLgpd P, bool Deletar, bool Atualizar,  bool Detalhes)
            : base(P, Deletar, Atualizar,  Detalhes)
        { 
            InitializeComponent();
        }

        private void DadoPessoal_Load(object sender, EventArgs e)
        {
            this.Text = "Daddos pessoais.";
            if (modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.PessoaLgpd)modelo;
                textemail.Text = p.Email;
            }
        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaLgpd)modelo;
            p.Email = textemail.Text;
        }

    }
}
