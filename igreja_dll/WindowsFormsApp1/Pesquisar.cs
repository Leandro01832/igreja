using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    

    public partial class Pesquisar : Form
    {
        public Pesquisar()
        {
            pesquisa = new WindowsFormsApp1.DdataGridViews.Pesquisar();
            modelo = null;
            
            InitializeComponent();
        }

       WindowsFormsApp1.DdataGridViews.Pesquisar pesquisa;
        modelocrud modelo;
        string comando = "";
        string tipo = "";

        private void radio_pessoa_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(true, false, false, false, false, false);
            if (radio_pessoa.Checked)
                MessageBox.Show("Você esta vendo informações de pessoa.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (business.classes.Abstrato.Pessoa)item;
                dgdados.Rows.Add(dado.Id, dado.Email, dado.celula_, dado.Falta, dado.Img);
            }   
        }

        private void radio_ministerio_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(false, true, false, false, false, false);
            if (radio_ministerio.Checked)
                MessageBox.Show("Você esta vendo informações de ministério.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (business.classes.Abstrato.Ministerio)item;
                dgdados.Rows.Add(dado.Id, dado.Nome, dado.Maximo_pessoa, dado.Ministro_, dado.Proposito);
            }
        }

        private void radio_celula_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(false, false, true, false, false, false);
            if (radio_celula.Checked)
                MessageBox.Show("Você esta vendo informações de celula.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {                
                var dado = (business.classes.Abstrato.Celula)item;
                dgdados.Rows.Add(dado.Id, dado.Nome, dado.Maximo_pessoa, dado.Dia_semana, dado.Horario);
            }
        }

        private void radio_chamada_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Chamada();
            FormataDataGrid(false, false, false, true, false, false);
            if (radio_chamada.Checked)
                MessageBox.Show("Você esta vendo informações de chamada.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (business.classes.Chamada)item;
                dgdados.Rows.Add(dado.Id, dado.Data_inicio, dado.Numero_chamada);
            }
        }

        private void radio_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Reuniao();
            FormataDataGrid(false, false, false, false, true, false);
            if (radio_reuniao.Checked)
                MessageBox.Show("Você esta vendo informações de reunião.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Reuniao)item;
                dgdados.Rows.Add(dado.Id, dado.Data_reuniao, dado.Horario_fim, dado.Horario_inicio);
            }
        }

        private void radio_historico_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Historico();
            FormataDataGrid(false, false, false, false, false, true);
            if (radio_historico.Checked)
                MessageBox.Show("Você esta vendo informações de histórico.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Historico)item;
                dgdados.Rows.Add(dado.Id, dado.Data_inicio, dado.Falta, dado.pessoaid);
            }
        }       

        private void FormataDataGrid(bool Pessoa, bool Ministerio,
        bool Celula, bool Chamada, bool Reuniao, bool Historico)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            check_pesquisa_id.Enabled = true;
            check_pesquisa_nome.Enabled = false;
            check_pesquisa_email.Enabled = false;
            check_pesquisa_nome_mae.Enabled = false;
            check_pesquisa_nome_pai.Enabled = false;
            check_pesquisa_data_visita.Enabled = false;
            check_pesquisa_data_reuniao.Enabled = false;
            check_pesquisa_ano_batismo.Enabled = false;
            check_pesquisa_email.Enabled = false;

            if (Pessoa)
            {
                tipo = "Pessoa";
                check_pesquisa_email.Enabled = true;
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Email", "Email");
                dgdados.Columns.Add("celula_", "Celula");
                dgdados.Columns.Add("Falta", "Falta");
                dgdados.Columns.Add("Img", "Imagem");
                dgdados.Columns[1].Width = 300;
                
                comboBox1.Items.Add("Visitante");
                comboBox1.Items.Add("Criança");
                comboBox1.Items.Add("Membro por aclamação");
                comboBox1.Items.Add("Membro por batismo");
                comboBox1.Items.Add("Membro por reconciliação");
                comboBox1.Items.Add("Membro por trandferência");
            }

            if (Ministerio)
            {
                tipo = "Ministerio";
                check_pesquisa_nome.Enabled = true;
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Nome", "Nome");
                dgdados.Columns.Add("Maximo_pessoa", "Maximo de pessoas");
                dgdados.Columns.Add("Ministro_", "Ministro");
                dgdados.Columns.Add("Proposito", "Proposito");
                dgdados.Columns[2].Width = 300;
                
                comboBox1.Items.Add("Lider de celula");
                comboBox1.Items.Add("Lider em treinamento de celula");
                comboBox1.Items.Add("Lider de ministério");
                comboBox1.Items.Add("Lider em treinamento de ministério");
                comboBox1.Items.Add("Supervisor de celula");
                comboBox1.Items.Add("Supervisor em treinamento de celula");
                comboBox1.Items.Add("Supervisor de ministério");
                comboBox1.Items.Add("Supervisor em treinamento de ministério");
            }

            if (Celula)
            {
                tipo = "Celula";
                check_pesquisa_nome.Enabled = true;
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Nome", "Nome");
                dgdados.Columns.Add("Maximo_pessoa", "Maximo de pessoas");
                dgdados.Columns.Add("Dia_semana", "Dia da semana");
                dgdados.Columns.Add("Horario", "Horário");
                dgdados.Columns[2].Width = 300;
                dgdados.Columns[4].Width = 150;
                
                comboBox1.Items.Add("Celula para adolescentes");
                comboBox1.Items.Add("Celula para adultos");
                comboBox1.Items.Add("Celula para jovens");
                comboBox1.Items.Add("Celula para crianças");
                comboBox1.Items.Add("Celula para casados");
            }

            if (Chamada)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Data_inicio", "Data de início");
                dgdados.Columns.Add("Numero_chamada", "numero da chamada");
                dgdados.Columns[1].Width = 300;
                dgdados.Columns[2].Width = 300;
            }

            if (Reuniao)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Data_reuniao", "Data da reunião");
                dgdados.Columns.Add("Horario_inicio", "Horário que inicia");
                dgdados.Columns.Add("Horario_fim", "Horário que termina");
                dgdados.Columns[1].Width = 300;
                dgdados.Columns[2].Width = 300;
            }

            if (Historico)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Data_inicio", "Data de inicio do semestre");
                dgdados.Columns.Add("Falta", "Faltas");
                dgdados.Columns.Add("pessoaid", "Identificação da pessoa");
                dgdados.Columns[1].Width = 400;
                dgdados.Columns[3].Width = 400;
            }


        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            dgdados.Font = new Font("Arial", 18);
            
        }

        private void ModificaDataGridView(modelocrud m, string tipo, string comando)
        {
            if(m == null && tipo == "Pessoa")
            {
                FormataDataGrid(true, false, false, false, false, false);
            }

            if (m == null && tipo == "Ministerio")
            {
                FormataDataGrid(false, true, false, false, false, false);
            }

            if (m == null && tipo == "Celula")
            {
                FormataDataGrid(false, false, true, false, false, false);
            }

            if (m is business.classes.Abstrato.Pessoa)
            {
                if (m is business.classes.Pessoas.Visitante)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Data_visita", "Data da visita");
                    dgdados.Columns.Add("Condicao_religiosa", "Condição religiosa");
                }

                if (m is business.classes.Pessoas.Crianca)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Nome_mae", "Nome da mãe");
                    dgdados.Columns.Add("Nome_pai", "Nome do pai");
                }

                if (m is business.classes.Pessoas.Membro_Aclamacao)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Denominacao", "Denominação");
                }

                if (m is business.classes.Pessoas.Membro_Batismo)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                }

                if (m is business.classes.Pessoas.Membro_Reconciliacao)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Data_reconciliacao", "Ano da reconciliação");
                }

                if (m is business.classes.Pessoas.Membro_Reconciliacao)
                {
                    FormataDataGrid(true, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Nome_cidade_transferencia", "Nome da cidade onde estava");
                    dgdados.Columns.Add("Estado_transferencia", "Nome do estado onde estava");
                    dgdados.Columns.Add("Nome_igreja_transferencia", "Nome da igreja onde estava");
                } 
            }

            if(m is business.classes.Abstrato.Ministerio)
            {
                if(m is business.classes.Ministerio.Supervisor_Celula)
                {
                    FormataDataGrid(false, true, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is business.classes.Ministerio.Supervisor_Celula_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is business.classes.Ministerio.Supervisor_Ministerio)
                {
                    FormataDataGrid(false, true, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is business.classes.Ministerio.Supervisor_Ministerio_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }
            }

            foreach (var item in pesquisa.BuscarPorRestricao(m, tipo, comando))
            {
                if (m is business.classes.Abstrato.Pessoa)
                {
                    if (m is business.classes.Pessoas.Visitante)
                    {
                        business.classes.Pessoas.Visitante info = (business.classes.Pessoas.Visitante)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_visita, info.Condicao_religiosa);
                    }

                    if (m is business.classes.Pessoas.Crianca)
                    {
                        business.classes.Pessoas.Crianca info = (business.classes.Pessoas.Crianca)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Nome_mae, info.Nome_pai);
                    }

                    if (m is business.classes.Pessoas.Membro_Aclamacao)
                    {
                        business.classes.Pessoas.Membro_Aclamacao info = (business.classes.Pessoas.Membro_Aclamacao)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Denominacao, info.Desligamento, info.Motivo_desligamento);
                    }

                    if (m is business.classes.Pessoas.Membro_Batismo)
                    {
                        business.classes.Pessoas.Membro_Batismo info = (business.classes.Pessoas.Membro_Batismo)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento);
                    }

                    if (m is business.classes.Pessoas.Membro_Reconciliacao)
                    {
                        business.classes.Pessoas.Membro_Reconciliacao info = (business.classes.Pessoas.Membro_Reconciliacao)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Data_reconciliacao);
                    }

                    if (m is business.classes.Pessoas.Membro_Transferencia)
                    {
                        business.classes.Pessoas.Membro_Transferencia info = (business.classes.Pessoas.Membro_Transferencia)item;
                        dgdados.Rows.Add(info.Id, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Nome_cidade_transferencia,
                        info.Estado_transferencia, info.Nome_igreja_transferencia);
                    } 
                }
                
                if(m is business.classes.Abstrato.Ministerio)
                {
                    if (m is business.classes.Ministerio.Supervisor_Celula)
                    {
                        business.classes.Ministerio.Supervisor_Celula info = (business.classes.Ministerio.Supervisor_Celula)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if (m is business.classes.Ministerio.Supervisor_Celula_Treinamento)
                    {
                        business.classes.Ministerio.Supervisor_Celula_Treinamento info = (business.classes.Ministerio.Supervisor_Celula_Treinamento)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if (m is business.classes.Ministerio.Supervisor_Ministerio)
                    {
                        business.classes.Ministerio.Supervisor_Ministerio info = (business.classes.Ministerio.Supervisor_Ministerio)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if (m is business.classes.Ministerio.Supervisor_Ministerio_Treinamento)
                    {
                        business.classes.Ministerio.Supervisor_Ministerio_Treinamento info = (business.classes.Ministerio.Supervisor_Ministerio_Treinamento)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if(m is business.classes.Ministerio.Lider_Celula ||
                       m is business.classes.Ministerio.Lider_Celula_Treinamento ||
                       m is business.classes.Ministerio.Lider_Ministerio ||
                       m is business.classes.Ministerio.Lider_Ministerio_Treinamento)
                    {
                        business.classes.Ministerio.Lider_Celula info = (business.classes.Ministerio.Lider_Celula)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito);
                    }
                }

                if(m is business.classes.Abstrato.Celula)
                {
                    if(m is business.classes.Celulas.Celula_Adolescente ||
                        m is business.classes.Celulas.Celula_Adulto ||
                        m is business.classes.Celulas.Celula_Casado ||
                        m is business.classes.Celulas.Celula_Jovem ||
                        m is business.classes.Celulas.Celula_Crianca)
                    {
                        business.classes.Celulas.Celula_Crianca info = (business.classes.Celulas.Celula_Crianca)item;
                        dgdados.Rows.Add(info.Id, info.Nome, info.Maximo_pessoa, info.Dia_semana, info.Horario);
                    }
                }
            }
        }

        
    }
}
