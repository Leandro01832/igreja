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
        }

        private void check_pesquisa_nome_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito pesquisa.");
                txt_numeros_restricao.Enabled = true;
                txt_numeros_restricao.Focus();
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
        }

        private void check_pesquisa_data_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_data_reuniao.Checked)
            {
                MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                mask_data_valor1.Enabled = true;
                mask_data_valor2.Enabled = true;
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
        }

        private void check_pesquisa_email_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_email.Checked)
            {
                MessageBox.Show("Digite um email parecido com o que lembra para ser feito a pesquisa.");
                txt_numeros_restricao.Enabled = true;
                txt_numeros_restricao.Focus();
            }
        }

        private void check_pesquisa_nome_pai_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_pai.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_numeros_restricao.Enabled = true;
                txt_numeros_restricao.Focus();
            }
        }

        private void check_pesquisa_nome_mae_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_mae.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_numeros_restricao.Enabled = true;
                txt_numeros_restricao.Focus();
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
        }

        private void check_horario_celula_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
            mask_horario_valor1.Enabled = true;
            mask_horario_valor2.Enabled = true;
            mask_horario_valor1.Focus();
        }

        private void check_horario_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
            mask_horario_valor1.Enabled = true;
            mask_horario_valor2.Enabled = true;
            mask_horario_valor1.Focus();
        }

        private void check_horario_final_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
            mask_horario_valor1.Enabled = true;
            mask_horario_valor2.Enabled = true;
            mask_horario_valor1.Focus();
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            List<modelocrud> lista = new List<modelocrud>();
            if (modelo is MudancaEstado)
                lista.AddRange(listaMudancaEstado);
            if (modelo is Ministerio)
                lista.AddRange(listaMinisterios);
            if (modelo is Celula)
                lista.AddRange(listaCelulas);
            if (modelo is Pessoa)
                lista.AddRange(listaPessoas);
            if (modelo is Reuniao)
                lista.AddRange(listaReuniao);
            ModificaDataGridView(modelo, tipo, lista);
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            ModificaDataGridView(modelo, tipo, Resultado);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (check_horario_final_reuniao.Checked)
            {
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    Resultado = modelo.PesquisarPorHorario(Resultado, v2, "Horario_fim");
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
                    Resultado = modelo.PesquisarPorHorario(Resultado, v1, v2, "Horario_inicio");
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
                    Resultado = modelo.PesquisarPorHorario(Resultado,v1, v2, "Horario");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_nome_mae.Checked)
            {
                Resultado = modelo.PesquisarPorTexto(Resultado,txt_numeros_restricao.Text, "Nome_mae");
            }

            if (check_pesquisa_nome_pai.Checked)
            {
                Resultado= modelo.PesquisarPorTexto(Resultado, txt_numeros_restricao.Text, "Nome_pai");
            }

            if (check_pesquisa_email.Checked)
            {
                Resultado= modelo.PesquisarPorTexto(Resultado, txt_numeros_restricao.Text, "Email");
            }

            if (check_pesquisa_data_reuniao.Checked)
            {
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    Resultado = modelo.PesquisarPorData(Resultado, v1, v2, "Data_reuniao");
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
                    Resultado = modelo.PesquisarPorData(Resultado, v1, v2, "Data_visita");
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
                    Resultado = modelo.PesquisarPorData(Resultado, v1, v2, "DataMudanca");
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
                    Resultado = modelo.PesquisarPorNumero(Resultado, v1, v2, id);
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (modelo is Membro)
            {
                if (check_pesquisa_ano_batismo.Checked)
                {
                    try
                    {
                        var v1 = int.Parse(txt_pesquisa_numero1.Text);
                        var v2 = int.Parse(txt_pesquisa_numero2.Text);
                        Resultado = modelo.PesquisarPorNumero(Resultado, v1, v2, "Databatismo");
                    }
                    catch
                    {
                        MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                        return;
                    }
                }
            }

            if (modelo is Pessoa)
            {
                if (check_pesquisa_email.Checked)
                {
                    Resultado = modelo.PesquisarPorTexto(Resultado, txt_numeros_restricao.Text, "Email");
                }

                if (check_pesquisa_nome.Checked)
                {
                    Resultado = modelo.PesquisarPorTexto(Resultado, txt_numeros_restricao.Text, "NomePessoa");
                }
            }

            if (modelo is Celula || modelo is Ministerio)
            {
                if (check_pesquisa_nome.Checked)
                {
                    Resultado = modelo.PesquisarPorTexto(Resultado, txt_numeros_restricao.Text, "Nome");
                }
            }
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
        
    }
}
