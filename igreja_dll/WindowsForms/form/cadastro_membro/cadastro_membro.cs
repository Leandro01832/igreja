using business.classes;
using igreja2;
using System;
using System.Windows.Forms;

namespace WindowsForms.form.cadastro_membro
{
    public partial class cadastro_membro : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_membro(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }

        public cadastro_membro(Membro membro)
        {
            InitializeComponent();
            m = membro;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Text = "Cadastrar como membro por batismo.";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button1.Text = "cadastrar como membro por reconciliação.";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                button1.Text = "cadastrar como membro por transferência.";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                button1.Text = "cadastrar como membro por aclamação.";
            }
        }

        private void cadastro_membro_Load(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button1.Text = "Cadastrar como membro por batismo.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Membro membro = new Membro();
            membro.Endereco = p.Endereco;
            membro.Telefone = p.Telefone;
            membro.Celula = p.Celula;
            membro.Nome = p.Nome;
            membro.Cpf = p.Cpf;
            membro.Rg = p.Rg;
            membro.Sexo_feminino = p.Sexo_feminino;
            membro.Sexo_masculino = p.Sexo_masculino;
            membro.Status = p.Status;
            membro.Img = p.Img;
            membro.Data_nascimento = p.Data_nascimento;

            if (button1.Text == "Cadastrar como membro por batismo.")
            {
                try
                {
                    membro.Data_batismo = int.Parse(mask_ano_batismo.Text);
                    cadastro_membro_batismo cad_mem = new cadastro_membro_batismo(membro, classe_);
                    cad_mem.MdiParent = MDIsingleton.InstanciaMDI();
                    cad_mem.Show();
                    cad_mem.WindowState = FormWindowState.Maximized;
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe o ano de batismo.");
                }
            }
            else if (button1.Text == "cadastrar como membro por reconciliação.")
            {
                try
                {
                    membro.Data_batismo = int.Parse(mask_ano_batismo.Text);
                    cadastro_membro_reconciliacao cad_mem = new cadastro_membro_reconciliacao(membro, classe_);
                    cad_mem.MdiParent = MDIsingleton.InstanciaMDI();
                    cad_mem.Show();
                    cad_mem.WindowState = FormWindowState.Maximized;
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe o ano de batismo.");
                }
            }
            else if (button1.Text == "cadastrar como membro por transferência.")
            {
                try
                {
                    membro.Data_batismo = int.Parse(mask_ano_batismo.Text);
                    cadastro_membro_transferencia cad_mem = new cadastro_membro_transferencia(membro, classe_);
                    cad_mem.MdiParent = MDIsingleton.InstanciaMDI();
                    cad_mem.Show();
                    cad_mem.WindowState = FormWindowState.Maximized;
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe o ano de batismo.");
                }
            }
            else
            {
                try
                {
                    membro.Data_batismo = int.Parse(mask_ano_batismo.Text);
                    cadasdro_membro_aclamacao cad_mem = new cadasdro_membro_aclamacao(membro, classe_);
                    cad_mem.MdiParent = MDIsingleton.InstanciaMDI();
                    cad_mem.Show();
                    cad_mem.WindowState = FormWindowState.Maximized;
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe o ano de batismo");
                }
            }
        }
    }
}
