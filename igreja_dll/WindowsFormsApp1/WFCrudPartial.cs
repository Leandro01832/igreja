using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa;
using WindowsFormsApp1.Formulario.Reuniao;
using Endereco = WindowsFormsApp1.Formulario.Pessoa.Endereco;

namespace WindowsFormsApp1
{
  public partial  class  WFCrud
    {
        private void DadoFoto_Click(object sender, EventArgs e)
        {
            Foto c = new Foto((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            c.MdiParent = this.MdiParent;
            c.Show();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if (modelo is Crianca || modelo is CriancaLgpd)
            {
                CadastroCrianca c = new CadastroCrianca((Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Visitante || modelo is VisitanteLgpd)
            {
                CadastroVisitante c =
                new CadastroVisitante((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Aclamacao || modelo is Membro_AclamacaoLgpd)
            {
                CadastroMembroAclamacao c =
                new CadastroMembroAclamacao((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Batismo || modelo is Membro_BatismoLgpd)
            {
                CadastroMembroBatismo c =
                new CadastroMembroBatismo((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Reconciliacao || modelo is Membro_ReconciliacaoLgpd)
            {
                CadastroMembroReconciliacao c =
                new CadastroMembroReconciliacao((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Transferencia || modelo is Membro_TransferenciaLgpd)
            {
                CadastroMembroTransferencia c =
                new CadastroMembroTransferencia((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
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
                    var listaMinisterio = Ministerio.recuperarTodosMinisterios();
                    var arr = AddNaListaCelulaMinisterios.Replace(" ", "").Split(',');
                    foreach (var item in arr)
                    {
                        try
                        {
                            if (listaMinisterio.FirstOrDefault(i => i.Id == int.Parse(item)) == null)
                                AddNaListaCelulaMinisterios.Replace(item, "");
                        }
                        catch { }
                    }
                    p.RemoverDaLista("MinisterioCelula", p, new Lider_Celula(), AddNaListaCelulaMinisterios);
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.RemoverDaLista("PessoaMinisterio", p, new Visitante(), AddNaListaMinisterioPessoas);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.RemoverDaLista("MinisterioCelula", p, new Celula_Adolescente(), AddNaListaMinisterioCelulas);
            }

            if (modelo is business.classes.Abstrato.Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.RemoverDaLista("PessoaMinisterio", p, new Lider_Celula(), AddNaListaPessoaMinsterios);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.RemoverDaLista("ReuniaoPessoa", p, new Reuniao(), AddNaListaPessoaReunioes);

            }

            if (modelo is business.classes.Reuniao)
            {
                var p = (business.classes.Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.RemoverDaLista("ReuniaoPessoa", p, new Visitante(), AddNaListaReuniaoPessoas);

            }

            modelo.alterar(modelo.Id);
            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            modelo.excluir(modelo.Id);
            MessageBox.Show("Informação removida do banco de dados com sucesso.");
        }

        private void Proximo_Click(object sender, EventArgs e)
        {
            if (this is FormCrudPessoa)
            {
                if (modelo is PessoaDado)
                {
                    if (this is DadoPessoal)
                    {
                        if(ModeloNovo != null)
                        {
                            Endereco end = new Endereco(condicaoAtualizar, condicaoDeletar, CondicaoDetalhes,
                            ModeloVelho, ModeloNovo);
                            end.MdiParent = this.MdiParent;
                            this.Close();
                            end.Show();
                        }
                        else
                        {
                            Endereco end = new Endereco((PessoaDado)modelo,
                            condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                            end.MdiParent = this.MdiParent;
                            this.Close();
                            end.Show();
                        } 

                       
                    }

                    if (this is Endereco)
                    {
                        if(ModeloNovo != null)
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
                        if(ModeloNovo == null)
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
                        if(ModeloNovo == null)
                        {
                            ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa((PessoaDado)modelo,
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
                                CadastroMembroAclamacao cma = new CadastroMembroAclamacao( CondicaoAtualizar,
                                    condicaoDeletar, condicaoDetalhes, modeloVelho, ModeloNovo);
                                cma.MdiParent = this.MdiParent;
                                this.Close();
                                cma.Show();
                            }

                            if (ModeloNovo is Membro_Reconciliacao)
                            {
                                CadastroMembroReconciliacao cmr = new CadastroMembroReconciliacao( CondicaoAtualizar,
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
                                CadastroMembroTransferencia cmt = new CadastroMembroTransferencia( CondicaoAtualizar,
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
                        if(ModeloNovo != null)
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
                        FinalizarCadastroPessoa((PessoaDado)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                            fn.MdiParent = this.MdiParent;
                            this.Close();
                            fn.Show();
                        }
                        

                    }
                }

                if (modelo is PessoaLgpd)
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
                        FinalizarCadastroPessoa((PessoaLgpd)modelo,
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
                    EnderecoCelula end = new EnderecoCelula((Celula)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                    end.MdiParent = this.MdiParent;
                    this.Close();
                    end.Show();
                }

                if (this is EnderecoCelula)
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

            if(this is FormCrudReuniao)
            {
                if(this is DadoReuniao)
                {
                    PessoasReuniao frm = new PessoasReuniao(modelo,
                    condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                    frm.MdiParent = this.MdiParent;
                    this.Close();
                    frm.Show();
                }

                if(this is PessoasReuniao)
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
