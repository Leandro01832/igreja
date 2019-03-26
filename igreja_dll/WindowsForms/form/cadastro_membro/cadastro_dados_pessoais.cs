using business.classes;
using igreja2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.form.cadastro_membro
{
    public partial class cadastro_dados_pessoais : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_dados_pessoais(string classe)
        {
            InitializeComponent();
            classe_ = classe;
        }

        public cadastro_dados_pessoais(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Membro membro = new Membro();
            Visitante visitante = new Visitante();

            pessoa = p;
            pessoa.Nome = text_nome.Text;
            pessoa.Sexo_feminino = Convert.ToBoolean(radioButton_feminino.Checked);
            pessoa.Sexo_masculino = Convert.ToBoolean(radioButton_masculino.Checked);
            pessoa.Data_nascimento = Convert.ToDateTime(mask_data_nascimento.Text);
            pessoa.Rg = text_rg.Text.ToString();
            pessoa.Falescimento = false;
            pessoa.Email = textemail.Text;
            pessoa.Cpf = text_cpf.Text;
            pessoa.Falta = 0;            
            pessoa.Estado_civil = listestado_civil.Text.ToString();
            pessoa.Status = listBox_status.Text;
            pessoa.Chamada = new Chamada();
            pessoa.Chamada.Data_inicio = DateTime.Now;

            if (!salvar)
            {
                cadastro_endereco cad_end = new cadastro_endereco(pessoa, classe_);
                cad_end.MdiParent = MDIsingleton.InstanciaMDI();
                cad_end.Show();
                cad_end.WindowState = FormWindowState.Maximized;
            }
            else
            {
                finalizar_cadastro fin_cad = new finalizar_cadastro(pessoa, classe_);
                fin_cad.MdiParent = MDIsingleton.InstanciaMDI();
                fin_cad.Show();
            }
            
        }

        private void cadastro_dados_pessoais_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button1.Text = "cadastrar endereço.";
            }
            else
            {
                button1.Text = "salvar.";
                text_nome.Text = p.Nome;
                text_rg.Text = p.Rg;
                text_cpf.Text = p.Cpf;
                listestado_civil.Text = p.Estado_civil;
                listBox_status.Text = p.Status;
                mask_data_nascimento.Text = p.Data_nascimento.ToString("dd/pp/yyyy");
                textemail.Text = p.Email;
                radioButton_masculino.Checked = p.Sexo_masculino;
                radioButton_feminino.Checked = p.Sexo_feminino;

            }
        }
    }
}
