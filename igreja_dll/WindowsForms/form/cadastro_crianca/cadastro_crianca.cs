using business.classes;
using igreja2;
using System;
using System.Windows.Forms;
using WindowsForms.form.cadastro_membro;

namespace WindowsForms.form.cadastro_crianca
{
    public partial class cadastro_crianca : Form
    {
        Crianca c = new Crianca();
        Pessoa p = new Pessoa();
        string classe_ = string.Empty;

        public cadastro_crianca( Pessoa pessoa, string classe)
        {
            InitializeComponent();
            p = pessoa;
            classe_ = classe;
        }

        private void cadastro_crianca_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Crianca v = new Crianca();
            v.Endereco = p.Endereco;
            v.Telefone = p.Telefone;
            v.Celula = p.Celula;
            v.Nome = p.Nome;
            v.Sexo_feminino = p.Sexo_feminino;
            v.Sexo_masculino = p.Sexo_masculino;
            v.Status = p.Status;
            v.Cpf = p.Cpf;
            v.Rg = p.Rg;
            v.Data_nascimento = p.Data_nascimento;
            v.Email = p.Email;
            v.Estado_civil = p.Estado_civil;
            v.Falescimento = p.Falescimento;
            v.Falta = p.Falta;
            v.Img = p.Img;

            finalizar_cadastro cel = new finalizar_cadastro(v, classe_);
            cel.MdiParent = MDIsingleton.InstanciaMDI();
            cel.Show();
            cel.WindowState = FormWindowState.Maximized;
        }
    }
}
