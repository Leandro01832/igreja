using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celula;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Pessoa.FormCrudPessoa;
using WindowsFormsApp1.Formulario.Reuniao;

namespace WindowsFormsApp1
{
    public partial class MDI : Form
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
            FrmMinisterio m = new FrmMinisterio();
            m.MdiParent = this;
            m.Text = "Janela " + childFormNumber++;
            m.Show();
        }

        private void celulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmCelula c = new FrmCelula();
            c.MdiParent = this;
            c.Text = "Janela " + childFormNumber++;
            c.Show();
        }

        private void mininstérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiderCelula lc = new LiderCelula();
            lc.MdiParent = this;
            lc.Text = "Janela " + childFormNumber++;
            lc.Show();
        }

        private void ministérioDeLiderançaEmTreinamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiderCelulaTreinamento lct = new LiderCelulaTreinamento();
            lct.MdiParent = this;
            lct.Text = "Janela " + childFormNumber++;
            lct.Show();
        }

        private void ministérioDeLiderançaDeMinistérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiderMinisterio lm = new LiderMinisterio();
            lm.MdiParent = this;
            lm.Text = "Janela " + childFormNumber++;
            lm.Show();
        }

        private void ministerioDeLiderancaDeMinistérioEmTreianmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiderMinisterioTreinamento lmt = new LiderMinisterioTreinamento();
            lmt.MdiParent = this;
            lmt.Text = "Janela " + childFormNumber++;
            lmt.Show();
        }

        private void ministérioDeSupervisionamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupervisorCelula sc = new SupervisorCelula();
            sc.MdiParent = this;
            sc.Text = "Janela " + childFormNumber++;
            sc.Show();
        }

        private void ministérioDeSupervisionamentoDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupervisorCelulaTreinamento sct = new SupervisorCelulaTreinamento();
            sct.MdiParent = this;
            sct.Text = "Janela " + childFormNumber++;
            sct.Show();
        }

        private void ministérioDeSupervisionamentoDeMinistérioDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupervisorMinisterio sm = new SupervisorMinisterio();
            sm.MdiParent = this;
            sm.Text = "Janela " + childFormNumber++;
            sm.Show();
        }

        private void ministérioDeSupervisionamentoDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupervisorMinisterioTreinamento smt = new SupervisorMinisterioTreinamento();
            smt.MdiParent = this;
            smt.Text = "Janela " + childFormNumber++;
            smt.Show();
        }

        private void ceulaParaAdolescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CelulaAdolescente ca = new CelulaAdolescente();
            ca.MdiParent = this;
            ca.Text = "Janela " + childFormNumber++;
            ca.Show();
        }

        private void celulaParaAdultoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CelulaAdulto cad = new CelulaAdulto();
            cad.MdiParent = this;
            cad.Text = "Janela " + childFormNumber++;
            cad.Show();
        }

        private void ceulaParaJovemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CelulaJovem cj = new CelulaJovem();
            cj.MdiParent = this;
            cj.Text = "Janela " + childFormNumber++;
            cj.Show();
        }

        private void celulaParaCasadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CelulaCasado cc = new CelulaCasado();
            cc.MdiParent = this;
            cc.Text = "Janela " + childFormNumber++;
            cc.Show();
        }

        private void celulaParaAdultosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula(new business.classes.Celulas.Celula_Adulto(),
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
            DadoCelula dc = new DadoCelula(new business.classes.Celulas.Celula_Crianca(),
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaAdolescentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula(new business.classes.Celulas.Celula_Adolescente(),
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaJovensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula(new business.classes.Celulas.Celula_Jovem(),
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void celulaParaCasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoCelula dc = new DadoCelula(new business.classes.Celulas.Celula_Casado(),
                false, false, false);
            dc.MdiParent = this;
            dc.Text = "Janela " + childFormNumber++;
            dc.Show();
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pesquisar query = new Pesquisar();
            query.MdiParent = this;
            query.Text = "Janela " + childFormNumber++;
            query.Show();
        }

        

        private async void pessoaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string tipo = "Pessoa";
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(null, tipo);
        }

        private async void celulaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(null, "Celula");
        }

        private async void celulaParaAdolescentesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(new business.classes.Celulas.Celula_Adolescente(), "");
        }

        private async void celulaParaAdultosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
           await ir.imprimir(new business.classes.Celulas.Celula_Adulto(), "");
        }

        private async void celulaParaJovensToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
           await ir.imprimir(new business.classes.Celulas.Celula_Jovem(), "");
        }

        private async void celulaParaCriançasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await ir.imprimir(new business.classes.Celulas.Celula_Crianca(), "");
        }

        private  async void celulaParaCasadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(new business.classes.Celulas.Celula_Casado(), "");
        }

        private async void ministérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(null, "Ministerio");
        }

        private async void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(new business.classes.Ministerio.Lider_Celula(), "");
        }

        private async void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(new business.classes.Ministerio.Lider_Celula_Treinamento(), "");
        }

        private async void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
          await  ir.imprimir(new business.classes.Ministerio.Lider_Ministerio(), "");
        }

        private async void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(new business.classes.Ministerio.Lider_Ministerio_Treinamento(), "");
        }

        private async void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(new business.classes.Ministerio.Supervisor_Celula(), "");
        }

        private async void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(new business.classes.Ministerio.Supervisor_Celula_Treinamento(), "");
        }

        private async void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(new business.classes.Ministerio.Supervisor_Ministerio(), "");
        }

        private async void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio ir = new ImprimirRelatorio();
            await ir.imprimir(new business.classes.Ministerio.Supervisor_Ministerio_Treinamento(), "");
        }

        private  void reuniãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReuniao frm = new FrmReuniao();
        }

        private void reuniãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DadoReuniao frm = new DadoReuniao(new Reuniao(), false, false, false);
            frm.MdiParent = this;
            frm.Show();
        }

        private void mudançaDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaMudancaEstado frm = new ListaMudancaEstado();
            frm.MdiParent = this;
            frm.Show();
        }

        private async void mudançaDeEstadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string tipo = "";
            ImprimirRelatorio ir = new ImprimirRelatorio();
           await ir.imprimir(new MudancaEstado(), tipo);
        }

        private async Task envioDeArquivosPServidorToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            string StartDirectory = @"c:\Users\exampleuser\start";
            string EndDirectory = @"c:\Users\exampleuser\end";

            foreach (string filename in Directory.EnumerateFiles(StartDirectory))
            {
                using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create(EndDirectory + filename.Substring(filename.LastIndexOf('\\'))))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                    }
                }
            }
        }
    }
}
