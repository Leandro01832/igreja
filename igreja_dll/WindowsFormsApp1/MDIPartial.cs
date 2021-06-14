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
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            PessoaDado p2 = new Membro_Transferencia();
            p2.Endereco = new business.classes.Endereco();
            p2.Telefone = new business.classes.Telefone();
            DadoPessoal cv = new DadoPessoal(p2, false, false, false);
            cv.MdiParent = this;
            cv.Text = "Janela " + childFormNumber++;
            cv.Show();
        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {
            if (Pessoa.listaPessoas.Count > 0)
            {
                FrmPessoa p = new FrmPessoa(typeof(PessoaLgpd));
                p.MdiParent = this;
                p.Text = "Janela " + childFormNumber++;
                p.Show(); 
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pessoa.listaPessoas.Count > 0)
            {
                FrmPessoa p = new FrmPessoa(typeof(Pessoa));
                p.MdiParent = this;
                p.Text = "Janela " + childFormNumber++;
                p.Show();
            }
            else MessageBox.Show("Aguarde o processamento");
            
        }

        private void pessoaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (Pessoa.listaPessoas.Count > 0)
            {
                FrmPessoa p = new FrmPessoa(typeof(PessoaDado));
                p.MdiParent = this;
                p.Text = "Janela " + childFormNumber++;
                p.Show(); 
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void visitanteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmVisitante m = new FrmVisitante(typeof(Visitante));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {
            FrmVisitante m = new FrmVisitante(typeof(VisitanteLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (Pessoa.listaPessoas.Count > 0)
            {
                FrmMembro m = new FrmMembro(typeof(Membro));
                m.MdiParent = this;
                m.Text = "Janela " + childFormNumber++;
                m.Show();  
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {
            if (Pessoa.listaPessoas.Count > 0)
            {
                FrmMembro m = new FrmMembro(typeof(MembroLgpd));
                m.MdiParent = this;
                m.Text = "Janela " + childFormNumber++;
                m.Show();  
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void criançaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmCrianca m = new FrmCrianca(typeof(Crianca));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {
            FrmCrianca m = new FrmCrianca(typeof(CriancaLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorAclamaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmMembroAclamacao m = new FrmMembroAclamacao(typeof(Membro_Aclamacao));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem13_Click_1(object sender, EventArgs e)
        {
            FrmMembroAclamacao m = new FrmMembroAclamacao(typeof(Membro_AclamacaoLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorBatismoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MembroBatismo m = new MembroBatismo(typeof(Membro_Batismo));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem14_Click_1(object sender, EventArgs e)
        {
            MembroBatismo m = new MembroBatismo(typeof(Membro_BatismoLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorReconciliaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MembroReconciliacao m = new MembroReconciliacao(typeof(Membro_Reconciliacao));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem15_Click_1(object sender, EventArgs e)
        {
            MembroReconciliacao m = new MembroReconciliacao(typeof(Membro_ReconciliacaoLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void membroPorTransferênciaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MembroTransferencia m = new MembroTransferencia(typeof(Membro_Transferencia));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void toolStripMenuItem16_Click_1(object sender, EventArgs e)
        {
            MembroTransferencia m = new MembroTransferencia(typeof(Membro_TransferenciaLgpd));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();

        }

        private void pessoaLgpdToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(PessoaLgpd)); 
        }

        private void pessoaDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(PessoaDado)); 
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(CriancaLgpd)); 
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(VisitanteLgpd)); 
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(MembroLgpd)); 
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_AclamacaoLgpd)); 
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_BatismoLgpd)); 
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_TransferenciaLgpd)); 
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_ReconciliacaoLgpd)); 
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Crianca)); 
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Visitante)); 
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro)); 
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_Aclamacao)); 
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_Batismo)); 
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_Transferencia)); 
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(Pessoa.listaPessoas, Ministerio.listaMinisterios, Celula.listaCelulas,
                    Reuniao.Reunioes, MudancaEstado.Mudancas);
                ir.imprimir(typeof(Membro_Reconciliacao)); 
        }

    }
}
