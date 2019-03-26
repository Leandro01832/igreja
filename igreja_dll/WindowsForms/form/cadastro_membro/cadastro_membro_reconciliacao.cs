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
    public partial class cadastro_membro_reconciliacao : Form
    {
        Membro m = new Membro();
        string classe_ = string.Empty;
        bool salvar = false;

        public cadastro_membro_reconciliacao(Membro membro, string classe, bool salve = false)
        {
            InitializeComponent();
            m = membro;
            salvar = salve;
            classe_ = classe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Membro_Reconciliacao membro = new Membro_Reconciliacao();
            membro.Endereco = m.Endereco;
            membro.Telefone = m.Telefone;
            membro.Nome = m.Nome;
            membro.Img = m.Img;
            membro.Estado_civil = m.Estado_civil;
            membro.Email = m.Email;
            membro.Cpf = m.Cpf;
            membro.Rg = m.Rg;
            membro.Sexo_feminino = m.Sexo_feminino;
            membro.Sexo_masculino = m.Sexo_masculino;
            membro.celula_ = m.celula_;
            membro.classe = m.classe;
            membro.Data_nascimento = m.Data_nascimento;
            membro.Falescimento = false;
            membro.Falta = 0;
            membro.imgtipo = m.imgtipo;
            membro.Data_batismo = m.Data_batismo;
            membro.Data_reconciliacao = int.Parse(text_reconciliacao.Text);

            finalizar_cadastro fin_cad = new finalizar_cadastro(membro, classe_);
            fin_cad.MdiParent = MDIsingleton.InstanciaMDI();
            fin_cad.Show();
            fin_cad.WindowState = FormWindowState.Maximized;
        }

        private void cadastro_membro_reconciliacao_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button1.Text = "adicionar foto";
            }
            else
            {
                button1.Text = "salvar.";
            }
        }
    }
}
