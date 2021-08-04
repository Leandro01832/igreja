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
            Foto c = new Foto((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            c.MdiParent = this.MdiParent;
            c.Show();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if (modelo is Crianca || modelo is CriancaLgpd)
            {
                CadastroCrianca c = new CadastroCrianca((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Visitante || modelo is VisitanteLgpd)
            {
                CadastroVisitante c =
                new CadastroVisitante((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Aclamacao || modelo is Membro_AclamacaoLgpd)
            {
                CadastroMembroAclamacao c =
                new CadastroMembroAclamacao((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Batismo || modelo is Membro_BatismoLgpd)
            {
                CadastroMembroBatismo c =
                new CadastroMembroBatismo((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Reconciliacao || modelo is Membro_ReconciliacaoLgpd)
            {
                CadastroMembroReconciliacao c =
                new CadastroMembroReconciliacao((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Transferencia || modelo is Membro_TransferenciaLgpd)
            {
                CadastroMembroTransferencia c =
                new CadastroMembroTransferencia((Pessoa)modelo, condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
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
                    p.Ministerios.Add(new MinisterioCelula { MinisterioId= item, CelulaId=p.Id  });

                    foreach (var item in numeros)
                     if (!arrNum.Contains(item))
                     p.Ministerios.Remove(p.Ministerios.First(i => i.MinisterioId == item));
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

                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                            p.Pessoas.Remove(p.Pessoas.First(i => i.PessoaId == item));
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

                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                            p.Celulas.Remove(p.Celulas.First(i => i.CelulaId == item));
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

                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                            p.Ministerios.Remove(p.Ministerios.First(i => i.MinisterioId == item));
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

                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                            p.Reuniao.Remove(p.Reuniao.First(i => i.ReuniaoId == item));
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

                    foreach (var item in numeros)
                        if (!arrNum.Contains(item))
                            p.Pessoas.Remove(p.Pessoas.First(i => i.PessoaId == item));
                }
            }

            modelo.alterar(modelo.Id);
            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            var id = modelo.Id;

            if (modelo is Visitante) modelo = new Visitante(id);
            if (modelo is Crianca) modelo = new Crianca(id);
            if (modelo is Membro_Aclamacao) modelo = new Membro_Aclamacao(id);
            if (modelo is Membro_Batismo) modelo = new Membro_Batismo(id);
            if (modelo is Membro_Reconciliacao) modelo = new Membro_Reconciliacao(id);
            if (modelo is Membro_Transferencia) modelo = new Membro_Transferencia(id);
            if (modelo is VisitanteLgpd) modelo = new VisitanteLgpd(id);
            if (modelo is CriancaLgpd) modelo = new CriancaLgpd(id);
            if (modelo is Membro_AclamacaoLgpd) modelo = new Membro_AclamacaoLgpd(id);
            if (modelo is Membro_BatismoLgpd) modelo = new Membro_BatismoLgpd(id);
            if (modelo is Membro_ReconciliacaoLgpd) modelo = new Membro_ReconciliacaoLgpd(id);
            if (modelo is Membro_TransferenciaLgpd) modelo = new Membro_TransferenciaLgpd(id);

            if (modelo is Celula_Adolescente) modelo = new Celula_Adolescente(id);
            if (modelo is Celula_Adulto) modelo = new Celula_Adulto(id);
            if (modelo is Celula_Casado) modelo = new Celula_Casado(id);
            if (modelo is Celula_Jovem) modelo = new Celula_Jovem(id);
            if (modelo is Celula_Crianca) modelo = new Celula_Crianca(id);

            if (modelo is Lider_Celula) modelo = new Lider_Celula(id);
            if (modelo is Lider_Celula_Treinamento) modelo = new Lider_Celula_Treinamento(id);
            if (modelo is Lider_Ministerio) modelo = new Lider_Ministerio(id);
            if (modelo is Lider_Ministerio_Treinamento) modelo = new Lider_Ministerio_Treinamento(id);
            if (modelo is Supervisor_Celula) modelo = new Supervisor_Celula(id);
            if (modelo is Supervisor_Celula_Treinamento) modelo = new Supervisor_Celula_Treinamento(id);
            if (modelo is Supervisor_Ministerio) modelo = new Supervisor_Ministerio(id);
            if (modelo is Supervisor_Ministerio_Treinamento) modelo = new Supervisor_Ministerio_Treinamento(id);


            if (modelo is Reuniao) modelo = new Reuniao(id);
            if (modelo is MudancaEstado) modelo = new MudancaEstado(id);
            if (modelo is Historico) modelo = new Historico(id);
            if (modelo is business.classes.Chamada) modelo = new business.classes.Chamada(id);
            if (modelo is Telefone) modelo = new Telefone(id);
            if (modelo is Endereco) modelo = new Endereco(id);
            if (modelo is EnderecoCelula) modelo = new EnderecoCelula(id);
            if (modelo is MinisterioCelula) modelo = new MinisterioCelula(id);
            if (modelo is PessoaMinisterio) modelo = new PessoaMinisterio(id);
            if (modelo is ReuniaoPessoa) modelo = new ReuniaoPessoa(id);




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
                            FrmEndereco end = new FrmEndereco((PessoaDado)modelo,
                            condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                            end.MdiParent = this.MdiParent;
                            this.Close();
                            end.Show();
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
                            Contato con = new Contato((PessoaDado)modelo,
                            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            con.MdiParent = this.MdiParent;
                            this.Close();
                            con.Show();
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
                            Foto con = new Foto((PessoaDado)modelo,
                            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            con.MdiParent = this.MdiParent;
                            this.Close();
                            con.Show();
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
                            ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa((Pessoa)modelo,
                            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            con.MdiParent = this.MdiParent;
                            this.Close();
                            con.Show();
                        }

                    }

                    if (this is ReunioesMinisteriosPessoa)
                    {
                        if (ModeloNovo == null)
                        {
                            if (modelo is Crianca)
                            {
                                CadastroCrianca cc = new CadastroCrianca((PessoaDado)
                                modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cc.MdiParent = this.MdiParent;
                                this.Close();
                                cc.Show();
                            }

                            if (modelo is Visitante)
                            {
                                CadastroVisitante cv = new CadastroVisitante((PessoaDado)
                                modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cv.MdiParent = this.MdiParent;
                                this.Close();
                                cv.Show();
                            }

                            if (modelo is Membro_Aclamacao)
                            {
                                CadastroMembroAclamacao cma = new CadastroMembroAclamacao((PessoaDado)
                               modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cma.MdiParent = this.MdiParent;
                                this.Close();
                                cma.Show();
                            }

                            if (modelo is Membro_Reconciliacao)
                            {
                                CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao((PessoaDado)
                                modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cmr.MdiParent = this.MdiParent;
                                this.Close();
                                cmr.Show();
                            }

                            if (modelo is Membro_Batismo)
                            {
                                CadastroMembroBatismo cmb = new CadastroMembroBatismo((PessoaDado)
                                modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cmb.MdiParent = this.MdiParent;
                                this.Close();
                                cmb.Show();
                            }

                            if (modelo is Membro_Transferencia)
                            {
                                CadastroMembroTransferencia cmt = new CadastroMembroTransferencia((PessoaDado)
                                modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                                cmt.MdiParent = this.MdiParent;
                                this.Close();
                                cmt.Show();
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
                            FinalizarCadastroPessoa fn = new
                        FinalizarCadastroPessoa(CondicaoAtualizar, condicaoDeletar, condicaoDetalhes, ModeloVelho,
                        ModeloNovo);
                            fn.MdiParent = this.MdiParent;
                            this.Close();
                            fn.Show();
                        }
                        else
                        {
                            FinalizarCadastroPessoa fn = new
                        FinalizarCadastroPessoa((Pessoa)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
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
                        Foto con = new Foto((PessoaLgpd)modelo,
                        condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }
                    if (this is Foto)
                    {
                        ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa((PessoaLgpd)modelo,
                        condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }
                    if (this is ReunioesMinisteriosPessoa)
                    {
                        if (modelo is CriancaLgpd)
                        {
                            CadastroCrianca cc = new CadastroCrianca((PessoaLgpd)
                            modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cc.MdiParent = this.MdiParent;
                            this.Close();
                            cc.Show();
                        }

                        if (modelo is VisitanteLgpd)
                        {
                            CadastroVisitante cv = new CadastroVisitante((PessoaLgpd)
                            modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cv.MdiParent = this.MdiParent;
                            this.Close();
                            cv.Show();
                        }

                        if (modelo is Membro_AclamacaoLgpd)
                        {
                            CadastroMembroAclamacao cma = new CadastroMembroAclamacao((PessoaLgpd)
                           modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cma.MdiParent = this.MdiParent;
                            this.Close();
                            cma.Show();
                        }

                        if (modelo is Membro_ReconciliacaoLgpd)
                        {
                            CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao((PessoaLgpd)
                            modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cmr.MdiParent = this.MdiParent;
                            this.Close();
                            cmr.Show();
                        }

                        if (modelo is Membro_BatismoLgpd)
                        {
                            CadastroMembroBatismo cmb = new CadastroMembroBatismo((PessoaLgpd)
                            modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cmb.MdiParent = this.MdiParent;
                            this.Close();
                            cmb.Show();
                        }

                        if (modelo is Membro_TransferenciaLgpd)
                        {
                            CadastroMembroTransferencia cmt = new CadastroMembroTransferencia((PessoaLgpd)
                            modelo, CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            cmt.MdiParent = this.MdiParent;
                            this.Close();
                            cmt.Show();
                        }
                    }

                    if (this is CadastroCrianca || this is CadastroVisitante ||
                        this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                        this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                    {
                        FinalizarCadastroPessoa fn = new
                        FinalizarCadastroPessoa((Pessoa)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        fn.MdiParent = this.MdiParent;
                        this.Close();
                        fn.Show();

                    }
                }

            }

            if (this is FormularioCrudCelula)
            {
                if (this is DadoCelula)
                {
                    FrmEnderecoCelula end = new FrmEnderecoCelula((Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    end.MdiParent = this.MdiParent;
                    this.Close();
                    end.Show();
                }

                if (this is FrmEnderecoCelula)
                {
                    MinisteriosCelula con = new MinisteriosCelula((Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }
                if (this is MinisteriosCelula)
                {
                    FinalizarCadastro con = new FinalizarCadastro((Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    con.MdiParent = this.MdiParent;
                    this.Close();
                    con.Show();
                }
            }

            if (this is FormCrudMinisterio)
            {
                if (this is DadoMinisterio)
                {
                    PessoasCelulasMinisterio fn = new
                    PessoasCelulasMinisterio((Ministerio)modelo,
                   CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    fn.MdiParent = this.MdiParent;
                    this.Close();
                    fn.Show();
                }

                if (this is PessoasCelulasMinisterio)
                {
                    FinalizarCadastroMinisterio fn = new
                    FinalizarCadastroMinisterio((Ministerio)modelo,
                   CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    fn.MdiParent = this.MdiParent;
                    this.Close();
                    fn.Show();
                }
            }

            if (this is FormCrudReuniao)
            {
                if (this is DadoReuniao)
                {
                    PessoasReuniao frm = new PessoasReuniao(modelo,
                    condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                    frm.MdiParent = this.MdiParent;
                    this.Close();
                    frm.Show();
                }

                if (this is PessoasReuniao)
                {
                    FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(modelo,
                    condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                    frm.MdiParent = this.MdiParent;
                    this.Close();
                    frm.Show();
                }
            }

        }

    }
}
