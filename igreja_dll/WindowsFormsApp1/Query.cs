using business.classes;
using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   public partial class Pesquisar
    {

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Visitante")
            {
                modelo = new business.classes.Pessoas.Visitante();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Criança")
            {
                modelo = new business.classes.Pessoas.Crianca();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Membro por aclamação")
            {
                modelo = new business.classes.Pessoas.Membro_Aclamacao();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Membro por batismo")
            {
                modelo = new business.classes.Pessoas.Membro_Batismo();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Membro por reconciliação")
            {
                modelo = new business.classes.Pessoas.Membro_Reconciliacao();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Membro por trandferência")
            {
                modelo = new business.classes.Pessoas.Membro_Transferencia();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Lider de celula")
            {
                modelo = new business.classes.Ministerio.Lider_Celula();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Lider em treinamento de celula")
            {
                modelo = new business.classes.Ministerio.Lider_Celula_Treinamento();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Lider de ministério")
            {
                modelo = new business.classes.Ministerio.Lider_Ministerio();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Lider em treinamento de ministério")
            {
                modelo = new business.classes.Ministerio.Lider_Ministerio_Treinamento();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Supervisor de celula")
            {
                modelo = new business.classes.Ministerio.Supervisor_Celula();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Supervisor em treinamento de celula")
            {
                modelo = new business.classes.Ministerio.Supervisor_Celula_Treinamento();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Supervisor de ministério")
            {
                modelo = new business.classes.Ministerio.Supervisor_Ministerio();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Supervisor em treinamento de ministério")
            {
                modelo = new business.classes.Ministerio.Supervisor_Ministerio_Treinamento();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Celula para adolescentes")
            {
                modelo = new business.classes.Celulas.Celula_Adolescente();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Celula para adultos")
            {
                modelo = new business.classes.Celulas.Celula_Adulto();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Celula para jovens")
            {
                modelo = new business.classes.Celulas.Celula_Jovem();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Celula para crianças")
            {
                modelo = new business.classes.Celulas.Celula_Crianca();
                ModificaDataGridView(modelo, tipo, comando);
            }

            if (comboBox1.Text == "Celula para casados")
            {
                modelo = new business.classes.Celulas.Celula_Casado();
                ModificaDataGridView(modelo, tipo, comando);
            }
        }

        private void check_pesquisa_ano_batismo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_ano_batismo.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                txt_pesquisa_ano_batismo_valor1.Enabled = true;
                txt_pesquisa_ano_batismo_valor2.Enabled = true;
                txt_pesquisa_ano_batismo_valor1.Focus();
            }
        }

        private void txt_pesquisa_ano_batismo_valor1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var v = int.Parse(txt_pesquisa_ano_batismo_valor1.Text);
                var v2 = int.Parse(txt_pesquisa_ano_batismo_valor2.Text);
            }
            catch
            {
                MessageBox.Show("Informe o ano de batismo com quatro digitos.");
                txt_pesquisa_ano_batismo_valor1.Text = "";
                txt_pesquisa_ano_batismo_valor2.Text = "";
            }
        }

        private void txt_pesquisa_ano_batismo_valor2_TextChanged(object sender, EventArgs e)
        {
            if (VerificaAnd()) comando += " and ";
            try
            {
                var v = int.Parse(txt_pesquisa_ano_batismo_valor1.Text);
                var v2 = int.Parse(txt_pesquisa_ano_batismo_valor2.Text);
            }
            catch
            {
                MessageBox.Show("Informe o ano de batismo com quatro digitos.");
                txt_pesquisa_ano_batismo_valor1.Text = "";
                txt_pesquisa_ano_batismo_valor2.Text = "";
            }
        }

        private void check_pesquisa_nome_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito pesquisa.");
                txt_pesquisa_nome.Enabled = true;
                txt_pesquisa_nome.Focus();
            }
        }

        private void txt_pesquisa_nome_TextChanged(object sender, EventArgs e)
        {
        }

        private void check_pesquisa_data_visita_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_data_visita.Checked)
            {

            }
        }

        private void check_pesquisa_data_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_data_reuniao.Checked)
            {

            }
        }

        private void check_pesquisa_email_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_email.Checked)
            {
                MessageBox.Show("Digite um email parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_email.Enabled = true;                
                txt_pesquisa_email.Focus();
            }
        }

        private void txt_pesquisa_email_TextChanged(object sender, EventArgs e) { }
        private void txt_pesquisa_email_Leave(object sender, EventArgs e)
        {
            if (VerificaAnd()) comando += " and ";
            comando += modelo.PesquisarPorTexto(txt_pesquisa_email.Text, "Email");
        }

        private void check_pesquisa_nome_pai_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_pai.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_nome_pai.Enabled = true;
                txt_pesquisa_nome_pai.Focus();
            }
        }

        private void txt_pesquisa_nome_pai_TextChanged(object sender, EventArgs e) { }
        private void txt_pesquisa_nome_pai_Leave(object sender, EventArgs e)
        {
            if (VerificaAnd()) comando += " and ";
            comando += modelo.PesquisarPorTexto(txt_pesquisa_nome_pai.Text, "Nome_pai");
        }

        private void check_pesquisa_nome_mae_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_mae.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_nome_mae.Enabled = true;
                if (VerificaAnd()) comando += " and ";
                txt_pesquisa_nome_mae.Focus();
            }
        }

        private void txt_pesquisa_nome_mae_TextChanged(object sender, EventArgs e) { }
        private void txt_pesquisa_nome_mae_Leave(object sender, EventArgs e)
        {
            if (VerificaAnd()) comando += " and ";
            comando += modelo.PesquisarPorTexto(txt_pesquisa_nome_pai.Text, "Nome_mae");
        }


        private void check_pesquisa_id_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_id.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                txt_pesquisa_id_valor1.Enabled = true;
                txt_pesquisa_id_valor2.Enabled = true;
                txt_pesquisa_id_valor1.Focus();
            }
        }

        private void txt_pesquisa_id_valor1_TextChanged(object sender, EventArgs e) { }       

        private void txt_pesquisa_id_valor2_TextChanged(object sender, EventArgs e) { }

        private void txt_pesquisa_id_valor2_Leave(object sender, EventArgs e)
        {
            if (VerificaAnd()) comando += " and ";
            try
            {
                var v = int.Parse(txt_pesquisa_id_valor1.Text);
                var v2 = int.Parse(txt_pesquisa_id_valor2.Text);
                string id = retornarStringId();

                comando += modelo.PesquisarPorNumero(v, v2, id);
            }
            catch
            {
                MessageBox.Show("Informe um numero de identificação");
                txt_pesquisa_id_valor1.Text = "";
                txt_pesquisa_id_valor2.Text = "";
            }
        }

        

        private void btn_todos_Click(object sender, EventArgs e)
        {
            comando = "";
            ModificaDataGridView(modelo, tipo, comando);
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            if (check_pesquisa_id.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                string id = retornarStringId();
                var v1 = int.Parse(txt_pesquisa_id_valor1.Text);
                var v2 = int.Parse(txt_pesquisa_id_valor2.Text);
                comando += modelo.PesquisarPorNumero(v1, v2, id);
            }

            if (modelo is Membro)
            {
                if (check_pesquisa_ano_batismo.Checked)
                {
                    if (VerificaAnd()) comando += " and ";
                    var v1 = int.Parse(txt_pesquisa_ano_batismo_valor1.Text);
                    var v2 = int.Parse(txt_pesquisa_ano_batismo_valor2.Text);
                    comando += modelo.PesquisarPorNumero(v1, v2, "Databatismo");
                }
            }

            if (modelo is Pessoa)
            {
                if (check_pesquisa_email.Checked)
                {
                    if (VerificaAnd()) comando += " and ";
                    comando += modelo.PesquisarPorTexto(txt_pesquisa_email.Text, "Email");
                }
            }

            if (modelo is Celula || modelo is Ministerio)
            {
                if (check_pesquisa_nome.Checked)
                {
                    if (VerificaAnd()) comando += " and ";
                    comando += $" Nome like {txt_pesquisa_nome.Text} ";
                }
            }


            ModificaDataGridView(modelo, tipo, comando);
        }

        private string retornarStringId()
        {
            string id = "";
            if (modelo is Pessoa)
                id = "IdPessoa";
            if (modelo is Celula)
                id = "IdCelula";
            if (modelo is Ministerio)
                id = "IdMinisterio";
            if (modelo is Reuniao)
                id = "IdReuniao";
            if (modelo is Historico)
                id = "IdHistorico";
            if (modelo is Chamada)
                id = "IdChamada";
            return id;
        }

        private bool VerificaAnd()
        {
            if (comando != "" && !comando[comando.Length - 1].Equals(" ")
                && !comando[comando.Length - 2].Equals("d") && !comando[comando.Length - 3].Equals("n")
                && !comando[comando.Length - 4].Equals("a"))
                return true;

            else return false;
        }
    }
}
