﻿using business.classes;
using business.classes.Abstrato;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
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
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
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
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
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
        }

        private void check_pesquisa_nome_mae_CheckedChanged(object sender, EventArgs e)
        {
            if (check_pesquisa_nome_mae.Checked)
            {
                MessageBox.Show("Digite um nome parecido com o que lembra para ser feito a pesquisa.");
                txt_pesquisa_texto.Enabled = true;
                txt_pesquisa_texto.Focus();
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
            comando = "";
            ModificaDataGridView(modelo, tipo, comando);
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            if (check_horario_final_reuniao.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    comando += modelo.PesquisarPorHorario(v1, v2, "Horario_fim");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_horario_reuniao.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    comando += modelo.PesquisarPorHorario(v1, v2, "Horario_inicio");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_horario_celula.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = TimeSpan.Parse(mask_horario_valor1.Text);
                    var v2 = TimeSpan.Parse(mask_horario_valor2.Text);
                    comando += modelo.PesquisarPorHorario(v1, v2, "Horario");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_nome_mae.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "Nome_mae");
            }

            if (check_pesquisa_nome_pai.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "Nome_pai");
            }

            if (check_pesquisa_email.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "Email");
            }

            if (check_pesquisa_data_reuniao.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    comando += modelo.PesquisarPorData(v1, v2, "Data_reuniao");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_data_visita.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    comando += modelo.PesquisarPorData(v1, v2, "Data_visita");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_data_mudanca_estado.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                try
                {
                    var v1 = Convert.ToDateTime(mask_data_valor1.Text);
                    var v2 = Convert.ToDateTime(mask_data_valor2.Text);
                    comando += modelo.PesquisarPorData(v1, v2, "DataMudanca");
                }
                catch
                {
                    MessageBox.Show("Digite dois valores e o resultado da pesquisa será entre esses dois valores.");
                    return;
                }
            }

            if (check_pesquisa_id.Checked)
            {
                if (VerificaAnd()) comando += " and ";
                string id = retornarStringId();
                try
                {
                    var v1 = int.Parse(txt_pesquisa_numero1.Text);
                    var v2 = int.Parse(txt_pesquisa_numero2.Text);
                    comando += modelo.PesquisarPorNumero(v1, v2, id);
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
                    if (VerificaAnd()) comando += " and ";
                    try
                    {
                        var v1 = int.Parse(txt_pesquisa_numero1.Text);
                        var v2 = int.Parse(txt_pesquisa_numero2.Text);
                        comando += modelo.PesquisarPorNumero(v1, v2, "Databatismo");
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
                    if (VerificaAnd()) comando += " and ";
                    comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "Email");
                }

                if (check_pesquisa_nome.Checked)
                {
                    if (VerificaAnd()) comando += " and ";
                    comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "NomePessoa");
                }
            }

            if (modelo is Celula || modelo is Ministerio)
            {
                if (check_pesquisa_nome.Checked)
                {
                    if (VerificaAnd()) comando += " and ";
                    comando += modelo.PesquisarPorTexto(txt_pesquisa_texto.Text, "Nome");
                }
            }


            ModificaDataGridView(modelo, tipo, comando);
            escreverComando();
        }

        private void escreverComando()
        {
            var tabela = "";

            if (modelo is Pessoa)
            {
                tabela = "Pessoa";

                if (modelo is PessoaDado)
                {
                    if (modelo is Visitante)
                        tabela = "Pessoa";

                    if (modelo is Crianca)
                        tabela = "Crianca";

                    if (modelo is Membro_Aclamacao)
                        tabela = "Membro_Aclamacao";

                    if (modelo is Membro_Batismo)
                        tabela = "Membro_Batismo";

                    if (modelo is Membro_Reconciliacao)
                        tabela = "Membro_Reconciliacao";

                    if (modelo is Membro_Transferencia)
                        tabela = "Membro_Transferencia";
                }

                if (modelo is PessoaLgpd)
                {
                    if (modelo is VisitanteLgpd)
                        tabela = "VisitanteLgpd";

                    if (modelo is CriancaLgpd)
                        tabela = "CriancaLgpd";

                    if (modelo is Membro_AclamacaoLgpd)
                        tabela = "Membro_AclamacaoLgpd";

                    if (modelo is Membro_BatismoLgpd)
                        tabela = "Membro_BatismoLgpd";

                    if (modelo is Membro_ReconciliacaoLgpd)
                        tabela = "Membro_ReconciliacaoLgpd";

                    if (modelo is Membro_TransferenciaLgpd)
                        tabela = "Membro_TransferenciaLgpd";
                }

            }
            if (modelo is Celula)
            {
                tabela = "Celula";

                if (modelo is business.classes.Celulas.Celula_Adolescente)
                    tabela = "Celula_Adolescente";

                if (modelo is business.classes.Celulas.Celula_Adulto)
                    tabela = "Celula_Adulto";

                if (modelo is business.classes.Celulas.Celula_Casado)
                    tabela = "Celula_Casado";

                if (modelo is business.classes.Celulas.Celula_Jovem)
                    tabela = "Celula_Jovem";

                if (modelo is business.classes.Celulas.Celula_Crianca)
                    tabela = "Celula_Crianca";
            }

            if (modelo is Ministerio)
            {
                tabela = "Ministerio";
                if (modelo is Supervisor_Celula)
                    tabela = "Supervisor_Celula";

                if (modelo is Supervisor_Celula_Treinamento)
                    tabela = "Supervisor_Celula_Treinamento";

                if (modelo is Supervisor_Ministerio)
                    tabela = "Supervisor_Ministerio";

                if (modelo is Supervisor_Ministerio_Treinamento)
                    tabela = "Supervisor_Ministerio_Treinamento";

                if (modelo is Lider_Celula)
                    tabela = "Lider_Celula";

                if (modelo is Lider_Celula_Treinamento)
                    tabela = "Lider_Celula_Treinamento";

                if (modelo is Lider_Ministerio)
                    tabela = "Lider_Ministerio";

                if (modelo is Lider_Ministerio_Treinamento)
                    tabela = "Lider_Ministerio_Treinamento";
            }
            if (modelo is Reuniao)
                tabela = "Reuniao";
            if (modelo is Historico)
                tabela = "Historico";
            if (modelo is Chamada)
                tabela = "Chamada";


            txt_comando.Text = $"Selecionado os registros da tabela {tabela}";
            if (comando != "")
                txt_comando.Text += $" onde {comando}";
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
