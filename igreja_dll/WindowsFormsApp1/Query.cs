using business.classes;
using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Pesquisar
    {

        private void check_pesquisa_ano_batismo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_ano_batismo.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                txt_pesquisa_numero1.Enabled = true;
                txt_pesquisa_numero2.Enabled = true;
                txt_pesquisa_numero1.Focus();
            }
            else
            {
                txt_pesquisa_numero1.Text = "";
                txt_pesquisa_numero2.Text = "";
                txt_pesquisa_numero1.Enabled = false;
                txt_pesquisa_numero2.Enabled = false;
            }
        }

        private void check_pesquisa_nome_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito pesquisa.");
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
            }
            else
            {
                txt_pesquisa_texto.Enabled = false;
                txt_pesquisa_texto.Text = "";
            }
        }

        private void check_pesquisa_data_visita_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_data_visita.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_data_valor1.Enabled = true;
                mask_data_valor2.Enabled = true;
            }
            else
            {
                mask_data_valor1.Enabled = false;
                mask_data_valor2.Enabled = false;
                mask_data_valor1.Text = "";
                mask_data_valor2.Text = "";
            }
        }

        private void check_pesquisa_data_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_data_reuniao.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_data_valor1.Enabled = true;
                mask_data_valor2.Enabled = true;
            }
            else
            {
                mask_data_valor1.Enabled = false;
                mask_data_valor2.Enabled = false;
                mask_data_valor1.Text = "";
                mask_data_valor2.Text = "";
            }
        }

        private void check_data_mudanca_estado_CheckedChanged(object sender, EventArgs e)
        {
            if (check_data_mudanca_estado.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_data_valor1.Enabled = true;
                mask_data_valor2.Enabled = true;
            }
            else
            {
                mask_data_valor1.Enabled = false;
                mask_data_valor2.Enabled = false;
                mask_data_valor1.Text = "";
                mask_data_valor2.Text = "";
            }
        }

        private void check_pesquisa_email_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_email.Checked)
            {
                MessageBox.Show("Digite um email parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
            }
            else
            {
                txt_pesquisa_texto.Enabled = false;
                txt_pesquisa_texto.Text = "";
            }
        }

        private void check_pesquisa_nome_pai_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_pai.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
            }
            else
            {
                txt_pesquisa_texto.Enabled = false;
                txt_pesquisa_texto.Text = "";
            }
        }

        private void check_pesquisa_nome_mae_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_mae.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
            }
            else
            {
                txt_pesquisa_texto.Enabled = false;
                txt_pesquisa_texto.Text = "";
            }
        }

        private void check_pesquisa_id_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_id.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                txt_pesquisa_numero1.Enabled = true;
                txt_pesquisa_numero2.Enabled = true;
                txt_pesquisa_numero1.Focus();
            }
            else
            {
                txt_pesquisa_numero1.Text = "";
                txt_pesquisa_numero2.Text = "";
                txt_pesquisa_numero1.Enabled = false;
                txt_pesquisa_numero2.Enabled = false;
            }
        }

        private void check_horario_celula_CheckedChanged(object sender, EventArgs e)
        {
            if (check_horario_celula.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_horario_valor1.Enabled = true;
                mask_horario_valor2.Enabled = true;
                mask_horario_valor1.Focus(); 
            }
            else
            {
                mask_horario_valor1.Text = "";
                mask_horario_valor2.Text = "";
                mask_horario_valor1.Enabled = false;
                mask_horario_valor2.Enabled = false;
            }
        }

        private void check_horario_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_horario_reuniao.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_horario_valor1.Enabled = true;
                mask_horario_valor2.Enabled = true;
                mask_horario_valor1.Focus(); 
            }
            else
            {
                mask_horario_valor1.Text = "";
                mask_horario_valor2.Text = "";
                mask_horario_valor1.Enabled = false;
                mask_horario_valor2.Enabled = false;
            }
        }

        private void check_horario_final_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_horario_final_reuniao.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_horario_valor1.Enabled = true;
                mask_horario_valor2.Enabled = true;
                mask_horario_valor1.Focus(); 
            }
            else
            {
                mask_horario_valor1.Text = "";
                mask_horario_valor2.Text = "";
                mask_horario_valor1.Enabled = false;
                mask_horario_valor2.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check_horario_final_reuniao.Checked)
            {
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorHorario(Resultado, v2, "Horario_fim");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_horario_reuniao.Checked)
            {
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorHorario(Resultado, v1, v2, "Horario_inicio");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_horario_celula.Checked)
            {
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorHorario(Resultado,v1, v2, "Horario");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_nome_mae.Checked)
            {
                Resultado = Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "Nome_mae");
            }

            if (check_pesquisa_nome_pai.Checked)
            {
                Resultado= Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "Nome_pai");
            }

            if (check_pesquisa_email.Checked)
            {
                Resultado= Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "Email");
            }

            if (check_pesquisa_data_reuniao.Checked)
            {
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorData(Resultado, v1, v2, "Data_reuniao");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_data_visita.Checked)
            {
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorData(Resultado, v1, v2, "Data_visita");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_data_mudanca_estado.Checked)
            {
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    Resultado = Resultado[0].PesquisarPorData(Resultado, v1, v2, "DataMudanca");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_id.Checked)
            {
                string id = retornarStringId();
                try
                {
                    var v1 = int.Parse(txt_pesquisa_numero1.Text);
                    var v2 = int.Parse(txt_pesquisa_numero2.Text);
                    Resultado = Resultado[0].PesquisarPorNumero(Resultado, v1, v2, id);
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (tipo == typeof(Membro))
            {
                if (check_pesquisa_ano_batismo.Checked)
                {
                    try
                    {
                        var v1 = int.Parse(txt_pesquisa_numero1.Text);
                        var v2 = int.Parse(txt_pesquisa_numero2.Text);
                        Resultado = Resultado[0].PesquisarPorNumero(Resultado, v1, v2, "Databatismo");
                    }
                    catch
                    {
                        MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                        return;
                    }
                }
            }

            if (tipo == typeof(Pessoa))
            {
                if (check_pesquisa_email.Checked)
                {
                    Resultado = Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "Email");
                }

                if (check_pesquisa_nome.Checked)
                {
                    Resultado = Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "NomePessoa");
                }
            }

            if (tipo == typeof(Celula) || tipo == typeof(Ministerio))
            {
                if (check_pesquisa_nome.Checked)
                {
                    Resultado = Resultado[0].PesquisarPorTexto(Resultado, txt_pesquisa_texto.Text, "Nome");
                }
            }
        }

        private string retornarStringId()
        {
            string id = "";
            if (Resultado[0] is Pessoa)
                id = "IdPessoa";
            if (Resultado[0] is Celula)
                id = "IdCelula";
            if (Resultado[0] is Ministerio)
                id = "IdMinisterio";
            if (Resultado[0] is Reuniao)
                id = "IdReuniao";
            if (Resultado[0] is MudancaEstado)
                id = "IdMudanca";
            return id;
        }
        
    }
}
