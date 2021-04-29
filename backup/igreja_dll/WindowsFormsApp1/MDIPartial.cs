using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
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
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Crianca();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Aclamacao();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Batismo();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Reconciliacao();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Transferencia();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
            FrmPessoa p = new FrmPessoa(null, "PessoaLgpd");
            p.MdiParent = this;
            p.Text = "Janela " + childFormNumber++;
            p.Show();
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPessoa p = new FrmPessoa(null, "Pessoa");
            p.MdiParent = this;
            p.Text = "Janela " + childFormNumber++;
            p.Show();
        }

        private void pessoaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmPessoa p = new FrmPessoa(null, "PessoaDado");
            p.MdiParent = this;
            p.Text = "Janela " + childFormNumber++;
            p.Show();
        }

        private void visitanteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmVisitante m = new FrmVisitante(new Visitante());
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            FrmVisitante m = new FrmVisitante(new VisitanteLgpd());
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmMembro m = new FrmMembro(null, "Membro");
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            FrmMembro m = new FrmMembro(null, "MembroLgpd");
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void criançaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmCrianca m = new FrmCrianca(new Crianca());
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
            FrmCrianca m = new FrmCrianca(new CriancaLgpd());
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorAclamaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Pessoa p1 = new Membro_Aclamacao();
            FrmMembroAclamacao m = new FrmMembroAclamacao(p1);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem13_Click_1(object sender, EventArgs e)
        {
            Pessoa p1 = new Membro_AclamacaoLgpd();
            FrmMembroAclamacao m = new FrmMembroAclamacao(p1);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorBatismoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Pessoa p1 = new Membro_Batismo();
            MembroBatismo m = new MembroBatismo(p1);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem14_Click_1(object sender, EventArgs e)
        {
            Pessoa p1 = new Membro_BatismoLgpd();
            MembroBatismo m = new MembroBatismo(p1);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorReconciliaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Membro_Reconciliacao();
            MembroReconciliacao m = new MembroReconciliacao(p);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem15_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Membro_ReconciliacaoLgpd();
            MembroReconciliacao m = new MembroReconciliacao(p);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorTransferênciaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Membro_Transferencia();
            MembroTransferencia m = new MembroTransferencia(p);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem16_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Membro_TransferenciaLgpd();
            MembroTransferencia m = new MembroTransferencia(p);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void pessoaLgpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tipo = "PessoaLgpd";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(null, tipo);
        }

        private void pessoaDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tipo = "PessoaDado";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(null, tipo);
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new CriancaLgpd(), tipo);
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new VisitanteLgpd(), tipo);
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            string tipo = "MembroLgpd";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(null, tipo);
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_AclamacaoLgpd(), tipo);
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_BatismoLgpd(), tipo);
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_TransferenciaLgpd(), tipo);
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_ReconciliacaoLgpd(), tipo);
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Crianca(), tipo);
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Visitante(), tipo);
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            string tipo = "Membro";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(null, tipo);
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_Aclamacao(), tipo);
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_Batismo(), tipo);
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_Transferencia(), tipo);
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            ir.imprimir(new Membro_Reconciliacao(), tipo);
        }

    }
}
