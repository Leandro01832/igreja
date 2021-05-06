using database;
using System;
using System.Drawing;
using System.Windows.Forms;
using business.classes.PessoasLgpd;
using business.classes.Pessoas;
using business.classes.Ministerio;
using business.classes.Abstrato;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : FormPadrao
    {
        public Pesquisar()
        {
            pesquisa = new DdataGridViews.Pesquisar();
            modelo = null;
            
            InitializeComponent();
        }

       DdataGridViews.Pesquisar pesquisa;
        modelocrud modelo;
        string comando = "";
        string tipo = "";

        private void radio_mudanca_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.MudancaEstado();
            FormataDataGrid(false, false, false, false, false, false, false, false, true);
            if (radio_reuniao.Checked)
                MessageBox.Show("Você esta vendo informações de mudança de estado.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.MudancaEstado)item;
                dgdados.Rows.Add(dado.IdMudanca, dado.CodigoPessoa, dado.velhoEstado, dado.novoEstado,
                dado.DataMudanca);
            }
        }

        private void radio_endereco_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Endereco();
            FormataDataGrid(false, false, false, false, false, false, false, true, false);
            if (radio_reuniao.Checked)
                MessageBox.Show("Você esta vendo informações de Endereço.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Endereco)item;
                dgdados.Rows.Add(dado.IdEndereco, dado.Pais, dado.Estado, dado.Cidade,
                dado.Bairro, dado.Rua, dado.Numero_casa, dado.Cep);
            }
        }

        private void radio_telefone_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Telefone();
            FormataDataGrid(false, false, false, false, false, false, true, false, false);
            if (radio_reuniao.Checked)
                MessageBox.Show("Você esta vendo informações de Telefone.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Telefone)item;
                dgdados.Rows.Add(dado.IdTelefone, dado.Fone, dado.Celular, dado.Whatsapp);
            }
        }

        private void radio_pessoa_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(true, false, false, false, false, false, false, false, false);
            if (radio_pessoa.Checked)
                MessageBox.Show("Você esta vendo informações de pessoa.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (PessoaDado)item;
                dgdados.Rows.Add(dado.IdPessoa, dado.Email, dado.celula_, dado.Falta, dado.Img);
            }   
        }

        private void radio_ministerio_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(false, true, false, false, false, false, false, false, false);
            if (radio_ministerio.Checked)
                MessageBox.Show("Você esta vendo informações de ministério.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (Ministerio)item;
                dgdados.Rows.Add(dado.IdMinisterio, dado.Nome, dado.Maximo_pessoa, dado.Ministro_, dado.Proposito);
            }
        }

        private void radio_celula_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            comando = "";
            FormataDataGrid(false, false, true, false, false, false, false, false, false);
            if (radio_celula.Checked)
                MessageBox.Show("Você esta vendo informações de celula.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {                
                var dado = (Celula)item;
                dgdados.Rows.Add(dado.IdCelula, dado.Nome, dado.Maximo_pessoa, dado.Dia_semana, dado.Horario);
            }
        }

        private void radio_chamada_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Chamada();
            FormataDataGrid(false, false, false, true, false, false, false, false, false);
            if (radio_chamada.Checked)
                MessageBox.Show("Você esta vendo informações de chamada.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, tipo, comando))
            {
                var dado = (business.classes.Chamada)item;
                dgdados.Rows.Add(dado.IdChamada, dado.Data_inicio, dado.Numero_chamada);
            }
        }

        private void radio_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Reuniao();
            FormataDataGrid(false, false, false, false, true, false, false, false, false);
            if (radio_reuniao.Checked)
                MessageBox.Show("Você esta vendo informações de reunião.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Reuniao)item;
                dgdados.Rows.Add(dado.IdReuniao, dado.Data_reuniao, dado.Horario_fim, dado.Horario_inicio);
            }
        }

        private void radio_historico_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "Escolha o tipo se necessário.";
            modelo = new business.classes.Historico();
            FormataDataGrid(false, false, false, false, false, true, false, false, false);
            if (radio_historico.Checked)
                MessageBox.Show("Você esta vendo informações de histórico.");

            foreach (var item in pesquisa.BuscarPorRestricao(modelo, "", ""))
            {
                var dado = (business.classes.Historico)item;
                dgdados.Rows.Add(dado.IdHistorico, dado.Data_inicio, dado.Falta, dado.pessoaid);
            }
        }       

        private void FormataDataGrid(bool Pessoa, bool Ministerio,
        bool Celula, bool Chamada, bool Reuniao, bool Historico, bool Telefone, bool Endereco,  bool Mudanca)
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
                dgdados.Columns.Add("Codigo", "Id");
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

            if (Telefone)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Fone", "Fone");
                dgdados.Columns.Add("Celular", "Celular");
                dgdados.Columns.Add("Whatsapp", "Whatsapp");
            }

            if (Endereco)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("Pais", "País");
                dgdados.Columns.Add("Estado", "Estado");
                dgdados.Columns.Add("Cidade", "Cidade");
                dgdados.Columns.Add("Bairro", "Bairro");
                dgdados.Columns.Add("Rua", "Rua");
                dgdados.Columns.Add("Numero_casa", "Numero da casa");
                dgdados.Columns.Add("Cep", "Cep");
            }

            if (Mudanca)
            {
                dgdados.Columns.Clear();
                dgdados.Columns.Add("Id", "Id");
                dgdados.Columns.Add("CodigoPessoa", "Identificação da pessoa");
                dgdados.Columns.Add("velhoEstado", "Estado antigo");
                dgdados.Columns.Add("novoEstado", "Estado novo");
                dgdados.Columns.Add("DataMudanca", "Data da mudança");
            }
        }

        private void Pesquisar_Load(object sender, EventArgs e)
        {
            dgdados.Font = new Font("Arial", 18);
            
        }

        private void ModificaDataGridView(modelocrud m, string tipo, string comando)
        {
            if(m == null && tipo == "Pessoa" || m == null && tipo == "PessoaLgpd")
            {
                FormataDataGrid(true, false, false, false, false, false, false, false, false);
            }

            if (m == null && tipo == "Ministerio")
            {
                FormataDataGrid(false, true, false, false, false, false, false, false, false);
            }

            if (m == null && tipo == "Celula")
            {
                FormataDataGrid(false, false, true, false, false, false, false, false, false);
            }
            
            if (m is Pessoa)
            {
                if (m is Visitante || m is VisitanteLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Data_visita", "Data da visita");
                    dgdados.Columns.Add("Condicao_religiosa", "Condição religiosa");
                }

                if (m is Crianca || m is CriancaLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Nome_mae", "Nome da mãe");
                    dgdados.Columns.Add("Nome_pai", "Nome do pai");
                }

                if (m is Membro_Aclamacao || m is Membro_AclamacaoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Denominacao", "Denominação");
                }

                if (m is Membro_Batismo || m is Membro_BatismoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                }

                if (m is Membro_Reconciliacao ||  m is Membro_ReconciliacaoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Data_reconciliacao", "Ano da reconciliação");
                }

                if (m is Membro_Transferencia || m is Membro_TransferenciaLgpd)
                {
                    FormataDataGrid(true, false, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Nome_cidade_transferencia", "Nome da cidade onde estava");
                    dgdados.Columns.Add("Estado_transferencia", "Nome do estado onde estava");
                    dgdados.Columns.Add("Nome_igreja_transferencia", "Nome da igreja onde estava");
                } 
            }

            if(m is Ministerio)
            {
                if(m is Supervisor_Celula)
                {
                    FormataDataGrid(false, true, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Celula_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Ministerio)
                {
                    FormataDataGrid(false, true, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Ministerio_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false, false, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }
            }

            foreach (var item in pesquisa.BuscarPorRestricao(m, tipo, comando))
            {
                if (m is Pessoa)
                {
                    if (m is Visitante)
                    {
                        Visitante info = (Visitante)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_visita, info.Condicao_religiosa);
                    }

                    if ( m is VisitanteLgpd)
                    {
                        VisitanteLgpd info = (VisitanteLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_visita, info.Condicao_religiosa);
                    }

                    if (m is Crianca)
                    {
                        Crianca info = (Crianca)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Nome_mae, info.Nome_pai);
                    }
                    if ( m is CriancaLgpd)
                    {
                        CriancaLgpd info = (CriancaLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Nome_mae, info.Nome_pai);
                    }

                    if ( m is Membro_Aclamacao)
                    {
                        Membro_Aclamacao info = (Membro_Aclamacao)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Denominacao, info.Desligamento, info.Motivo_desligamento);
                    }
                    if (m is Membro_AclamacaoLgpd)
                    {
                        Membro_AclamacaoLgpd info = (Membro_AclamacaoLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Denominacao, info.Desligamento, info.Motivo_desligamento);
                    }

                    if (m is Membro_Batismo)
                    {
                        Membro_Batismo info = (Membro_Batismo)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento);
                    }

                    if (m is Membro_BatismoLgpd)
                    {
                        Membro_BatismoLgpd info = (Membro_BatismoLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento);
                    }

                    if (m is Membro_Reconciliacao)
                    {
                        Membro_Reconciliacao info = (Membro_Reconciliacao)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Data_reconciliacao);
                    }

                    if ( m is Membro_ReconciliacaoLgpd)
                    {
                        Membro_ReconciliacaoLgpd info = (Membro_ReconciliacaoLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Data_reconciliacao);
                    }

                    if (m is Membro_Transferencia)
                    {
                        Membro_Transferencia info = (Membro_Transferencia)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento,
                        info.Nome_cidade_transferencia,
                        info.Estado_transferencia, info.Nome_igreja_transferencia);
                    }

                    if ( m is Membro_TransferenciaLgpd)
                    {
                        Membro_TransferenciaLgpd info = (Membro_TransferenciaLgpd)item;
                        dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                        info.Data_batismo, info.Desligamento, info.Motivo_desligamento,
                        info.Nome_cidade_transferencia,
                        info.Estado_transferencia, info.Nome_igreja_transferencia);
                    }
                }
                
                if(m is Ministerio)
                {
                    if (m is Supervisor_Celula)
                    {
                        Supervisor_Celula info = (Supervisor_Celula)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa,
                            info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if (m is Supervisor_Celula_Treinamento)
                    {
                        Supervisor_Celula_Treinamento info = (Supervisor_Celula_Treinamento)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                            info.Proposito, info.Maximo_celula);
                    }

                    if (m is Supervisor_Ministerio)
                    {
                        Supervisor_Ministerio info = (Supervisor_Ministerio)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                            info.Proposito, info.Maximo_celula);
                    }

                    if (m is Supervisor_Ministerio_Treinamento)
                    {
                        Supervisor_Ministerio_Treinamento info = (Supervisor_Ministerio_Treinamento)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                        info.Proposito, info.Maximo_celula);
                    }

                    if(m is Lider_Celula ||
                       m is Lider_Celula_Treinamento ||
                       m is Lider_Ministerio ||
                       m is Lider_Ministerio_Treinamento)
                    {
                        Lider_Celula info = (Lider_Celula)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito);
                    }
                }

                if(m is Celula)
                {
                    if(m is business.classes.Celulas.Celula_Adolescente ||
                        m is business.classes.Celulas.Celula_Adulto ||
                        m is business.classes.Celulas.Celula_Casado ||
                        m is business.classes.Celulas.Celula_Jovem ||
                        m is business.classes.Celulas.Celula_Crianca)
                    {
                        business.classes.Celulas.Celula_Crianca info = (business.classes.Celulas.Celula_Crianca)item;
                        dgdados.Rows.Add(info.IdCelula, info.Nome, info.Maximo_pessoa, info.Dia_semana, info.Horario);
                    }
                }
            }
        }

        
    }
}
