using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;

namespace WindowsFormsApp1
{
    public partial class MDI 
    {
        WFCrud frm = null;
        ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);

        private void OpenListPessoa(Type tipo)
        {
            FormularioListView frm = new ListPessoa(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }
        private void OpenListMinisterio(Type tipo)
        {
            FormularioListView frm = new ListMinisterio(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }
        private void OpenListCelula(Type tipo)
        {
            FormularioListView frm = new ListCelula(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void OpenQuery(Type tipo)
        {
            Pesquisar query = new Pesquisar(tipo);
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void LoadFormCreate(modelocrud modelo)
        {
            frm.modelo = modelo;
            frm.CondicaoAtualizar = false;
            frm.CondicaoDeletar = false;
            frm.CondicaoDetalhes = false;
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroPorAclamaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_AclamacaoLgpd(true));
        }

        private void membroPorBatismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_BatismoLgpd(true));
        }

        private void membroPorReconciliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_ReconciliacaoLgpd(true));
        }

        private void membroPorTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_TransferenciaLgpd(true));
        }

        private void vIsitanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new VisitanteLgpd(true));
        }

        private void criançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new CriancaLgpd(true));
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Visitante(true));
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Crianca(true));
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Aclamacao(true));
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Batismo(true));
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Reconciliacao(true));
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            DadoPessoal frm = new DadoPessoal();
            LoadFormCreate(new Membro_Transferencia(true));
        }

        private void pessoaLgpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(PessoaLgpd));
        }

        private void pessoaDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(PessoaDado));
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(CriancaLgpd));
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(VisitanteLgpd));
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(MembroLgpd));
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_AclamacaoLgpd));
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_BatismoLgpd));
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_TransferenciaLgpd));
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_ReconciliacaoLgpd));
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Crianca));
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Visitante));
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro));
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_Aclamacao));
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_Batismo));
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_Transferencia));
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            ir.imprimir(typeof(Membro_Reconciliacao));
        }

    }
}
