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
    public partial class MDI : Form, IFormCrud
    {
        private int childFormNumber = 1;
        private CrudForm crudForm;

        public MDI()
        {
            crudForm = new CrudForm();
            crudForm.Mdi = this;
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

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e){ }        
        public void Lider_CelulaListar_Click(object sender, EventArgs e)                         { Clicar(this); }
        public void Lider_Celula_TreinamentoListar_Click(object sender, EventArgs e)             { Clicar(this); }
        public void Lider_MinisterioListar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Lider_Ministerio_TreinamentoListar_Click(object sender, EventArgs e)         { Clicar(this); }
        public void Supervisor_CelulaListar_Click(object sender, EventArgs e)                    { Clicar(this); }
        public void Supervisor_Celula_TreinamentoListar_Click(object sender, EventArgs e)        { Clicar(this); }
        public void Supervisor_MinisterioListar_Click(object sender, EventArgs e)                { Clicar(this); }
        public void Supervisor_Ministerio_TreinamentoListar_Click(object sender, EventArgs e)    { Clicar(this); }
        public void Celula_AdolescenteListar_Click(object sender, EventArgs e)                   { Clicar(this); }
        public void Celula_AdultoListar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void Celula_JovemListar_Click(object sender, EventArgs e)                         { Clicar(this); }
        public void Celula_CasadoListar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void Celula_AdultoCadastrar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Lider_CelulaCadastrar_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void Lider_Celula_TreinamentoCadastrar_Click(object sender, EventArgs e)          { Clicar(this); }
        public void Lider_MinisterioCadastrar_Click(object sender, EventArgs e)                  { Clicar(this); }
        public void Lider_Ministerio_TreinamentoCadastrar_Click(object sender, EventArgs e)      { Clicar(this); }
        public void Supervisor_CelulaCadastrar_Click(object sender, EventArgs e)                 { Clicar(this); }
        public void Supervisor_Celula_TreinamentoCadastrar_Click(object sender, EventArgs e)     { Clicar(this); }
        public void Supervisor_MinisterioCadastrar_Click(object sender, EventArgs e)             { Clicar(this); }
        public void Supervisor_Ministerio_TreinamentoCadastrar_Click(object sender, EventArgs e) { Clicar(this); }
        public void Celula_CriancaCadastrar_Click(object sender, EventArgs e)                    { Clicar(this); }
        public void Celula_AdolescenteCadastrar_Click(object sender, EventArgs e)                { Clicar(this); }
        public void Celula_JovemCadastrar_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void Celula_CasadoCadastrar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void PessoaImprimir_Click(object sender, EventArgs e)                             { Clicar(this); }
        public void CelulaImprimir_Click(object sender, EventArgs e)                             { Clicar(this); }
        public void Celula_AdolescenteImprimir_Click(object sender, EventArgs e)                 { Clicar(this); }
        public void Celula_AdultoImprimir_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void Celula_JovemImprimir_Click(object sender, EventArgs e)                       { Clicar(this); }
        public void Celula_CriancaImprimir_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Celula_CasadoImprimir_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void MinisterioImprimir_Click(object sender, EventArgs e)                         { Clicar(this); }
        public void Lider_CelulaImprimir_Click(object sender, EventArgs e)                       { Clicar(this); }
        public void Lider_Celula_TreinamentoImprimir_Click(object sender, EventArgs e)           { Clicar(this); }
        public void Lider_MinisterioImprimir_Click(object sender, EventArgs e)                   { Clicar(this); }
        public void Lider_Ministerio_TreinamentoImprimir_Click(object sender, EventArgs e)       { Clicar(this); }
        public void Supervisor_CelulaImprimir_Click(object sender, EventArgs e)                  { Clicar(this); }
        public void Supervisor_Celula_TreinamentoImprimir_Click(object sender, EventArgs e)      { Clicar(this); }
        public void Supervisor_MinisterioImprimir_Click(object sender, EventArgs e)              { Clicar(this); }
        public void Supervisor_Ministerio_TreinamentoImprimir_Click(object sender, EventArgs e)  { Clicar(this); }
        public void ReuniaoListar_Click(object sender, EventArgs e)                              { Clicar(this); }
        public void ReuniaoCadastrar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void MudancaEstadoListar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void MudancaEstadoImprimir_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void ReuniaoImprimir_Click(object sender, EventArgs e)                            { Clicar(this); }
        public void MinisterioPesquisar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void Lider_CelulaPesquisar_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void Lider_Celula_TreinamentoPesquisar_Click(object sender, EventArgs e)          { Clicar(this); }
        public void Lider_MinisterioPesquisar_Click(object sender, EventArgs e)                  { Clicar(this); }
        public void Lider_Ministerio_TreianamentoPesquisar_Click(object sender, EventArgs e)     { Clicar(this); }
        public void Supervisor_CelulaPesquisar_Click(object sender, EventArgs e)                 { Clicar(this); }
        public void Supervisor_Celula_TreinamentoPesquisar_Click(object sender, EventArgs e)     { Clicar(this); }
        public void Supervisor_MinisterioPesquisar_Click(object sender, EventArgs e)             { Clicar(this); }
        public void Supervisor_Ministerio_TreinamentoPesquisar_Click(object sender, EventArgs e) { Clicar(this); }
        public void ReuniaoPesquisar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void CelulaPesquisar_Click(object sender, EventArgs e)                            { Clicar(this); }
        public void Celula_AdolescentePesquisar_Click(object sender, EventArgs e)                { Clicar(this); }
        public void Celula_AdultoPesquisar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Celula_JovemPesquisar_Click(object sender, EventArgs e)                      { Clicar(this); }
        public void Celula_CasadoPesquisar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Celula_CriancaPesquisar_Click(object sender, EventArgs e)                    { Clicar(this); }
        public void PessoaPesquisar_Click(object sender, EventArgs e)                            { Clicar(this); }
        public void PessoaLgpdPesquisar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void PessoaDadoPesquisar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void VisitanteLgpdPesquisar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void MenbroLgpdPesquisar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void CriancaLgpdPesquisar_Click(object sender, EventArgs e)                       { Clicar(this); }
        public void Membro_AclamacaoLgpdPesquisar_Click(object sender, EventArgs e)              { Clicar(this); }
        public void Membro_BatismoLgpdPesquisar_Click(object sender, EventArgs e)                { Clicar(this); }
        public void Membro_ReconciliacaoLgpdPesquisar_Click(object sender, EventArgs e)          { Clicar(this); }
        public void Membro_TransferenciaLgpdPesquisar_Click(object sender, EventArgs e)          { Clicar(this); }
        public void PessoaDadoListar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void VisitantePesquisar_Click(object sender, EventArgs e)                         { Clicar(this); }
        public void CriancaPesquisar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void MembroPesquisar_Click(object sender, EventArgs e)                            { Clicar(this); }
        public void Membro_AclamacaoPesquisar_Click(object sender, EventArgs e)                  { Clicar(this); }
        public void Membro_BatismoPesquisar_Click(object sender, EventArgs e)                    { Clicar(this); }
        public void Membro_ReconciliacaoPesquisar_Click(object sender, EventArgs e)              { Clicar(this); }
        public void Membro_TransferenciaPesquisar_Click(object sender, EventArgs e)              { Clicar(this); }
        public void PessoaLgpdListar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void PessoaListar_Click(object sender, EventArgs e)                               { Clicar(this); }
        public void VisitanteLgpdListar_Click(object sender, EventArgs e)                        { Clicar(this); }
        public void Celula_CriancaListar_Click(object sender, EventArgs e)                       { Clicar(this); }
        public void MembroLgpdListar_Click(object sender, EventArgs e)                           { Clicar(this); }
        public void CriancaLgpdListar_Click(object sender, EventArgs e)                          { Clicar(this); }
        public void Membro_AclamacaoLgpdListar_Click(object sender, EventArgs e)                 { Clicar(this); }
        public void Membro_BatismoLgpdListar_Click(object sender, EventArgs e)                   { Clicar(this); }
        public void Membro_ReconciliacaoLgpdListar_Click(object sender, EventArgs e)             { Clicar(this); }
        public void Membro_TransferenciaLgpdListar_Click(object sender, EventArgs e)             { Clicar(this); }
        public void VisitanteListar_Click(object sender, EventArgs e)                            { Clicar(this); }
        public void MembroListar_Click(object sender, EventArgs e)                               { Clicar(this); }
        public void CriancaListar_Click(object sender, EventArgs e)                              { Clicar(this); }
        public void Membro_AclamacaoListar_Click(object sender, EventArgs e)                     { Clicar(this); }
        public void Membro_BatismoListar_Click(object sender, EventArgs e)                       { Clicar(this); }
        public void Membro_ReconciliacaoListar_Click(object sender, EventArgs e)                 { Clicar(this); }
        public void Membro_TransferenciaListar_Click(object sender, EventArgs e)                 { Clicar(this); }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, Atual);
        }

        public void Clicar(Form form)
        {
            crudForm.Clicar(form);
        }
    }
}
