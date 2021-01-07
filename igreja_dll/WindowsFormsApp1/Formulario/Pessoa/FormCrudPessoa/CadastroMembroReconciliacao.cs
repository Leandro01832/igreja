using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroMembroReconciliacao : WindowsFormsApp1.Formulario.FormCrudPessoa
    {

        public CadastroMembroReconciliacao(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroReconciliacao(business.classes.Pessoas.PessoaDado p,
            bool Deletar, bool Atualizar,  bool Detalhes)
            : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void CadastroMembroReconciliacao_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por reconciliação.";
            if(modelo != null)
            if(modelo.Id != 0)
            {
                var p = (business.classes.Pessoas.Membro_Reconciliacao)modelo;
                txt_reconciliacao.Text = p.Data_reconciliacao.ToString();
            }
            
            
        }

        private void txt_reconciliacao_TextChanged(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var p = (business.classes.Pessoas.Membro_Reconciliacao)modelo;
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
                var p = (business.classes.Pessoas.Membro_Reconciliacao)ModeloNovo;
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
