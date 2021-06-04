using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class CadastroMembroBatismo :  Formulario.FormCrudPessoa
    {

        public CadastroMembroBatismo(modelocrud modelo, modelocrud modeloNovo)
            :base(modelo, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroBatismo(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho,
            modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        public CadastroMembroBatismo(modelocrud p, bool Atualizar, bool Deletar, bool Detalhes)            
            : base(p, Atualizar, Deletar, Detalhes)
        {
            InitializeComponent();
        }
        

        private void CadastroMembroBatismo_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por batismo.";

            if (modelo != null)
            {
                if (modelo is Membro_Batismo)
                {
                    var p = (Membro_Batismo)modelo;
                    txt_ano.Text = p.Data_batismo.ToString();
                }
                if (modelo is Membro_BatismoLgpd)
                {
                    var p = (Membro_BatismoLgpd)modelo;
                    txt_ano.Text = p.Data_batismo.ToString();
                }

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
