using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa;

namespace WindowsFormsApp1
{
    public partial class MDI
    {

        private void membroPorAclamaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new Membro_AclamacaoLgpd();
            DadoPessoalLgpd cma = new DadoPessoalLgpd(p2, false, false, false);
            cma.MdiParent = this;
            cma.Text = "Janela " + childFormNumber++;
            cma.Show();
        }

        private void membroPorBatismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new Membro_BatismoLgpd();
            DadoPessoalLgpd cmb = new DadoPessoalLgpd(p2, false, false, false);
            cmb.MdiParent = this;
            cmb.Text = "Janela " + childFormNumber++;
            cmb.Show();
        }

        private void membroPorReconciliaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new Membro_ReconciliacaoLgpd();
            DadoPessoalLgpd cmr = new DadoPessoalLgpd(p2, false, false, false);

            cmr.MdiParent = this;
            cmr.Text = "Janela " + childFormNumber++;
            cmr.Show();
        }

        private void membroPorTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new Membro_TransferenciaLgpd();
            DadoPessoalLgpd cmt = new DadoPessoalLgpd(p2, false, false, false);
            cmt.MdiParent = this;
            cmt.Text = "Janela " + childFormNumber++;
            cmt.Show();
        }

        private void vIsitanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new VisitanteLgpd();
            DadoPessoalLgpd cv = new DadoPessoalLgpd(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void criançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PessoaLgpd p2 = new CriancaLgpd();
            DadoPessoalLgpd cc = new DadoPessoalLgpd(p2, false, false, false);
            cc.MdiParent = this;
            cc.Text = "Janela " + childFormNumber++;
            cc.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Visitante();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Crianca();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Aclamacao();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Batismo();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Reconciliacao();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Transferencia();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
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
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(CriancaLgpd)); 
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(VisitanteLgpd)); 
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(MembroLgpd)); 
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_AclamacaoLgpd)); 
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_BatismoLgpd)); 
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_TransferenciaLgpd)); 
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_ReconciliacaoLgpd)); 
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Crianca)); 
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Visitante)); 
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro)); 
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_Aclamacao)); 
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_Batismo)); 
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_Transferencia)); 
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Membro_Reconciliacao)); 
        }

    }
}
