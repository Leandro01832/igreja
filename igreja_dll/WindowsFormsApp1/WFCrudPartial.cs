using business.classes;
using business.classes.Abstrato;
using business.classes.Esboco.Fontes;
using business.classes.Fontes;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
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
            crudForm.Form = new Foto();
            LoadForm();
        }

        private void DadoClasse_Click(object sender, EventArgs e)
        {
            if (modelo is Crianca || modelo is CriancaLgpd)
                crudForm.Form = new CadastroCrianca();

            if (modelo is Visitante || modelo is VisitanteLgpd)
                crudForm.Form = new CadastroVisitante();

            if (modelo is Membro_Aclamacao || modelo is Membro_AclamacaoLgpd)
                crudForm.Form = new CadastroMembroAclamacao();

            if (modelo is Membro_Batismo || modelo is Membro_BatismoLgpd)
                crudForm.Form = new CadastroMembroBatismo();

            if (modelo is Membro_Reconciliacao || modelo is Membro_ReconciliacaoLgpd)
                crudForm.Form = new CadastroMembroReconciliacao();

            if (modelo is Membro_Transferencia || modelo is Membro_TransferenciaLgpd)
                crudForm.Form = new CadastroMembroTransferencia();

            LoadForm();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
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

            var model = (modelocrud)Activator.CreateInstance(modelo.GetType());

            if (!model.recuperar(id))
            {
                MessageBox.Show("Você já apagou este registro");
                return;
            }

            model.excluir(id);
            modelocrud.Modelos.Remove(modelocrud.Modelos.First(i => i.Id == id));
            MessageBox.Show("Informação removida do banco de dados com sucesso.");
        }

        private void Proximo_Click(object sender, EventArgs e)
        {
            if (this is FrmCadastrarMensagem)
                crudForm.Form = new FrmMensagem();

            if (this is FrmDadoFonte)
            {
                if (modelo is Versiculo)
                    crudForm.Form = new FrmVersiculo();

                if (modelo is CanalTv)
                    crudForm.Form = new FrmCanalTv();

                if (modelo is Livro)
                    crudForm.Form = new FrmLivro();
            }

            if (this is FrmVersiculo || this is FrmCanalTv || this is FrmLivro)
                crudForm.Form = new FrmFonte();

            if (modelo is PessoaDado || ModeloNovo is PessoaDado)
            {
                if (this is DadoPessoal)
                    crudForm.Form = new FrmEndereco();

                if (this is FrmEndereco)
                    crudForm.Form = new Contato();

                if (this is Contato)
                    crudForm.Form = new Foto();

                if (this is Foto)
                    crudForm.Form = new ReunioesMinisteriosPessoa();

                if (this is ReunioesMinisteriosPessoa)
                {
                    //  object objNovo = null;
                    //  object obj = null;
                    //
                    //  if (ModeloNovo != null)
                    //      objNovo = Activator.CreateInstance(ModeloNovo.GetType());
                    //  if (modelo != null)
                    //      obj = Activator.CreateInstance(modelo.GetType());

                    if (ModeloNovo is Crianca || modelo is Crianca)
                        crudForm.Form = new CadastroCrianca();

                    if (ModeloNovo is Visitante || modelo is Visitante)
                        crudForm.Form = new CadastroVisitante();

                    if (ModeloNovo is Membro_Aclamacao || modelo is Membro_Aclamacao)
                        crudForm.Form = new CadastroMembroAclamacao();

                    if (ModeloNovo is Membro_Reconciliacao || modelo is Membro_Reconciliacao)
                        crudForm.Form = new CadastroMembroReconciliacao();

                    if (ModeloNovo is Membro_Batismo || modelo is Membro_Batismo)
                        crudForm.Form = new CadastroMembroBatismo();

                    if (ModeloNovo is Membro_Transferencia || modelo is Membro_Transferencia)
                        crudForm.Form = new CadastroMembroTransferencia();
                }

                if (this is CadastroCrianca || this is CadastroVisitante ||
                    this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                    this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                    crudForm.Form = new FrmPessoa();

            }

            if (modelo is PessoaLgpd || ModeloNovo is PessoaLgpd)
            {
                if (this is DadoPessoalLgpd)
                    crudForm.Form = new Foto();

                if (this is Foto)
                    crudForm.Form = new ReunioesMinisteriosPessoa();

                if (this is ReunioesMinisteriosPessoa)
                {
                    if (modelo is CriancaLgpd)
                        crudForm.Form = new CadastroCrianca();

                    if (modelo is VisitanteLgpd)
                        crudForm.Form = new CadastroVisitante();

                    if (modelo is Membro_AclamacaoLgpd)
                        crudForm.Form = new CadastroMembroAclamacao();

                    if (modelo is Membro_ReconciliacaoLgpd)
                        crudForm.Form = new CadastroMembroReconciliacao();

                    if (modelo is Membro_BatismoLgpd)
                        crudForm.Form = new CadastroMembroBatismo();

                    if (modelo is Membro_TransferenciaLgpd)
                        crudForm.Form = new CadastroMembroTransferencia();
                }

                if (this is CadastroCrianca || this is CadastroVisitante ||
                    this is CadastroMembroAclamacao || this is CadastroMembroReconciliacao ||
                    this is CadastroMembroBatismo || this is CadastroMembroTransferencia)
                    crudForm.Form = new FrmPessoa();
            }

            if (this is DadoCelula)
                crudForm.Form = new FrmEnderecoCelula();

            if (this is FrmEnderecoCelula)
                crudForm.Form = new MinisteriosCelula();

            if (this is MinisteriosCelula)
                crudForm.Form = new FrmCelula();

            if (this is DadoMinisterio)
                crudForm.Form = new PessoasCelulasMinisterio();

            if (this is PessoasCelulasMinisterio)
                crudForm.Form = new FrmMinisterio();

            if (this is DadoReuniao)
                crudForm.Form = new PessoasReuniao();

            if (this is PessoasReuniao)
                crudForm.Form = new FrmReuniao();

            LoadForm();

            this.Close();
        }

    }
}
