using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class CadastroMembroBatismo :  WFCrud
    {


        public CadastroMembroBatismo()  : base()
        {
            InitializeComponent();
        }        

        private void CadastroMembroBatismo_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por batismo.";
            
                if (modelo is Membro_Batismo)
                {
                    var p = (Membro_Batismo)modelo;
                try { txt_ano.Text = p.Data_batismo.ToString(); }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is Membro_BatismoLgpd)
                {
                    var p = (Membro_BatismoLgpd)modelo;
                try { txt_ano.Text = p.Data_batismo.ToString(); }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }

            
        }

        private void txt_ano_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Batismo)
                {
                    var p = (Membro_Batismo)modelo;
                    try
                    {
                        p.Data_batismo = int.Parse(txt_ano.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                    }
                }
                if (modelo is Membro_BatismoLgpd)
                {
                    var p = (Membro_BatismoLgpd)modelo;
                    try
                    {
                        p.Data_batismo = int.Parse(txt_ano.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                    }
                }

            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Batismo)
                {
                    var p = (Membro_Batismo)ModeloNovo;
                    try
                    {
                        p.Data_batismo = int.Parse(txt_ano.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Informe apenas o ano. (4 digitos.)");
                    }
                }
                if (ModeloNovo is Membro_BatismoLgpd)
                {
                    var p = (Membro_BatismoLgpd)ModeloNovo;
                    try
                    {
                        p.Data_batismo = int.Parse(txt_ano.Text);
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
