using business.classes;
using igreja2;
using System;
using System.Windows.Forms;

namespace WindowsForms.form.cadastro_membro
{
    public partial class finalizar_cadastro : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        Crianca c = new Crianca();
        string classe_ = string.Empty;


        public finalizar_cadastro(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            classe_ = classe;
        }

       

        private void finalizar_cadastro_Load(object sender, EventArgs e)
        {

            if (classe_ == "")
            {
                

            }
        }

        private void dadosPessoaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_dados_pessoais cad = new cadastro_dados_pessoais(m, classe_,  true);
            cad.MdiParent = MDIsingleton.InstanciaMDI();
            cad.Show();
            cad.WindowState = FormWindowState.Maximized;
            
        }

        private void telefoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_telefone tel = new cadastro_telefone(m, classe_, true);
            tel.MdiParent = MDIsingleton.InstanciaMDI();
            tel.Show();
            tel.WindowState = FormWindowState.Maximized;
        }

        private void endereçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_endereco end = new cadastro_endereco(m, classe_, true);
            end.MdiParent = MDIsingleton.InstanciaMDI();            
            end.Show();
            end.WindowState = FormWindowState.Maximized;
        }

        private void fotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_foto foto = new cadastro_foto(m, classe_, true);
            foto.MdiParent = MDIsingleton.InstanciaMDI();
            foto.Show();
            foto.WindowState = FormWindowState.Maximized;
        }

        private void celulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_celula cel = new cadastro_celula(m, classe_, true);
            cel.MdiParent = MDIsingleton.InstanciaMDI();
            cel.Show();
            cel.WindowState = FormWindowState.Maximized;
        }

        private void dadosDeClasseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(v.Nome != null)
            {
                v.salvar();
            }

            if(m.Nome != null)
            {
                m.salvar();
            }

            if (c.Nome != null)
            {
                c.salvar();
            }
        }
    }
}
