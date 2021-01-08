using business.classes.Abstrato;
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
            if (modelo is Crianca)
            {
                CadastroCrianca c = new CadastroCrianca((Pessoa)modelo, condicaoAtualizar,
                condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Visitante)
            {
                CadastroVisitante c =
                new CadastroVisitante((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Aclamacao)
            {
                CadastroMembroAclamacao c =
                new CadastroMembroAclamacao((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Batismo)
            {
                CadastroMembroBatismo c =
                new CadastroMembroBatismo((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Reconciliacao)
            {
                CadastroMembroReconciliacao c =
                new CadastroMembroReconciliacao((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                c.MdiParent = this.MdiParent;
                c.Show();
            }

            if (modelo is Membro_Transferencia)
            {
                CadastroMembroTransferencia c =
                new CadastroMembroTransferencia((Pessoa)modelo, condicaoAtualizar, condicaoDeletar, condicaoDetalhes);

                c.MdiParent = this.MdiParent;
                c.Show();
            }

        }

        private void DadoCelula_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula((Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoEnderecoCelula_Click(object sender, EventArgs e)
        {
            EnderecoCelula dc = new EnderecoCelula((Celula)modelo, condicaoDeletar,
            condicaoAtualizar, condicaoDetalhes);
            dc.MdiParent = this.MdiParent;
            dc.Show();
        }

        private void DadoCelulaMinisterio_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoCelulaPessoas_Click(object sender, EventArgs e)
        {
            MinisteriosCelula mt = new MinisteriosCelula((Celula)modelo,
            condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            mt.MdiParent = this.MdiParent;
            mt.Show();
        }

        private void DadoMinisterio_Click(object sender, EventArgs e)
        {
            DadoMinisterio pcm = new DadoMinisterio((Ministerio)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinisterioPessoas_Click(object sender, EventArgs e)
        {
            PessoasCelulasMinisterio pcm = new PessoasCelulasMinisterio((Ministerio)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            pcm.MdiParent = this.MdiParent;
            pcm.Show();
        }

        private void DadoMinistro_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DadoMinisterioPessoas_Click1(object sender, EventArgs e)
        {
            ReunioesMinisteriosPessoa rmp = new ReunioesMinisteriosPessoa((PessoaDado)modelo
            , condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
            rmp.MdiParent = this.MdiParent;
            rmp.Show();
        }

        private void DadoContato_Click(object sender, EventArgs e)
        {
            Contato dp = new Contato((PessoaDado)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoEnderecoPessoa_Click(object sender, EventArgs e)
        {
            Endereco dp = new Endereco((PessoaDado)modelo,
            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void DadoPessoal_Click(object sender, EventArgs e)
        {
            if (modelo is PessoaDado)
            {
                DadoPessoal dp = new DadoPessoal((PessoaDado)modelo,
                condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }
            if (modelo is PessoaLgpd)
            {
                DadoPessoalLgpd dp = new DadoPessoalLgpd((PessoaLgpd)modelo,
               condicaoDeletar, condicaoAtualizar, condicaoDetalhes);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }

        private void FinalizarCadastro_Click(object sender, EventArgs e)
        {
            FinalizarCadastro.Enabled = false;
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
                    p.AdicionarNaLista("MinisterioCelula", "Celula", "Ministerio", AddNaListaCelulaMinisterios);
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.AdicionarNaLista("PessoaMinisterio", "Ministerio", "Pessoa", AddNaListaMinisterioPessoas);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.AdicionarNaLista("MinisterioCelula", "Ministerio", "Celula", AddNaListaMinisterioCelulas);
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.AdicionarNaLista("PessoaMinisterio", "Pessoa", "Ministerio", AddNaListaPessoaMinsterios);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.AdicionarNaLista("ReuniaoPessoa", "Pessoa", "Reuniao", AddNaListaPessoaReunioes);

            }

            if (modelo is business.classes.Reuniao)
            {
                var p = (business.classes.Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.AdicionarNaLista("ReuniaoPessoa", "Reuniao", "Pessoa", AddNaListaReuniaoPessoas);

            }

            modelo.salvar();

            MessageBox.Show("Cadastro realiado com sucesso.");
            this.Close();
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
                    p.RemoverDaLista("MinisterioCelula", "Celula", "Ministerio", AddNaListaCelulaMinisterios, modelo.Id);
                }
            }

            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                if (!string.IsNullOrEmpty(AddNaListaMinisterioPessoas))
                    p.RemoverDaLista("PessoaMinisterio", "Ministerio", "Pessoa", AddNaListaMinisterioPessoas, modelo.Id);

                if (!string.IsNullOrEmpty(AddNaListaMinisterioCelulas))
                    p.RemoverDaLista("MinisterioCelula", "Ministerio", "Celula", AddNaListaMinisterioCelulas, modelo.Id);
            }

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                if (!string.IsNullOrEmpty(AddNaListaPessoaMinsterios))
                    p.RemoverDaLista("PessoaMinisterio", "Pessoa", "Ministerio", AddNaListaPessoaMinsterios, modelo.Id);

                if (!string.IsNullOrEmpty(AddNaListaPessoaReunioes))
                    p.RemoverDaLista("ReuniaoPessoa", "Pessoa", "Reuniao", AddNaListaPessoaReunioes, modelo.Id);

            }

            if (modelo is business.classes.Reuniao)
            {
                var p = (business.classes.Reuniao)modelo;
                if (!string.IsNullOrEmpty(AddNaListaReuniaoPessoas))
                    p.RemoverDaLista("ReuniaoPessoa", "Reuniao", "Pessoa", AddNaListaReuniaoPessoas, modelo.Id);

            }

            modelo.alterar(modelo.Id);
            MessageBox.Show("Informação atualizada com sucesso.");
        }

        private void Deletar_Click(object sender, EventArgs e)
        {
            modelo.excluir(modelo.Id);
        }

        private void Proximo_Click(object sender, EventArgs e)
        {
            if (this is FormCrudPessoa)
            {
                if (modelo is PessoaDado)
                {
                    if (this is DadoPessoal)
                    {

                        Endereco end = new Endereco((PessoaDado)modelo,
                        condicaoAtualizar, condicaoDeletar, CondicaoDetalhes);
                        end.MdiParent = this.MdiParent;
                        this.Close();
                        end.Show();
                    }

                    if (this is Endereco)
                    {

                        Contato con = new Contato((PessoaDado)modelo,
                            condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }

                    if (this is Contato)
                    {
                        Foto con = new Foto((PessoaDado)modelo,
                        condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }

                    if (this is Foto)
                    {
                        ReunioesMinisteriosPessoa con = new ReunioesMinisteriosPessoa((PessoaDado)modelo,
                        condicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        con.MdiParent = this.MdiParent;
                        this.Close();
                        con.Show();
                    }

                    if (this is ReunioesMinisteriosPessoa)
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

                    if (this is CadastroCrianca || this is CadastroVisitante ||
                        this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                        this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                    {
                        FinalizarCadastroPessoa fn = new
                        FinalizarCadastroPessoa((PessoaDado)modelo,
                        CondicaoAtualizar, condicaoDeletar, condicaoDetalhes);
                        fn.MdiParent = this.MdiParent;
                        this.Close();
                        fn.Show();

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

        }

    }
}
