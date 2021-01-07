using database;
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
    public partial class CadastroMembroReconciliacao : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public CadastroMembroReconciliacao(business.classes.Pessoas.PessoaLgpd p, bool Deletar, bool Atualizar,  bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public CadastroMembroReconciliacao(modelocrud modelo, modelocrud modeloNovo)
            : base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        private void CadastroMembroReconciliacao_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por reconciliação.";
            if(modelo != null)
            if(modelo.Id != 0)
            {
                var p = (business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd)modelo;
                txt_reconciliacao.Text = p.Data_reconciliacao.ToString();
            }       
            
        }

        private void txt_reconciliacao_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd)modelo;
                try
                {
                    p.Data_reconciliacao = int.Parse(txt_reconciliacao.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                }
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd)ModeloNovo;
                try
                {
                    p.Data_reconciliacao = int.Parse(txt_reconciliacao.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                }
            }

        }
    }
}
