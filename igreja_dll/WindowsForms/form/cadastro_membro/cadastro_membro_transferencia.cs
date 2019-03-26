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
    public partial class cadastro_membro_transferencia : Form
    {
        Membro m = new Membro();
        string classe_ = string.Empty;
        bool salvar = false;

        public cadastro_membro_transferencia(Membro membro, string classe, bool salve = false)
        {
            InitializeComponent();
            m = membro;
            salvar = salve;
            classe_ = classe;
        }

        private void cadastro_membro_transferencia_Load(object sender, EventArgs e)
        {
            if (!salvar)
            {
                button4.Text = "adicionar foto.";
            }
            else
            {
                button4.Text = "salvar.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Membro_Transferencia membro = new Membro_Transferencia();
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
            membro.Nome_cidade_transferencia = text_cidade.Text;
            membro.Estado_transferencia = text_estado.Text;
            membro.Nome_igreja_transferencia = text_nome_igreja.Text;

            finalizar_cadastro fin_cad = new finalizar_cadastro(membro, classe_);
            fin_cad.MdiParent = MDIsingleton.InstanciaMDI();
            fin_cad.Show();
            fin_cad.WindowState = FormWindowState.Maximized;

        }
    }
}
