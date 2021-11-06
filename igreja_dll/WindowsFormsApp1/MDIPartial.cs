using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using WindowsFormsApp1.Formulario.Pessoas;
using WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoas;

namespace WindowsFormsApp1
{
    public partial class MDI
    {
        WFCrud frm = null;
        ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);

        private void LoadFormCreate(modelocrud modelo)
        {
            frm.modelo = new Membro_AclamacaoLgpd();
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
            LoadFormCreate(new Membro_AclamacaoLgpd());
        }

        private void membroPorBatismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_BatismoLgpd());
        }

        private void membroPorReconciliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_ReconciliacaoLgpd());
        }

        private void membroPorTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new Membro_TransferenciaLgpd());
        }

        private void vIsitanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new VisitanteLgpd());
        }

        private void criançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoalLgpd();
            LoadFormCreate(new CriancaLgpd());
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Visitante());
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Crianca());
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Aclamacao());
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Batismo());
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            frm = new DadoPessoal();
            LoadFormCreate(new Membro_Reconciliacao());
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            DadoPessoal frm = new DadoPessoal();
            LoadFormCreate(new Membro_Transferencia());
        }

        private void pessoaLgpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
            ir.imprimir(typeof(PessoaLgpd));
        }

        private void pessoaDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
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
