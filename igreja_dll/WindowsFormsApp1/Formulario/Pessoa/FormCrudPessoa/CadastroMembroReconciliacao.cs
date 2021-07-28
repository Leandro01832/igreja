using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class CadastroMembroReconciliacao : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroMembroReconciliacao(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroReconciliacao(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho,
            modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroReconciliacao(modelocrud p, bool Deletar, bool Atualizar,  bool Detalhes)            
        : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void CadastroMembroReconciliacao_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por reconciliação.";
            if(modelo != null)
            {
                if(modelo is Membro_Reconciliacao)
                {
                    var p = (Membro_Reconciliacao)modelo;
                    txt_reconciliacao.Text = p.Data_reconciliacao.ToString();
                }
                if (modelo is Membro_ReconciliacaoLgpd)
                {
                    var p = (Membro_ReconciliacaoLgpd)modelo;
                    txt_reconciliacao.Text = p.Data_reconciliacao.ToString();
                }

            }
            
            
        }

        private void txt_reconciliacao_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                if(modelo is Membro_Reconciliacao)
                {
                    var p = (Membro_Reconciliacao)modelo;
                    try
                    {
                        p.Data_reconciliacao = int.Parse(txt_reconciliacao.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                    }
                }
                if (modelo is Membro_ReconciliacaoLgpd)
                {
                    var p = (Membro_ReconciliacaoLgpd)modelo;
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

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Reconciliacao)
                {
                    var p = (Membro_Reconciliacao)ModeloNovo;
                    try
                    {
                        p.Data_reconciliacao = int.Parse(txt_reconciliacao.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                    }
                }
                if (ModeloNovo is Membro_ReconciliacaoLgpd)
                {
                    var p = (Membro_ReconciliacaoLgpd)ModeloNovo;
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
}
