using business.classes;
using igreja2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms.form.cadastro_visitante;

namespace WindowsForms.form.cadastro_membro
{
    public partial class cadastro_celula : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_celula(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string listbox = listBox1.Text;
            Regex reg = new Regex(@"(\d+)");
            string id = reg.Match(listbox).ToString();
            Pessoa pessoa = new Pessoa();
            pessoa = p;
            try
            {
                if(!salvar)
                {
                    pessoa.celula_ = int.Parse(id);
                }
                else
                {
                    pessoa.celula_ = int.Parse(id);
                    button1.Text = "Salvar";
                }
                
            }
            catch (Exception)
            {
                if (!salvar)
                {
                    if(pessoa.Nome != "")
                    {
                        cadastro_foto cad_fot = new cadastro_foto(pessoa, classe_);
                        cad_fot.MdiParent = MDIsingleton.InstanciaMDI();
                        cad_fot.Show();
                        cad_fot.WindowState = FormWindowState.Maximized;
                    }                    
                }
                else
                {
                    button1.Text = "Salvar";
                }
            }

            cadastro_foto cad_foto = new cadastro_foto(p, classe_);
            cad_foto.MdiParent = MDIsingleton.InstanciaMDI();
            cad_foto.Show();
            cad_foto.WindowState = FormWindowState.Maximized;

        }

        private void cadastro_celula_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button1.Text = "cadastrar como membro";
            }
            else
            {
                button1.Text = "salvar";
                listBox1.Text = m.Celula.Cel_nome + " - " + m.Celula.Celulaid;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
