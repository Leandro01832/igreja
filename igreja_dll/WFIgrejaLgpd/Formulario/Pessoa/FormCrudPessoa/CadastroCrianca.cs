using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class CadastroCrianca : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public CadastroCrianca(business.classes.Abstrato.PessoaLgpd p, bool Atualizar, bool Deletar, bool Detalhes)
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
            P = p;
        }

        public business.classes.Abstrato.PessoaLgpd P { get; }

        private void CadastroCrianca_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de Criança.";

            if(modelo.Id != 0)
            {
                var p = (business.classes.PessoasLgpd.CriancaLgpd)modelo;
                txt_nome_pai.Text = p.Nome_pai;
                txt_nome_mae.Text = p.Nome_mae;
            }
            
        }

        private void Proximo_Click(object sender, EventArgs e)
        {

        }

        private void txt_nome_pai_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.PessoasLgpd.CriancaLgpd)modelo;
            p.Nome_pai = txt_nome_pai.Text;
        }

        private void txt_nome_mae_TextChanged(object sender, EventArgs e)
        {
            var p = (business.classes.PessoasLgpd.CriancaLgpd)modelo;
            p.Nome_mae = txt_nome_mae.Text;
        }
    }
}
