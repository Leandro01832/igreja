using igreja2.form.atualização;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using business.classes;
using System.Data.SqlClient;
using database.banco;
using igreja2.form.teste;
using WindowsForms.form.cadastro_membro;
using WindowsForms.form.cadastro_visitante;

//using MySql.Data.MySqlClient;

namespace igreja2.form
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        DateTime atual = DateTime.Now;
        string mesniver;

        private void menbroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro_dados_pessoais frm = new cadastro_dados_pessoais("Membro");
            frm.MdiParent = MDIsingleton.InstanciaMDI();
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            Chamada cha = new Chamada();
           // cha.recuperar();

            Pessoa pes = new Pessoa();
            BDcomum bd = new BDcomum();
            SqlCommand verifica = new SqlCommand("select * from Pessoa as P inner join Telefone as T on P.Id=T.telefoneid " +
                " inner join Endereco as E on P.Id=E.EnderecoId order by P.Data_nascimento asc", bd.obterconexao());
            try
            {
               SqlDataReader rd = verifica.ExecuteReader();
                                
                if (rd.HasRows == true)
                {                   
                    while (rd.Read())
                    {

                        // progressBar1.Value += 1;
                        var data = Convert.ToDateTime(rd["Data_nascimento"]);
                        var dia = data.ToString(data.Year + "-MM-dd");
                        if (Convert.ToDateTime(dia) > DateTime.Now && Convert.ToDateTime(dia) < DateTime.Now.AddDays(7))
                        {
                            label2.Text = Convert.ToString(rd["Nome"]);
                            label1.Text = Convert.ToString(rd["Data_nascimento"]);
                            label4.Text = Convert.ToString(rd["Fone"]);
                            label5.Text = Convert.ToString(rd["Celular"]);
                            label6.Text = Convert.ToString(rd["Whatsapp"]);
                            label7.Text = Convert.ToString(rd["Cep"]);
                            label8.Text = Convert.ToString(rd["Rua"]);
                            label9.Text = Convert.ToString(rd["Bairro"]);
                            label10.Text = Convert.ToString(rd["Numero_casa"]);
                            mesniver = label1.Text;
                        }                      
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            finally
            {
                MessageBox.Show("nimguem mais esta fazendo aniversário.");
                bd.obterconexao().Close();
                label1.Text = null;
                label2.Text = null;
                label4.Text = null;
                label5.Text = null;
                label6.Text = null;
                label7.Text = null;
                label8.Text = null;
                label9.Text = null;
                label10.Text = null;
                label11.Text = null;
                label12.Text = null;
                label13.Text = null;
                label14.Text = null;
                label15.Text = null;
                label16.Text = null;
                label17.Text = null;
                label18.Text = null;
                label19.Text = null;
                label20.Text = null;
                label21.Text = null;

            }

        }

        private void visitantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cadastro_dados_pessoais visi = new cadastro_dados_pessoais("Visitante");
            visi.MdiParent = MDIsingleton.InstanciaMDI();
            visi.Show();
            visi.WindowState = FormWindowState.Maximized;
        }

        private void criançasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cadastro_dados_pessoais crianca = new cadastro_dados_pessoais("Crianca");
            crianca.MdiParent = MDIsingleton.InstanciaMDI();
            crianca.Show();
            crianca.WindowState = FormWindowState.Maximized;
        }

        

        private void menbroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dados_membro mem = new dados_membro();
            mem.MdiParent = MDIsingleton.InstanciaMDI();
            mem.Show();
        }

        private void visitantesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dados_visitante visi = new dados_visitante();
            visi.MdiParent = MDIsingleton.InstanciaMDI();
            visi.Show();
        }

        private void criançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dados_crianca cri = new dados_crianca();
            cri.MdiParent = MDIsingleton.InstanciaMDI();
            cri.Show();
        }

        private void visõesDePessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizacao visu = new visualizacao();
            visu.MdiParent = MDIsingleton.InstanciaMDI();
            visu.Show();
        }

        private void relatorioDeMenbrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rel_membro rel = new rel_membro();
            //rel.MdiParent = MDIsingleton.InstanciaMDI();
            //rel.Show();
        }

        private void relatórioDeMenbrosPorTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rel_membro_transferencia rel = new rel_membro_transferencia();
            //rel.MdiParent = MDIsingleton.InstanciaMDI();
            //rel.Show();
        }

        private void relatórioDeMenbrosPorAclamaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rel_membro_reconciliacao rel = new rel_membro_reconciliacao();
            //rel.MdiParent = MDIsingleton.InstanciaMDI();
            //rel.Show();
        }

        private void relatórioDeMenbrosPorAclamaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //rel_membro_aclamacao rel = new rel_membro_aclamacao();
            //rel.MdiParent = MDIsingleton.InstanciaMDI();
            //rel.Show();
        }

        private void relatórioDeVisitantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rel_visitante visi = new rel_visitante();
            //visi.MdiParent = MDIsingleton.InstanciaMDI();
            //visi.Show();
        }

        private void relatórioDeMenbrosPorBatismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // rel_membro_batismo rel = new rel_membro_batismo();
            //rel.MdiParent = MDIsingleton.InstanciaMDI();
            //rel.Show();
        }

        private void celulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            atualizacao_celula cel = new atualizacao_celula();
            cel.MdiParent = MDIsingleton.InstanciaMDI();
            cel.Show();
        }

        private void teste1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teste1 test = new teste1();
            test.Show();
        }

        private void históricoDeChamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ministérioToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void supervisorToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // mysql mysql = new mysql();
           // MySqlConnection conexao = mysql.conectar();
            
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
