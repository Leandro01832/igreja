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
    public partial class cadastro_telefone : Form
    {
        Pessoa p = new Pessoa();
        Membro m = new Membro();
        Visitante v = new Visitante();
        bool salvar = false;
        string classe_ = string.Empty;

        public cadastro_telefone(Pessoa pessoa, string classe, bool salve = false)
        {
            InitializeComponent();
            p = pessoa;
            salvar = salve;
            classe_ = classe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = p;
            pessoa.Telefone = new Telefone();
            pessoa.Telefone.Fone = mask_tel1.Text;
            pessoa.Telefone.Celular = mask_tel2.Text;
            pessoa.Telefone.Whatsapp = mask_tel3.Text;

            if (!salvar)
            {
                cadastro_celula cad_cel = new cadastro_celula(pessoa, classe_);
                cad_cel.MdiParent = MDIsingleton.InstanciaMDI();
                cad_cel.Show();
                cad_cel.WindowState = FormWindowState.Maximized;
            }
            else
            {
                finalizar_cadastro fin_cad = new finalizar_cadastro(pessoa, classe_);
                fin_cad.MdiParent = MDIsingleton.InstanciaMDI();
                fin_cad.Show();
                fin_cad.WindowState = FormWindowState.Maximized;
            }
           
        }

        private void cadastro_telefone_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button1.Text = "cadastrar celula.";
            }
            else
            {
                button1.Text = "salvar";
                mask_tel1.Text = m.Telefone.Fone;
                mask_tel2.Text = m.Telefone.Celular;
                mask_tel3.Text = m.Telefone.Whatsapp;
            }
        }
    }
}
