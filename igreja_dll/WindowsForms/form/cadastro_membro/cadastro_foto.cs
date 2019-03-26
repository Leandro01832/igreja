using business.classes;
using igreja2;
using igreja2.form;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WindowsForms.form.cadastro_membro
{
    public partial class cadastro_foto : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_foto(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }

        private void cadastro_foto_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button2.Text = "cadastrar dados de classe.";
            }
            else
            {
                button2.Text = "salvar.";
            }
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Membro membro = new Membro();
            Visitante visitante = new Visitante();
            Crianca crianca = new Crianca();
            
            pessoa = p;
            MemoryStream memory = new MemoryStream();
            Bitmap btp = new Bitmap(pictureBox1.ImageLocation);
            btp.Save(memory, ImageFormat.Bmp);
            byte[] foto = memory.ToArray();
            pessoa.Img = foto;

            if (classe_ == "Membro")
            {
                membro.Endereco = pessoa.Endereco;
                membro.Telefone = pessoa.Telefone;
                membro.Celula = pessoa.Celula;
                membro.Nome = pessoa.Nome;
                membro.Sexo_feminino = pessoa.Sexo_feminino;
                membro.Sexo_masculino = pessoa.Sexo_masculino;
                membro.Status = pessoa.Status;
                membro.Cpf = pessoa.Cpf;
                membro.Rg = pessoa.Rg;
                membro.Data_nascimento = p.Data_nascimento;
                membro.Email = pessoa.Email;
                membro.Estado_civil = pessoa.Estado_civil;
                membro.Falescimento = pessoa.Falescimento;
                membro.Falta = pessoa.Falta;
                membro.Img = pessoa.Img;
                

                cadastro_membro cadastro = new cadastro_membro(membro);
                cadastro.MdiParent = MDIsingleton.InstanciaMDI();
                cadastro.Show();
                cadastro.WindowState = FormWindowState.Maximized;
            }
            else if (classe_ == "Visitante")
            {
                visitante.Endereco = pessoa.Endereco;
                visitante.Telefone = pessoa.Telefone;
                visitante.Celula = pessoa.Celula;
                visitante.Nome = pessoa.Nome;
                visitante.Sexo_feminino = pessoa.Sexo_feminino;
                visitante.Sexo_masculino = pessoa.Sexo_masculino;
                visitante.Status = pessoa.Status;
                visitante.Cpf = pessoa.Cpf;
                visitante.Rg = pessoa.Rg;
                visitante.Data_nascimento = p.Data_nascimento;
                visitante.Email = pessoa.Email;
                visitante.Estado_civil = pessoa.Estado_civil;
                visitante.Falescimento = pessoa.Falescimento;
                visitante.Falta = pessoa.Falta;
                visitante.Img = pessoa.Img;

                cadastro_visitante.cadastro_visitante cadastro_visi = new cadastro_visitante.cadastro_visitante(visitante, classe_);
                cadastro_visi.MdiParent = MDIsingleton.InstanciaMDI();
                cadastro_visi.Show();
                cadastro_visi.WindowState = FormWindowState.Maximized;
            }
            else
            {
                crianca.Endereco = pessoa.Endereco;
                crianca.Telefone = pessoa.Telefone;
                crianca.Celula = pessoa.Celula;
                crianca.Nome = pessoa.Nome;
                crianca.Sexo_feminino = pessoa.Sexo_feminino;
                crianca.Sexo_masculino = pessoa.Sexo_masculino;
                crianca.Status = pessoa.Status;
                crianca.Cpf = pessoa.Cpf;
                crianca.Rg = pessoa.Rg;
                crianca.Data_nascimento = p.Data_nascimento;
                crianca.Email = pessoa.Email;
                crianca.Estado_civil = pessoa.Estado_civil;
                crianca.Falescimento = pessoa.Falescimento;
                crianca.Falta = pessoa.Falta;
                crianca.Img = pessoa.Img;

                cadastro_crianca.cadastro_crianca cadastro_cri = new cadastro_crianca.cadastro_crianca(crianca, classe_);
                cadastro_cri.MdiParent = MDIsingleton.InstanciaMDI();
                cadastro_cri.Show();
                cadastro_cri.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pes = new Pessoa();
            pes.foto(pictureBox1);
            Visualizar_foto visu = new Visualizar_foto(pictureBox1);
            visu.Show();
        }
    }
}
