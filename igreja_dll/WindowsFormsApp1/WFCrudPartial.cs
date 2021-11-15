using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Esboco.Fontes;
using business.classes.Fontes;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioFonte;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class WFCrud
    {
        private void DadoFoto_Click(object sender, EventArgs e)
        {
            Frm = new Foto();
            LoadForm();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if (modelo is Crianca || modelo is CriancaLgpd)
            {
                Frm = new CadastroCrianca();
                LoadForm();
            }

            if (modelo is Visitante || modelo is VisitanteLgpd)
            {
                Frm = new CadastroVisitante();
                LoadForm();
            }

            if (modelo is Membro_Aclamacao || modelo is Membro_AclamacaoLgpd)
            {
                Frm = new CadastroMembroAclamacao();
                LoadForm();
            }

            if (modelo is Membro_Batismo || modelo is Membro_BatismoLgpd)
            {
                Frm = new CadastroMembroBatismo();
                LoadForm();
            }

            if (modelo is Membro_Reconciliacao || modelo is Membro_ReconciliacaoLgpd)
            {
                Frm = new CadastroMembroReconciliacao();
                LoadForm();
            }

            if (modelo is Membro_Transferencia || modelo is Membro_TransferenciaLgpd)
            {
                Frm = new CadastroMembroTransferencia();
                LoadForm();
            }

        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            List<modelocrud> remover = new List<modelocrud>();

            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                foreach (var item in p.Ministerios)
                {
                    item.CelulaId = modelo.Id;
                    item.salvar();
                }

            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                foreach (var item in p.Pessoas)
                {
                    item.MinisterioId = modelo.Id;
                    item.salvar();
                }

                foreach (var item in p.Celulas)
                {
                    item.MinisterioId = modelo.Id;
                    item.salvar();
                }
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                foreach (var item in p.Ministerios)
                    item.alterar(item.Id);

                foreach (var item in p.Reuniao)
                    item.alterar(item.Id);

            }

            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                foreach (var item in p.Pessoas)
                    item.alterar(item.Id);
            }

            try
            {
                modelo.alterar(modelo.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(modelo.exibirMensagemErro(ex, 1));
                return;
            }


            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            var id = modelo.Id;

            if (modelo is Visitante) modelo = new Visitante();
            if (modelo is Crianca) modelo = new Crianca();
            if (modelo is Membro_Aclamacao) modelo = new Membro_Aclamacao();
            if (modelo is Membro_Batismo) modelo = new Membro_Batismo();
            if (modelo is Membro_Reconciliacao) modelo = new Membro_Reconciliacao();
            if (modelo is Membro_Transferencia) modelo = new Membro_Transferencia();
            if (modelo is VisitanteLgpd) modelo = new VisitanteLgpd();
            if (modelo is CriancaLgpd) modelo = new CriancaLgpd();
            if (modelo is Membro_AclamacaoLgpd) modelo = new Membro_AclamacaoLgpd();
            if (modelo is Membro_BatismoLgpd) modelo = new Membro_BatismoLgpd();
            if (modelo is Membro_ReconciliacaoLgpd) modelo = new Membro_ReconciliacaoLgpd();
            if (modelo is Membro_TransferenciaLgpd) modelo = new Membro_TransferenciaLgpd();

            if (modelo is Celula_Adolescente) modelo = new Celula_Adolescente();
            if (modelo is Celula_Adulto) modelo = new Celula_Adulto();
            if (modelo is Celula_Casado) modelo = new Celula_Casado();
            if (modelo is Celula_Jovem) modelo = new Celula_Jovem();
            if (modelo is Celula_Crianca) modelo = new Celula_Crianca();

            if (modelo is Lider_Celula) modelo = new Lider_Celula();
            if (modelo is Lider_Celula_Treinamento) modelo = new Lider_Celula_Treinamento();
            if (modelo is Lider_Ministerio) modelo = new Lider_Ministerio();
            if (modelo is Lider_Ministerio_Treinamento) modelo = new Lider_Ministerio_Treinamento();
            if (modelo is Supervisor_Celula) modelo = new Supervisor_Celula();
            if (modelo is Supervisor_Celula_Treinamento) modelo = new Supervisor_Celula_Treinamento();
            if (modelo is Supervisor_Ministerio) modelo = new Supervisor_Ministerio();
            if (modelo is Supervisor_Ministerio_Treinamento) modelo = new Supervisor_Ministerio_Treinamento();


            if (modelo is Reuniao) modelo = new Reuniao();
            if (modelo is MudancaEstado) modelo = new MudancaEstado();
            if (modelo is Historico) modelo = new Historico();
            if (modelo is business.classes.Chamada) modelo = new business.classes.Chamada();
            if (modelo is Telefone) modelo = new Telefone();
            if (modelo is Endereco) modelo = new Endereco();
            if (modelo is EnderecoCelula) modelo = new EnderecoCelula();
            if (modelo is MinisterioCelula) modelo = new MinisterioCelula();
            if (modelo is PessoaMinisterio) modelo = new PessoaMinisterio();
            if (modelo is ReuniaoPessoa) modelo = new ReuniaoPessoa();




            if (!modelo.recuperar(id))
            {
                MessageBox.Show("Você já apagou este registro");
                return;
            }

            modelo.excluir(id);
            modelocrud.Modelos.Remove(modelocrud.Modelos.OfType<Pessoa>().ToList().First(i => i.Id == id));
            MessageBox.Show("Informação removida do banco de dados com sucesso.");
        }

        private void Proximo_Click(object sender, EventArgs e)
        {

            if (this is FrmCadastrarMensagem)
            {
                Frm = new FrmMensagem();
                LoadForm();
            }

            if (this is FrmDadoFonte)
            {
                if (modelo is Versiculo)
                    Frm = new FrmVersiculo();

                if (modelo is CanalTv)
                    Frm = new FrmCanalTv();

                if (modelo is Livro)
                    Frm = new FrmLivro();

                LoadForm();
            }

            if (this is FrmVersiculo || this is FrmCanalTv || this is FrmLivro)
            {
                Frm = new FrmFonte();
                LoadForm();
            }


            if (modelo is PessoaDado || ModeloNovo is PessoaDado)
            {
                if (this is DadoPessoal)
                {
                    if (ModeloNovo != null)
                    {
                        FrmEndereco end = new FrmEndereco(condicaoAtualizar, condicaoDeletar, CondicaoDetalhes,
                        ModeloVelho, ModeloNovo);
                        end.MdiParent = this.MdiParent;
                        this.Close();
                        end.Show();
                    }
                    else
                    {
                        Frm = new FrmEndereco();
                        LoadForm();
                    }
                }

                if (this is FrmEndereco)
                {
                    if (ModeloNovo != null)
                    {
                        Contato con = new Contato(condicaoAtualizar, condicaoDeletar, condicaoDetalhes,
                        ModeloVelho, ModeloNovo);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }
                    else
                    {
                        Frm = new Contato();
                        LoadForm();
                    }

                }

                if (this is Contato)
                {
                    if (ModeloNovo != null)
                    {
                        Foto con = new Foto(condicaoAtualizar, condicaoDeletar, condicaoDetalhes,
                        ModeloVelho, ModeloNovo);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }
                    else
                    {
                        Frm = new Foto();
                        LoadForm();
                    }

                }

                if (this is Foto)
                {
                    if (ModeloNovo != null)
                    {
                        ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa
                        (condicaoAtualizar, condicaoDeletar, condicaoDetalhes,
                        ModeloVelho, ModeloNovo);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }
                    else
                    {
                        Frm = new ReunioesMinisteriosPessoa();
                        LoadForm();
                    }

                }

                if (this is ReunioesMinisteriosPessoa)
                {
                    if (ModeloNovo == null)
                    {
                        if (modelo is Crianca)
                        {
                            CadastroCrianca cc = new CadastroCrianca();
                            LoadForm();
                        }

                        if (modelo is Visitante)
                        {
                            CadastroVisitante cv = new CadastroVisitante();
                            LoadForm();
                        }

                        if (modelo is Membro_Aclamacao)
                        {
                            CadastroMembroAclamacao cma = new CadastroMembroAclamacao();
                            LoadForm();
                        }

                        if (modelo is Membro_Reconciliacao)
                        {
                            CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao();
                            LoadForm();
                        }

                        if (modelo is Membro_Batismo)
                        {
                            CadastroMembroBatismo cmb = new CadastroMembroBatismo();
                            LoadForm();
                        }

                        if (modelo is Membro_Transferencia)
                        {
                            CadastroMembroTransferencia cmt = new CadastroMembroTransferencia();
                            LoadForm();
                        }
                    }
                    else
                    {
                        if (ModeloNovo is Crianca)
                        {
                            CadastroCrianca cc = new CadastroCrianca(condicaoAtualizar, condicaoDeletar,
                                condicaoDetalhes, modeloVelho, ModeloNovo);
                            cc.MdiParent = this.MdiParent;
                            this.Close();
                            cc.Show();
                        }

                        if (ModeloNovo is Visitante)
                        {
                            CadastroVisitante cv = new CadastroVisitante(condicaoAtualizar, condicaoDeletar,
                                condicaoDetalhes, modeloVelho, ModeloNovo);
                            cv.MdiParent = this.MdiParent;
                            this.Close();
                            cv.Show();
                        }

                        if (ModeloNovo is Membro_Aclamacao)
                        {
                            CadastroMembroAclamacao cma = new CadastroMembroAclamacao(CondicaoAtualizar,
                                condicaoDeletar, condicaoDetalhes, modeloVelho, ModeloNovo);
                            cma.MdiParent = this.MdiParent;
                            this.Close();
                            cma.Show();
                        }

                        if (ModeloNovo is Membro_Reconciliacao)
                        {
                            CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao(CondicaoAtualizar,
                                condicaoDeletar, condicaoDetalhes, modeloVelho, ModeloNovo);
                            cmr.MdiParent = this.MdiParent;
                            this.Close();
                            cmr.Show();
                        }

                        if (ModeloNovo is Membro_Batismo)
                        {
                            CadastroMembroBatismo cmb = new CadastroMembroBatismo(CondicaoAtualizar,
                                condicaoDeletar, condicaoDetalhes, modeloVelho, ModeloNovo);
                            cmb.MdiParent = this.MdiParent;
                            this.Close();
                            cmb.Show();
                        }

                        if (ModeloNovo is Membro_Transferencia)
                        {
                            CadastroMembroTransferencia cmt = new CadastroMembroTransferencia(CondicaoAtualizar,
                                condicaoDeletar, condicaoDetalhes, modeloVelho, ModeloNovo);
                            cmt.MdiParent = this.MdiParent;
                            this.Close();
                            cmt.Show();
                        }
                    }
                }

                if (this is CadastroCrianca || this is CadastroVisitante ||
                    this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                    this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                {
                    if (ModeloNovo != null)
                    {
                        FrmPessoa fn = new
                    FrmPessoa(CondicaoAtualizar, condicaoDeletar, condicaoDetalhes, ModeloVelho,
                    ModeloNovo);
                        fn.MdiParent = this.MdiParent;
                        this.Close();
                        fn.Show();
                    }
                    else
                    {
                        FrmPessoa fn = new FrmPessoa();
                        fn.MdiParent = this.MdiParent;
                        this.Close();
                        fn.Show();
                    }
                }
            }

            if (modelo is PessoaLgpd || ModeloNovo is PessoaLgpd)
            {
                if (this is DadoPessoalLgpd)
                {
                    Frm = new Foto();
                    LoadForm();
                }
                if (this is Foto)
                {
                    Frm = new ReunioesMinisteriosPessoa();
                    LoadForm();
                }
                if (this is ReunioesMinisteriosPessoa)
                {
                    if (modelo is CriancaLgpd)
                        Frm = new CadastroCrianca();

                    if (modelo is VisitanteLgpd)
                        Frm = new CadastroVisitante();

                    if (modelo is Membro_AclamacaoLgpd)
                        Frm = new CadastroMembroAclamacao();

                    if (modelo is Membro_ReconciliacaoLgpd)
                        Frm = new CadastroMembroReconciliacao();

                    if (modelo is Membro_BatismoLgpd)
                        Frm = new CadastroMembroBatismo();

                    if (modelo is Membro_TransferenciaLgpd)
                        Frm = new CadastroMembroTransferencia();

                    LoadForm();
                }

                if (this is CadastroCrianca || this is CadastroVisitante ||
                    this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                    this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                {
                    Frm = new FrmPessoa();
                    LoadForm();

                }
            }




            if (this is DadoCelula)
            {
                Frm = new FrmEnderecoCelula();
                LoadForm();
            }

            if (this is FrmEnderecoCelula)
            {
                Frm = new MinisteriosCelula();
                LoadForm();
            }
            if (this is MinisteriosCelula)
            {
                Frm = new FrmCelula();
                LoadForm();
            }



            if (this is DadoMinisterio)
            {
                Frm = new PessoasCelulasMinisterio();
                LoadForm();
            }

            if (this is PessoasCelulasMinisterio)
            {
                Frm = new FrmMinisterio();
                LoadForm();
            }



            if (this is DadoReuniao)
            {
                Frm = new PessoasReuniao();
                LoadForm();
            }

            if (this is PessoasReuniao)
            {
                Frm = new FrmReuniao();
                LoadForm();
            }


            this.Close();
        }

    }
}
