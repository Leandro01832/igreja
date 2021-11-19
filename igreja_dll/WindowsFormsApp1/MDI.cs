using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using business.implementacao;
using database;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Celulas;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;
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
            FormPadrao.LoadForm(this, "Gerenciamento de pessoas");
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
                OpenListMinisterio(typeof(Ministerio));
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void celulaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0)
            {
                OpenListCelula(typeof(Celula));
            }
            else MessageBox.Show("Aguarde o processamento");
        }

        private void mininstérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Lider_Celula));
        }

        private void ministérioDeLiderançaEmTreinamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Lider_Celula_Treinamento));
        }

        private void ministérioDeLiderançaDeMinistérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Lider_Ministerio));
        }

        private void ministerioDeLiderancaDeMinistérioEmTreianmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Lider_Ministerio_Treinamento));
        }

        private void ministérioDeSupervisionamentoDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Supervisor_Celula));
        }

        private void ministérioDeSupervisionamentoDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Supervisor_Celula_Treinamento));
        }

        private void ministérioDeSupervisionamentoDeMinistérioDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Supervisor_Ministerio));
        }

        private void ministérioDeSupervisionamentoDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListMinisterio(typeof(Supervisor_Ministerio_Treinamento));
        }

        private void ceulaParaAdolescenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListCelula(typeof(Celula_Adolescente));
        }

        private void celulaParaAdultoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListCelula(typeof(Celula_Adulto));
        }

        private void ceulaParaJovemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListCelula(typeof(Celula_Jovem));
        }

        private void celulaParaCasadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListCelula(typeof(Celula_Casado));
        }

        private void celulaParaAdultosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCreate(new Celula_Adulto(true));
        }

        private void liderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Lider_Celula(true));
        }

        private void lIiderEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Lider_Celula_Treinamento(true));
        }

        private void liderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Lider_Ministerio(true));
        }

        private void liderDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Lider_Ministerio_Treinamento(true));
        }

        private void supervisorDeCelulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Supervisor_Celula(true));
        }

        private void supervisorDeCelulaEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Supervisor_Celula_Treinamento(true));
        }

        private void supervisorDeMinistérioEmTreianmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Supervisor_Ministerio(true));
        }

        private void supervisorDeMinistérioEmTreinamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoMinisterio();
            LoadFormCreate(new Supervisor_Ministerio_Treinamento(true));
        }

        private void celulaParaCriançasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCreate(new Celula_Crianca(true));
        }

        private void celulaParaAdolescentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCreate(new Celula_Adolescente(true));
        }

        private void celulaParaJovensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCreate(new Celula_Jovem(true));
        }

        private void celulaParaCasadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoCelula();
            LoadFormCreate(new Celula_Casado(true));
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e){ }        

        private void pessoaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Pessoa)); 
        }

        private void celulaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula)); 
        }

        private void celulaParaAdolescentesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula_Adolescente)); 
        }

        private void celulaParaAdultosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula_Adulto)); 
        }

        private void celulaParaJovensToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula_Jovem)); 
        }

        private void celulaParaCriançasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula_Crianca)); 
        }

        private void celulaParaCasadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Celula_Casado)); 
        }

        private void ministérioToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Ministerio)); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Lider_Celula)); 
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Lider_Celula_Treinamento)); 
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Lider_Ministerio)); 
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Lider_Ministerio_Treinamento)); 
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Supervisor_Celula)); 
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Supervisor_Celula_Treinamento)); 
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Supervisor_Ministerio)); 
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Supervisor_Ministerio_Treinamento)); 
        }

        private  void reuniãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                ListReuniao frm = new ListReuniao();
                frm.MdiParent = this;
                frm.Text = "Janela " + childFormNumber++;
                frm.Show(); 
        }

        private void reuniãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new DadoReuniao();
            LoadFormCreate(new Reuniao(true));
        }

        private void mudançaDeEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaMudancaEstado frm = new ListaMudancaEstado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mudançaDeEstadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {            
                ir.imprimir(typeof(MudancaEstado)); 
        }

        private void reuniãoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
                ir.imprimir(typeof(Reuniao));
        }
        
        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Ministerio));
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Lider_Celula));
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Lider_Celula_Treinamento));
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Lider_Ministerio));
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Lider_Ministerio_Treinamento));
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Supervisor_Celula));
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Supervisor_Celula_Treinamento));
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Supervisor_Ministerio));
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Supervisor_Ministerio_Treinamento));
        }

        private void toolStripMenuItem49_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Reuniao));
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula));
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula_Adolescente));
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula_Adulto));
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula_Jovem));
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula_Casado));
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Celula_Crianca));
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Pessoa));
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(PessoaLgpd));
        }

        private void toolStripMenuItem65_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(PessoaDado));
        }

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(VisitanteLgpd));
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(MembroLgpd));
        }

        private void toolStripMenuItem64_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(CriancaLgpd));
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_AclamacaoLgpd));
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_BatismoLgpd));
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_ReconciliacaoLgpd));
        }

        private void toolStripMenuItem63_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_TransferenciaLgpd));
        }

        private void pessoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(PessoaDado));
        }

        private void toolStripMenuItem66_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Visitante));
        }

        private void toolStripMenuItem72_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Crianca));
        }

        private void toolStripMenuItem67_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro));
        }

        private void toolStripMenuItem68_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_Aclamacao));
        }

        private void toolStripMenuItem69_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_Batismo));
        }

        private void toolStripMenuItem70_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_Reconciliacao));
        }

        private void toolStripMenuItem71_Click(object sender, EventArgs e)
        {
            OpenQuery(typeof(Membro_Transferencia));
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(PessoaLgpd));
        }

        private void pessoasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Pessoa));
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(VisitanteLgpd));
        }

        private void celulaParaCriançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Celula_Crianca));
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(MembroLgpd));
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(CriancaLgpd));
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_AclamacaoLgpd));
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_BatismoLgpd));
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_ReconciliacaoLgpd));
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_TransferenciaLgpd));
        }

        private void visitanteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Visitante));
        }

        private void membroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro));
        }

        private void criançaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Crianca));
        }

        private void membroPorAclamaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_Aclamacao));
        }

        private void membroPorBatismoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_Batismo));
        }

        private void membroPorReconciliaçãoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           OpenListPessoa(typeof(Membro_Reconciliacao));
        }

        private void membroPorTransferênciaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenListPessoa(typeof(Membro_Transferencia));
        }
    }
}
