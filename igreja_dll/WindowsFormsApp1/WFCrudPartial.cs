using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
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
            Foto c = new Foto();
            LoadFormCrud();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if (modelo is Crianca || modelo is CriancaLgpd)
            {
                frm = new CadastroCrianca();
                LoadFormCrud();
            }

            if (modelo is Visitante || modelo is VisitanteLgpd)
            {
                frm =  new CadastroVisitante();
                LoadFormCrud();
            }

            if (modelo is Membro_Aclamacao || modelo is Membro_AclamacaoLgpd)
            {
                frm = new CadastroMembroAclamacao();
                LoadFormCrud();
            }

            if (modelo is Membro_Batismo || modelo is Membro_BatismoLgpd)
            {
                frm =  new CadastroMembroBatismo();
                LoadFormCrud();
            }

            if (modelo is Membro_Reconciliacao || modelo is Membro_ReconciliacaoLgpd)
            {
                frm =  new CadastroMembroReconciliacao();
                LoadFormCrud();
            }

            if (modelo is Membro_Transferencia || modelo is Membro_TransferenciaLgpd)
            {
                frm = new CadastroMembroTransferencia();
                LoadFormCrud();
            }

        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            List<modelocrud> remover = new List<modelocrud>();

            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (!string.IsNullOrEmpty(AddNaListaCelulaMinisterios))
                {
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Ministerios.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Ministerios[i].MinisterioId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Ministerios.Add(new MinisterioCelula { MinisterioId = item, CelulaId = p.Id });
                    p.Ministerios = p.Ministerios;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Ministerios.Remove(p.Ministerios.First(i => i.MinisterioId == item));
                            remover.Add(p.Ministerios.First(i => i.MinisterioId == item));
                            p.Ministerios = p.Ministerios;
                        }
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                {
                    var arr = AddNaListaMinisterioPessoas.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Pessoas.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Pessoas[i].PessoaId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Pessoas.Add(new PessoaMinisterio { MinisterioId = p.Id, PessoaId = item });
                    p.Pessoas = p.Pessoas;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Pessoas.Remove(p.Pessoas.First(i => i.PessoaId == item));
                            remover.Add(p.Pessoas.First(i => i.PessoaId == item));
                            p.Pessoas = p.Pessoas;
                        }
                }

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                {
                    var arr = AddNaListaMinisterioCelulas.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Pessoas.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Celulas[i].CelulaId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Celulas.Add(new MinisterioCelula { MinisterioId = p.Id, CelulaId = item });
                    p.Celulas = p.Celulas;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Celulas.Remove(p.Celulas.First(i => i.CelulaId == item));
                            remover.Add(p.Celulas.First(i => i.CelulaId == item));
                            p.Celulas = p.Celulas;
                        }
                }
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                {
                    var arr = AddNaListaPessoaMinsterios.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Ministerios.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Ministerios[i].MinisterioId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Ministerios.Add(new PessoaMinisterio { MinisterioId = item, PessoaId = p.Id });
                    p.Ministerios = p.Ministerios;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Ministerios.Remove(p.Ministerios.First(i => i.MinisterioId == item));
                            remover.Add(p.Ministerios.First(i => i.MinisterioId == item));
                            p.Ministerios = p.Ministerios;
                        }
                }

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                {
                    var arr = AddNaListaPessoaReunioes.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Reuniao.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Reuniao[i].ReuniaoId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Reuniao.Add(new ReuniaoPessoa { ReuniaoId = item, PessoaId = p.Id });
                    p.Reuniao = p.Reuniao;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Reuniao.Remove(p.Reuniao.First(i => i.ReuniaoId == item));
                            remover.Add(p.Reuniao.First(i => i.ReuniaoId == item));
                            p.Reuniao = p.Reuniao;
                        }
                }

            }

            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                {
                    var arr = AddNaListaReuniaoPessoas.Replace(" ", "").Split(',');
                    int[] arrNum = new int[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        arrNum[i] = int.Parse(arr[i]);
                    int[] numeros = new int[p.Pessoas.Count];
                    for (int i = 0; i < numeros.Length; i++)
                        numeros[i] = p.Pessoas[i].PessoaId;

                    foreach (var item in arrNum)
                        if (!numeros.Contains(item))
                            p.Pessoas.Add(new ReuniaoPessoa { ReuniaoId = p.Id, PessoaId = item });
                    p.Pessoas = p.Pessoas;
                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                        {
                            p.Pessoas.Remove(p.Pessoas.First(i => i.PessoaId == item));
                            remover.Add(p.Pessoas.First(i => i.PessoaId == item));
                            p.Pessoas = p.Pessoas;
                        }
                }
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

            foreach (var item in remover)
                item.excluir(item.Id);

            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                if (p.Ministerios != null)
                    foreach (var item in p.Ministerios)
                        item.salvar();
            }
            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (p.Pessoas != null)
                    foreach (var item in p.Pessoas)
                        item.salvar();
                if (p.Celulas != null)
                    foreach (var item in p.Celulas)
                        item.salvar();
            }
            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (p.Ministerios != null)
                    foreach (var item in p.Ministerios)
                        item.salvar();
                if (p.Reuniao != null)
                    foreach (var item in p.Reuniao)
                        item.salvar();
            }
            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                if (p.Pessoas != null)
                    foreach (var item in p.Pessoas)
                        item.salvar();
            }
            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            var id = modelo.Id;

            if (modelo is Visitante) modelo = new Visitante                              ();
            if (modelo is Crianca) modelo = new Crianca                                  ();
            if (modelo is Membro_Aclamacao) modelo = new Membro_Aclamacao                ();
            if (modelo is Membro_Batismo) modelo = new Membro_Batismo                    ();
            if (modelo is Membro_Reconciliacao) modelo = new Membro_Reconciliacao        ();
            if (modelo is Membro_Transferencia) modelo = new Membro_Transferencia        ();
            if (modelo is VisitanteLgpd) modelo = new VisitanteLgpd                      ();
            if (modelo is CriancaLgpd) modelo = new CriancaLgpd                          ();
            if (modelo is Membro_AclamacaoLgpd) modelo = new Membro_AclamacaoLgpd        ();
            if (modelo is Membro_BatismoLgpd) modelo = new Membro_BatismoLgpd            ();
            if (modelo is Membro_ReconciliacaoLgpd) modelo = new Membro_ReconciliacaoLgpd();
            if (modelo is Membro_TransferenciaLgpd) modelo = new Membro_TransferenciaLgpd();

            if (modelo is Celula_Adolescente) modelo = new Celula_Adolescente();
            if (modelo is Celula_Adulto) modelo = new Celula_Adulto          ();
            if (modelo is Celula_Casado) modelo = new Celula_Casado          ();
            if (modelo is Celula_Jovem) modelo = new Celula_Jovem            ();
            if (modelo is Celula_Crianca) modelo = new Celula_Crianca        ();

            if (modelo is Lider_Celula) modelo = new Lider_Celula                                          ();
            if (modelo is Lider_Celula_Treinamento) modelo = new Lider_Celula_Treinamento                  ();
            if (modelo is Lider_Ministerio) modelo = new Lider_Ministerio                                  ();
            if (modelo is Lider_Ministerio_Treinamento) modelo = new Lider_Ministerio_Treinamento          ();
            if (modelo is Supervisor_Celula) modelo = new Supervisor_Celula                                ();
            if (modelo is Supervisor_Celula_Treinamento) modelo = new Supervisor_Celula_Treinamento        ();
            if (modelo is Supervisor_Ministerio) modelo = new Supervisor_Ministerio                        ();
            if (modelo is Supervisor_Ministerio_Treinamento) modelo = new Supervisor_Ministerio_Treinamento();


            if (modelo is Reuniao) modelo = new Reuniao                                  ();
            if (modelo is MudancaEstado) modelo = new MudancaEstado                      ();
            if (modelo is Historico) modelo = new Historico                              ();
            if (modelo is business.classes.Chamada) modelo = new business.classes.Chamada();
            if (modelo is Telefone) modelo = new Telefone                                ();
            if (modelo is Endereco) modelo = new Endereco                                ();
            if (modelo is EnderecoCelula) modelo = new EnderecoCelula                    ();
            if (modelo is MinisterioCelula) modelo = new MinisterioCelula                ();
            if (modelo is PessoaMinisterio) modelo = new PessoaMinisterio                ();
            if (modelo is ReuniaoPessoa) modelo = new ReuniaoPessoa                      ();




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
            if (this is FormCrudPessoa)
            {
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
                            frm = new FrmEndereco();
                            LoadFormCrud();
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
                            frm = new Contato();
                            LoadFormCrud();
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
                            frm = new Foto();
                            LoadFormCrud();
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
                            frm = new ReunioesMinisteriosPessoa();
                            LoadFormCrud();
                        }

                    }

                    if (this is ReunioesMinisteriosPessoa)
                    {
                        if (ModeloNovo == null)
                        {
                            if (modelo is Crianca)
                            {
                                CadastroCrianca cc = new CadastroCrianca();
                                LoadFormCrud();
                            }

                            if (modelo is Visitante)
                            {
                                CadastroVisitante cv = new CadastroVisitante();
                                LoadFormCrud();
                            }

                            if (modelo is Membro_Aclamacao)
                            {
                                CadastroMembroAclamacao cma = new CadastroMembroAclamacao();
                                LoadFormCrud();
                            }

                            if (modelo is Membro_Reconciliacao)
                            {
                                CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao();
                                LoadFormCrud();
                            }

                            if (modelo is Membro_Batismo)
                            {
                                CadastroMembroBatismo cmb = new CadastroMembroBatismo();
                                LoadFormCrud();
                            }

                            if (modelo is Membro_Transferencia)
                            {
                                CadastroMembroTransferencia cmt = new CadastroMembroTransferencia();
                                LoadFormCrud();
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
                            FormPessoa fn = new
                        FormPessoa(CondicaoAtualizar, condicaoDeletar, condicaoDetalhes, ModeloVelho,
                        ModeloNovo);
                            fn.MdiParent = this.MdiParent;
                            this.Close();
                            fn.Show();
                        }
                        else
                        {
                            FormPessoa fn = new  FormPessoa();
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
                        Foto con = new Foto();
                        LoadFormCrud();
                    }
                    if (this is Foto)
                    {
                        frm = new ReunioesMinisteriosPessoa();
                        LoadFormCrud();
                    }
                    if (this is ReunioesMinisteriosPessoa)
                    {
                        if (modelo is CriancaLgpd)
                        {
                            frm = new CadastroCrianca();
                            LoadFormCrud();
                        }

                        if (modelo is VisitanteLgpd)
                        {
                            frm = new CadastroVisitante();
                            LoadFormCrud();
                        }

                        if (modelo is Membro_AclamacaoLgpd)
                        {
                            frm = new CadastroMembroAclamacao();
                            LoadFormCrud();
                        }

                        if (modelo is Membro_ReconciliacaoLgpd)
                        {
                            frm = new CadastroMembroReconciliacao();
                            LoadFormCrud();
                        }

                        if (modelo is Membro_BatismoLgpd)
                        {
                            frm = new CadastroMembroBatismo();
                            LoadFormCrud();
                        }

                        if (modelo is Membro_TransferenciaLgpd)
                        {
                            frm = new CadastroMembroTransferencia();
                            LoadFormCrud();
                        }
                    }

                    if (this is CadastroCrianca || this is CadastroVisitante ||
                        this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                        this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                    {
                        frm = new FormPessoa();
                        LoadFormCrud();

                    }
                }

            }

            if (this is FormularioCrudCelula)
            {
                if (this is DadoCelula)
                {
                    frm = new FrmEnderecoCelula();
                    LoadFormCrud();
                }

                if (this is FrmEnderecoCelula)
                {
                    frm = new MinisteriosCelula();
                    LoadFormCrud();
                }
                if (this is MinisteriosCelula)
                {
                    frm = new FrmCelula();
                    LoadFormCrud();
                }
            }

            if (this is FormCrudMinisterio)
            {
                if (this is DadoMinisterio)
                {
                    frm = new PessoasCelulasMinisterio();
                    LoadFormCrud();
                }

                if (this is PessoasCelulasMinisterio)
                {
                    frm = new FrmMinisterio();
                    LoadFormCrud();
                }
            }

            if (this is FormCrudReuniao)
            {
                if (this is DadoReuniao)
                {
                    frm = new PessoasReuniao();
                    LoadFormCrud();
                }

                if (this is PessoasReuniao)
                {
                    frm = new FrmReuniao();
                    LoadFormCrud();
                }
            }

        }

    }
}
