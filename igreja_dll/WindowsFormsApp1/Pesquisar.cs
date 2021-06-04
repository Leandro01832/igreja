using database;
using System;
using System.Drawing;
using System.Windows.Forms;
using business.classes.PessoasLgpd;
using business.classes.Pessoas;
using business.classes.Ministerio;
using business.classes.Abstrato;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Celula;
using business.classes;
using WindowsFormsApp1.Formulario.Reuniao;
using business.classes.Celulas;

namespace WindowsFormsApp1
{
    public partial class Pesquisar : FormPadrao
    {
        public Pesquisar()
        {
            modelo = null;
            InitializeComponent();
        }
        modelocrud modelo;
        string tipo = "";
        List<modelocrud> Resultado = new List<modelocrud>();

        private void radio_mudanca_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_mudanca.Checked)
            {
                comboBox1.Text = "Escolha o tipo se necessário.";
                FormataDataGrid(false, false, false, false, true);
                if (radio_reuniao.Checked)
                    MessageBox.Show("Você esta vendo informações de mudança de estado.");
                Resultado.Clear();
                Resultado.AddRange(listaMudancaEstado);

                foreach (var item in listaMudancaEstado)
                {
                    var dado = (MudancaEstado)item;
                    dgdados.Rows.Add(dado.IdMudanca, dado.CodigoPessoa, dado.velhoEstado, dado.novoEstado,
                    dado.DataMudanca);
                } 
            }
        }

        private void radio_pessoa_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_pessoa.Checked)
            {
                tipo = "Pessoa";
                comboBox1.Text = "Escolha o tipo se necessário.";
                FormataDataGrid(true, false, false, false, false);
                if (radio_pessoa.Checked)
                    MessageBox.Show("Você esta vendo informações de pessoa.");
                Resultado.Clear();
                Resultado.AddRange(listaPessoas);

                foreach (var item in listaPessoas)
                {
                    var dado = (Pessoa)item;
                    dgdados.Rows.Add(dado.IdPessoa, dado.Email, dado.celula_, dado.Falta, dado.Img);
                } 
            }
        }

        private void radio_ministerio_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_ministerio.Checked)
            {
                tipo = "Ministerio";
                comboBox1.Text = "Escolha o tipo se necessário.";
                FormataDataGrid(false, true, false, false, false);
                if (radio_ministerio.Checked)
                    MessageBox.Show("Você esta vendo informações de ministério.");

                Resultado.Clear();
                Resultado.AddRange(listaMinisterios);

                foreach (var item in listaMinisterios)
                {
                    var dado = (Ministerio)item;
                    dgdados.Rows.Add(dado.IdMinisterio, dado.Nome, dado.Maximo_pessoa, dado.Ministro_, dado.Proposito);
                } 
            }
        }

        private void radio_celula_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_celula.Checked)
            {
                tipo = "Celula";
                comboBox1.Text = "Escolha o tipo se necessário.";
                FormataDataGrid(false, false, true, false, false);
                if (radio_celula.Checked)
                    MessageBox.Show("Você esta vendo informações de celula.");
                Resultado.Clear();
                Resultado.AddRange(listaCelulas);

                foreach (var item in listaCelulas)
                {
                    var dado = (Celula)item;
                    dgdados.Rows.Add(dado.IdCelula, dado.Nome, dado.Maximo_pessoa, dado.Dia_semana, dado.Horario);
                } 
            }
        }

        private void radio_reuniao_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_reuniao.Checked)
            {
                comboBox1.Text = "Escolha o tipo se necessário.";
                FormataDataGrid(false, false, false, true, false);
                if (radio_reuniao.Checked)
                    MessageBox.Show("Você esta vendo informações de reunião.");
                Resultado.Clear();
                Resultado.AddRange(listaReuniao);

                foreach (var item in listaReuniao)
                {
                    var dado = item;
                    dgdados.Rows.Add(dado.IdReuniao, dado.Data_reuniao, dado.Horario_fim, dado.Horario_inicio);
                } 
            }
        }

        private void FormataDataGrid(bool Pessoa, bool Ministerio, bool Celula, bool Reuniao, bool Mudanca)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();

            // Pesquisas a  serem realizadas
            check_pesquisa_id.Enabled = true;
            check_pesquisa_nome.Enabled = false;
            check_pesquisa_email.Enabled = false;
            check_pesquisa_nome_mae.Enabled = false;
            check_pesquisa_nome_pai.Enabled = false;
            check_pesquisa_data_visita.Enabled = false;
            check_pesquisa_data_reuniao.Enabled = false;
            check_pesquisa_ano_batismo.Enabled = false;
            check_horario_celula.Enabled = false;
            check_horario_reuniao.Enabled = false;
            check_horario_final_reuniao.Enabled = false;
            check_data_mudanca_estado.Enabled = false;

            if (Pessoa)
            {

                check_pesquisa_email.Enabled = true;
                check_pesquisa_nome.Enabled = true;
                tipo = "Pessoa";
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

                comboBox1.Items.Add("Visitante Lgpd");
                comboBox1.Items.Add("Criança Lgpd");
                comboBox1.Items.Add("Membro por aclamação Lgpd");
                comboBox1.Items.Add("Membro por batismo Lgpd");
                comboBox1.Items.Add("Membro por reconciliação Lgpd");
                comboBox1.Items.Add("Membro por trandferência Lgpd");

            }

            if (Ministerio)
            {
                check_pesquisa_nome.Enabled = true;
                tipo = "Ministerio";
                dgdados.Columns.Clear();
                dgdados.Columns.Add("IdMinisterio", "Id");
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

                check_pesquisa_nome.Enabled = true;
                check_horario_celula.Enabled = true;
                tipo = "Celula";
                dgdados.Columns.Clear();
                dgdados.Columns.Add("IdCelula", "Id");
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

            if (Reuniao)
            {
                check_pesquisa_data_reuniao.Enabled = true;
                dgdados.Columns.Clear();
                dgdados.Columns.Add("IdReuniao", "Id");
                dgdados.Columns.Add("Data_reuniao", "Data da reunião");
                dgdados.Columns.Add("Horario_inicio", "Horário que inicia");
                dgdados.Columns.Add("Horario_fim", "Horário que termina");
                dgdados.Columns[1].Width = 300;
                dgdados.Columns[2].Width = 300;
            }

            if (Mudanca)
            {
                check_data_mudanca_estado.Enabled = true;
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

        private void ModificaDataGridView(modelocrud m, string tipo, List<modelocrud> models)
        {
            if (m == null && tipo == "Pessoa" || m == null && tipo == "PessoaLgpd")
            {
                FormataDataGrid(true, false, false, false, false);
            }

            if (m == null && tipo == "Ministerio")
            {
                FormataDataGrid(false, true, false, false, false);
            }

            if (m == null && tipo == "Celula")
            {
                FormataDataGrid(false, false, true, false, false);
            }

            if (m is Pessoa)
            {
                if (m is Visitante || m is VisitanteLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Data_visita", "Data da visita");
                    dgdados.Columns.Add("Condicao_religiosa", "Condição religiosa");
                }

                if (m is Crianca || m is CriancaLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Nome_mae", "Nome da mãe");
                    dgdados.Columns.Add("Nome_pai", "Nome do pai");
                }

                if (m is Membro_Aclamacao || m is Membro_AclamacaoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Denominacao", "Denominação");
                }

                if (m is Membro_Batismo || m is Membro_BatismoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                }

                if (m is Membro_Reconciliacao || m is Membro_ReconciliacaoLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Data_reconciliacao", "Ano da reconciliação");
                }

                if (m is Membro_Transferencia || m is Membro_TransferenciaLgpd)
                {
                    FormataDataGrid(true, false, false, false, false);
                    dgdados.Columns.Add("Data_batismo", "ano do batismo");
                    dgdados.Columns.Add("Desligamento", "Desligamento");
                    dgdados.Columns.Add("Motivo_desligamento", "Motivo do desligamento");
                    dgdados.Columns.Add("Nome_cidade_transferencia", "Nome da cidade onde estava");
                    dgdados.Columns.Add("Estado_transferencia", "Nome do estado onde estava");
                    dgdados.Columns.Add("Nome_igreja_transferencia", "Nome da igreja onde estava");
                }
            }

            if (m is Ministerio)
            {
                if (m is Supervisor_Celula)
                {
                    FormataDataGrid(false, true, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Celula_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Ministerio)
                {
                    FormataDataGrid(false, true, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }

                if (m is Supervisor_Ministerio_Treinamento)
                {
                    FormataDataGrid(false, true, false, false, false);
                    dgdados.Columns.Add("Maximo_celula", "máximo de celulas supervisionadas");
                }
            }

            foreach (var item in models)
            {
                if (item is Pessoa)
                {
                    if (item is PessoaDado)
                    {
                        if (item is Visitante)
                        {
                            Visitante info = (Visitante)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_visita, info.Condicao_religiosa);
                        }

                        if (item is Crianca)
                        {
                            Crianca info = (Crianca)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Nome_mae, info.Nome_pai);
                        }

                        if (item is Membro_Aclamacao)
                        {
                            Membro_Aclamacao info = (Membro_Aclamacao)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Denominacao, info.Desligamento, info.Motivo_desligamento);
                        }

                        if (item is Membro_Batismo)
                        {
                            Membro_Batismo info = (Membro_Batismo)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento);
                        }

                        if (item is Membro_Reconciliacao)
                        {
                            Membro_Reconciliacao info = (Membro_Reconciliacao)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Data_reconciliacao);
                        }

                        if (item is Membro_Transferencia)
                        {
                            Membro_Transferencia info = (Membro_Transferencia)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento,
                            info.Nome_cidade_transferencia,
                            info.Estado_transferencia, info.Nome_igreja_transferencia);
                        }
                    }

                    if (item is PessoaLgpd)
                    {
                        if (item is VisitanteLgpd)
                        {
                            VisitanteLgpd info = (VisitanteLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_visita, info.Condicao_religiosa);
                        }

                        if (item is CriancaLgpd)
                        {
                            CriancaLgpd info = (CriancaLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Nome_mae, info.Nome_pai);
                        }

                        if (item is Membro_AclamacaoLgpd)
                        {
                            Membro_AclamacaoLgpd info = (Membro_AclamacaoLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Denominacao, info.Desligamento, info.Motivo_desligamento);
                        }

                        if (item is Membro_BatismoLgpd)
                        {
                            Membro_BatismoLgpd info = (Membro_BatismoLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento);
                        }

                        if (item is Membro_ReconciliacaoLgpd)
                        {
                            Membro_ReconciliacaoLgpd info = (Membro_ReconciliacaoLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento, info.Data_reconciliacao);
                        }

                        if (item is Membro_TransferenciaLgpd)
                        {
                            Membro_TransferenciaLgpd info = (Membro_TransferenciaLgpd)item;
                            dgdados.Rows.Add(info.IdPessoa, info.Email, info.celula_, info.Falta, info.Img,
                            info.Data_batismo, info.Desligamento, info.Motivo_desligamento,
                            info.Nome_cidade_transferencia,
                            info.Estado_transferencia, info.Nome_igreja_transferencia);
                        }
                    }
                }

                if (item is Ministerio)
                {
                    if (item is Supervisor_Celula)
                    {
                        Supervisor_Celula info = (Supervisor_Celula)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa,
                            info.Ministro_, info.Proposito, info.Maximo_celula);
                    }

                    if (item is Supervisor_Celula_Treinamento)
                    {
                        Supervisor_Celula_Treinamento info = (Supervisor_Celula_Treinamento)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                            info.Proposito, info.Maximo_celula);
                    }

                    if (item is Supervisor_Ministerio)
                    {
                        Supervisor_Ministerio info = (Supervisor_Ministerio)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                            info.Proposito, info.Maximo_celula);
                    }

                    if (item is Supervisor_Ministerio_Treinamento)
                    {
                        Supervisor_Ministerio_Treinamento info = (Supervisor_Ministerio_Treinamento)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_,
                        info.Proposito, info.Maximo_celula);
                    }

                    if (item is Lider_Celula ||
                       item is Lider_Celula_Treinamento ||
                       item is Lider_Ministerio ||
                       item is Lider_Ministerio_Treinamento)
                    {
                        Ministerio info = (Ministerio)item;
                        dgdados.Rows.Add(info.IdMinisterio, info.Nome, info.Maximo_pessoa, info.Ministro_, info.Proposito);
                    }
                }

                if (item is Celula)
                {
                    if (item is Celula_Adolescente || item is Celula_Adulto ||
                        item is Celula_Casado || item is Celula_Jovem ||
                        item is Celula_Crianca)
                    {
                        Celula_Crianca info = (Celula_Crianca)item;
                        dgdados.Rows.Add(info.IdCelula, info.Nome, info.Maximo_pessoa, info.Dia_semana, info.Horario);
                    }
                }
            }
        }
        
        private void dgdados_SelectionChanged(object sender, EventArgs e)
        {
            var id = dgdados.CurrentRow.Cells[0];
            var value = int.Parse(id.Value.ToString());

            if (modelo != null)
            {
                if (modelo is Pessoa)
                {
                    var Modelo = listaPessoas.FirstOrDefault(i => i.Codigo == value);
                    if (Modelo != null)
                    {
                        FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((Pessoa)Modelo
                    , false, false, true);
                        fc.MdiParent = this.MdiParent;
                        fc.Show();
                    }
                }

                if (modelo is Ministerio)
                {
                    var Modelo = listaMinisterios.FirstOrDefault(i => i.IdMinisterio == value);
                    if (Modelo != null)
                    {
                        FinalizarCadastroMinisterio dp = new FinalizarCadastroMinisterio((Ministerio)Modelo,
                    false, false, true);
                        dp.MdiParent = this.MdiParent;
                        dp.Show();
                    }
                }

                if (modelo is Celula)
                {
                    var Modelo = listaCelulas.FirstOrDefault(i => i.IdCelula == value);
                    if (Modelo != null)
                    {
                        FinalizarCadastro dp =
                new FinalizarCadastro((Celula)Modelo, false, false, true);
                        dp.MdiParent = this.MdiParent;
                        dp.Show();
                    }
                }

                if (modelo is Reuniao)
                {
                    var Modelo = listaReuniao.FirstOrDefault(i => i.IdReuniao == value);
                    if (Modelo != null)
                    {
                        FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, false, false, true);
                        frm.MdiParent = this.MdiParent;
                        frm.Show();
                    }
                }
            }

            else if (tipo == "Pessoa")
            {
                var Modelo = listaPessoas.FirstOrDefault(i => i.Codigo == value);
                if (Modelo != null)
                {
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((Pessoa)Modelo
                , false, false, true);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
            }
            else if (tipo == "Ministerio")
            {
                var Modelo = listaMinisterios.FirstOrDefault(i => i.IdMinisterio == value);
                if (Modelo != null)
                {
                    FinalizarCadastroMinisterio dp = new FinalizarCadastroMinisterio((Ministerio)Modelo,
                false, false, true);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
            }
            else if (tipo == "Celula")
            {
                var Modelo = listaCelulas.FirstOrDefault(i => i.IdCelula == value);
                if (Modelo != null)
                {
                    FinalizarCadastro dp =
                     new FinalizarCadastro((Celula)Modelo, false, false, true);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verifica();
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            ModificaDataGridView(modelo, tipo, Resultado);
            verifica();
        }

        private void verifica()
        {


            if (comboBox1.Text == "Visitante Lgpd")
            {
                check_pesquisa_data_visita.Enabled = true;
                modelo = new VisitanteLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<VisitanteLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Criança Lgpd")
            {
                check_pesquisa_nome_mae.Enabled = true;
                check_pesquisa_nome_pai.Enabled = true;
                modelo = new CriancaLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<CriancaLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por aclamação Lgpd")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_AclamacaoLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_AclamacaoLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por batismo Lgpd")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_BatismoLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_BatismoLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por reconciliação Lgpd")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_ReconciliacaoLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_ReconciliacaoLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por trandferência Lgpd")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_TransferenciaLgpd();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_TransferenciaLgpd>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Visitante")
            {
                check_pesquisa_data_visita.Enabled = true;
                modelo = new Visitante();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Visitante>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Criança")
            {
                check_pesquisa_nome_mae.Enabled = true;
                check_pesquisa_nome_pai.Enabled = true;
                modelo = new Crianca();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Crianca>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por aclamação")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_Aclamacao();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_Aclamacao>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por batismo")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_Batismo();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_Batismo>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por reconciliação")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_Reconciliacao();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_Reconciliacao>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Membro por trandferência")
            {
                check_pesquisa_ano_batismo.Enabled = true;
                modelo = new Membro_Transferencia();
                Resultado.Clear();
                Resultado.AddRange(listaPessoas.OfType<Membro_Transferencia>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Lider de celula")
            {
                modelo = new Lider_Celula();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Lider_Celula>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Lider em treinamento de celula")
            {
                modelo = new Lider_Celula_Treinamento();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Lider_Celula_Treinamento>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Lider de ministério")
            {
                modelo = new Lider_Ministerio();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Lider_Ministerio>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Lider em treinamento de ministério")
            {
                modelo = new Lider_Ministerio_Treinamento();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Lider_Ministerio_Treinamento>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Supervisor de celula")
            {
                modelo = new Supervisor_Celula();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Supervisor_Celula>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Supervisor em treinamento de celula")
            {
                modelo = new Supervisor_Celula_Treinamento();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Supervisor_Celula_Treinamento>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Supervisor de ministério")
            {
                modelo = new Supervisor_Ministerio();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Supervisor_Ministerio>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Supervisor em treinamento de ministério")
            {
                modelo = new Supervisor_Ministerio_Treinamento();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Supervisor_Ministerio_Treinamento>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Celula para adolescentes")
            {
                modelo = new Celula_Adolescente();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Celula_Adolescente>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Celula para adultos")
            {
                modelo = new Celula_Adulto();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Celula_Adulto>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Celula para jovens")
            {
                modelo = new Celula_Jovem();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Celula_Jovem>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Celula para crianças")
            {
                modelo = new Celula_Crianca();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Celula_Crianca>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "Celula para casados")
            {
                modelo = new Celula_Casado();
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios.OfType<Celula_Casado>().ToList());
                ModificaDataGridView(modelo, tipo, Resultado);
            }

            if (comboBox1.Text == "")
            {
                if (Resultado[0] is Pessoa)
                {
                    Resultado.Clear();
                    Resultado.AddRange(listaPessoas);
                }

                if (Resultado[0] is Celula)
                {
                    Resultado.Clear();
                    Resultado.AddRange(listaCelulas);
                }

                if (Resultado[0] is Ministerio)
                {
                    Resultado.Clear();
                    Resultado.AddRange(listaMinisterios);
                }

                if (Resultado[0] is MudancaEstado)
                {
                    Resultado.Clear();
                    Resultado.AddRange(listaMudancaEstado);
                }

                if (Resultado[0] is Reuniao)
                {
                    Resultado.Clear();
                    Resultado.AddRange(listaReuniao);
                }
            }
        }

        private void btn_todos_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            // Pesquisas a  serem realizadas
            check_pesquisa_id.Enabled = true;
            check_pesquisa_id.Checked = false;
            check_pesquisa_nome.Enabled = false;
            check_pesquisa_nome.Checked = false;
            check_pesquisa_email.Enabled = false;
            check_pesquisa_email.Checked = false;
            check_pesquisa_nome_mae.Enabled = false;
            check_pesquisa_nome_mae.Checked = false;
            check_pesquisa_nome_pai.Enabled = false;
            check_pesquisa_nome_pai.Checked = false;
            check_pesquisa_data_visita.Enabled = false;
            check_pesquisa_data_visita.Checked = false;
            check_pesquisa_data_reuniao.Enabled = false;
            check_pesquisa_data_reuniao.Checked = false;
            check_pesquisa_ano_batismo.Enabled = false;
            check_pesquisa_ano_batismo.Checked = false;
            check_horario_celula.Enabled = false;
            check_horario_celula.Checked = false;
            check_horario_reuniao.Enabled = false;
            check_horario_reuniao.Checked = false;
            check_horario_final_reuniao.Enabled = false;
            check_horario_final_reuniao.Checked = false;
            check_data_mudanca_estado.Enabled = false;
            check_data_mudanca_estado.Checked = false;

            if (Resultado[0] is Pessoa)
            {
                Resultado.Clear();
                Resultado.AddRange(listaPessoas);
            }

            if (Resultado[0] is Celula)
            {
                Resultado.Clear();
                Resultado.AddRange(listaCelulas);
            }

            if (Resultado[0] is Ministerio)
            {
                Resultado.Clear();
                Resultado.AddRange(listaMinisterios);
            }

            if (Resultado[0] is MudancaEstado)
            {
                Resultado.Clear();
                Resultado.AddRange(listaMudancaEstado);
            }

            if (Resultado[0] is Reuniao)
            {
                Resultado.Clear();
                Resultado.AddRange(listaReuniao);
            }
        }
    }
}
