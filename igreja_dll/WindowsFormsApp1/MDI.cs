using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class MDI : FormPadrao
    {
        private int childFormNumber = 1;

        public MDI()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }        

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childFormNumber = 1;
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            toolStrip.Visible = false;
            visitanteToolStripMenuItem1.BackColor = Color.Aqua;
            criançaToolStripMenuItem1.BackColor = Color.Bisque;
            membroPorAclamaçãoToolStripMenuItem1.BackColor = Color.Brown;
            membroPorBatismoToolStripMenuItem1.BackColor = Color.Chocolate;
            membroPorReconciliaçãoToolStripMenuItem1.BackColor = Color.DarkBlue;
            membroPorTransferênciaToolStripMenuItem1.BackColor = Color.DeepPink;
        }

        private void ministerioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0)
            {
                FrmMinisterio m = new FrmMinisterio(typeof(Ministerio));
                m.MdiParent = this;
                m.Text = "Janela " + childFormNumber++;
                m.Show();
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void celulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0)
            {
                FrmCelula c = new FrmCelula(typeof(Celula));
                c.MdiParent = this;
                c.Text = "Janela " + childFormNumber++;
                c.Show();
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void mininstérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Lider_Celula));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeLiderançaEmTreinamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Lider_Celula_Treinamento));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeLiderançaDeMinistérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Lider_Ministerio));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministerioDeLiderancaDeMinistérioEmTreianmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Lider_Ministerio_Treinamento));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeSupervisionamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Supervisor_Celula));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeSupervisionamentoDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Supervisor_Celula_Treinamento));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeSupervisionamentoDeMinistérioDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Supervisor_Ministerio));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ministérioDeSupervisionamentoDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMinisterio m = new FrmMinisterio(typeof(Supervisor_Ministerio_Treinamento));
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void ceulaParaAdolescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula(typeof(Celula_Adolescente));
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void celulaParaAdultoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula(typeof(Celula_Adulto));
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void ceulaParaJovemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula(typeof(Celula_Jovem));
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void celulaParaCasadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula(typeof(Celula_Casado));
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void celulaParaAdultosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var celula = new business.classes.Celulas.Celula_Adulto();
            celula.EnderecoCelula = new business.classes.Celula.EnderecoCelula();
            DadoCelula dc = new DadoCelula(celula,
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;            
            dc.Show();
        }

        private void liderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Lider_Celula(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void lIiderEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Lider_Celula_Treinamento(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();

        }

        private void liderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Lider_Ministerio(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void liderDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Lider_Ministerio_Treinamento(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void supervisorDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Supervisor_Celula(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void supervisorDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Supervisor_Celula_Treinamento(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void supervisorDeMinistérioEmTreianmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Supervisor_Ministerio(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void supervisorDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoMinisterio m = new DadoMinisterio(new business.classes.Ministerio.Supervisor_Ministerio_Treinamento(),
                false, false, false);
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void celulaParaCriançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var celula = new business.classes.Celulas.Celula_Crianca();
            celula.EnderecoCelula = new business.classes.Celula.EnderecoCelula();
            DadoCelula dc = new DadoCelula(celula,
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaAdolescentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var celula = new business.classes.Celulas.Celula_Adolescente();
            celula.EnderecoCelula = new business.classes.Celula.EnderecoCelula();
            DadoCelula dc = new DadoCelula(celula,
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaJovensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var celula = new business.classes.Celulas.Celula_Jovem();
            celula.EnderecoCelula = new business.classes.Celula.EnderecoCelula();
            DadoCelula dc = new DadoCelula(celula,
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaCasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var celula = new business.classes.Celulas.Celula_Casado();
            celula.EnderecoCelula = new business.classes.Celula.EnderecoCelula();
            DadoCelula dc = new DadoCelula(celula,
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e){ }        

        private void pessoaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Pessoa)); 
        }

        private void celulaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula)); 
        }

        private void celulaParaAdolescentesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula_Adolescente)); 
        }

        private void celulaParaAdultosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula_Adulto)); 
        }

        private void celulaParaJovensToolStripMenuItem1_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula_Jovem)); 
        }

        private void celulaParaCriançasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula_Crianca)); 
        }

        private void celulaParaCasadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Celula_Casado)); 
        }

        private void ministérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Ministerio)); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Lider_Celula)); 
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Lider_Celula_Treinamento)); 
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Lider_Ministerio)); 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Lider_Ministerio_Treinamento)); 
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Supervisor_Celula)); 
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Supervisor_Celula_Treinamento)); 
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Supervisor_Ministerio)); 
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Supervisor_Ministerio_Treinamento)); 
        }

        private  void reuniãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                FrmReuniao frm = new FrmReuniao();
                frm.MdiParent = this;
                frm.Text = "Janela " + childFormNumber++;
                frm.Show(); 
        }

        private void reuniãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoReuniao frm = new DadoReuniao(new Reuniao(), false, false, false);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void mudançaDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaMudancaEstado frm = new ListaMudancaEstado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mudançaDeEstadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(MudancaEstado)); 
        }

        private void reuniãoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);
                ir.imprimir(typeof(Reuniao));
        }

        private void chamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void historicoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void processamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProcessamento processos = new FormProcessamento();
            processos.MdiParent = this;
            processos.Show();
        }

        private void toolStripMenuItem11_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem13_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem14_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem15_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem16_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem12_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem17_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem10_Click_1(object sender, EventArgs e)
        {

        }

        private void visitanteToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void membroPorAclamaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void membroPorBatismoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void membroPorReconciliaçãoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void membroPorTransferênciaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void membroToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void criançaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void pessoaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void pessoasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Ministerio));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Lider_Celula));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Lider_Celula_Treinamento));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Lider_Ministerio));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Lider_Ministerio_Treinamento));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Supervisor_Celula));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Supervisor_Celula_Treinamento));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Supervisor_Ministerio));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Supervisor_Ministerio_Treinamento));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Reuniao));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula_Adolescente));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula_Adulto));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula_Jovem));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula_Casado));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Celula_Crianca));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Pessoa));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(PessoaLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(PessoaDado));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(VisitanteLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(MembroLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(CriancaLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_AclamacaoLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_BatismoLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_ReconciliacaoLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_TransferenciaLgpd));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void pessoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(PessoaDado));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Visitante));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem72_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Crianca));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_Aclamacao));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_Batismo));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_Reconciliacao));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem71_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar(typeof(Membro_Transferencia));
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(PessoaLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void pessoasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Pessoa));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();

        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(VisitanteLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void celulaParaCriançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula(typeof(Celula_Crianca));
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(MembroLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(CriancaLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_AclamacaoLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_BatismoLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_ReconciliacaoLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_TransferenciaLgpd));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void visitanteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Visitante));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void criançaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Crianca));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroPorAclamaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_Aclamacao));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroPorBatismoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_Batismo));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroPorReconciliaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_Reconciliacao));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void membroPorTransferênciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPessoa frm = new FrmPessoa(typeof(Membro_Transferencia));
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }
    }
}
