using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MDIFinanceiro : Form, IFormCrud
    {
        private int childFormNumber = 0;

        ImprimirRelatorio ir = new ImprimirRelatorio(modelocrud.Modelos);

        private CrudForm crudForm;

        public MDIFinanceiro()
        {
            crudForm = new CrudForm();
            crudForm.Mdi = this;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
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
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MDI_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
        }

        public void AdminCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "AdminCadastrar_Click"); }

        public void CompradorCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CompradorCadastrar_Click"); }

        public void DizimoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "DizimoCadastrar_Click"); }

        private void LoadFormCreate(modelocrud model)
        {
            LoadFormCrud(model, false, false, false, this);
        }

        public void CantinaCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CantinaCadastrar_Click"); }

        public void OfertaCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "OfertaCadastrar_Click"); }

        public void BazarCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "BazarCadastrar_Click"); }

        public void Lava_RapidoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "Lava_RapidoCadastrar_Click"); }

        public void CompraCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CompraCadastrar_Click"); }

        public void TransporteCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "TransporteCadastrar_Click"); }

        public void TransacaoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "TransacaoCadastrar_Click"); }

        public void RetiroCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "RetiroCadastrar_Click"); }

        public void AluguelCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "AluguelCadastrar_Click"); }


        public void PessoaListar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaListar_Click"); }

        public void AdminListar_Click(object sender, EventArgs e)
        { Clicar(this, "AdminListar_Click"); }

        public void CompradorListar_Click(object sender, EventArgs e)
        { Clicar(this, "CompradorListar_Click"); }

        public void MovimentacaoListar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoListar_Click"); }

        public void MovimentacaoEntradaListar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoEntradaListar_Click"); }

        public void MovimentacaoSaidaListar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoSaidaListar_Click"); }

        public void CompraListar_Click(object sender, EventArgs e)
        { Clicar(this, "CompraListar_Click"); }

        public void TransporteListar_Click(object sender, EventArgs e)
        { Clicar(this, "TransporteListar_Click"); }

        public void TransacaoListar_Click(object sender, EventArgs e)
        { Clicar(this, "TransacaoListar_Click"); }

        public void RetiroListar_Click(object sender, EventArgs e)
        { Clicar(this, "RetiroListar_Click"); }

        public void AluguelListar_Click(object sender, EventArgs e)
        { Clicar(this, "AluguelListar_Click"); }

        public void DizimoListar_Click(object sender, EventArgs e)
        { Clicar(this, "DizimoListar_Click"); }

        public void CantinaListar_Click(object sender, EventArgs e)
        { Clicar(this, "CantinaListar_Click"); }

        public void OfertaListar_Click(object sender, EventArgs e)
        { Clicar(this, "OfertaListar_Click"); }

        public void BazarListar_Click(object sender, EventArgs e)
        { Clicar(this, "BazarListar_Click"); }

        public void Lava_RapidoListar_Click(object sender, EventArgs e)
        { Clicar(this, "Lava_RapidoListar_Click"); }

        public void PessoaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaImprimir_Click"); }

        public void AdminImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "AdminImprimir_Click"); }

        public void CompradorImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "CompradorImprimir_Click"); }

        public void MovimentacaoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoImprimir_Click"); }

        public void MovimentacaoEntradaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoEntradaImprimir_Click"); }

        public void MovimentacaoSaidaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoSaidaImprimir_Click"); }

        public void DizimoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "DizimoImprimir_Click"); }

        public void CantinaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "CantinaImprimir_Click"); }

        public void OfertaImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "OfertaImprimir_Click"); }

        public void BazarImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "BazarImprimir_Click"); }

        public void Lava_RapidoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "Lava_RapidoImprimir_Click"); }

        public void CompraImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "CompraImprimir_Click"); }

        public void TransporteImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "TransporteImprimir_Click"); }

        public void TransacaoImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "TransacaoImprimir_Click"); }

        public void RetiroImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "RetiroImprimir_Click"); }

        public void AluguelImprimir_Click(object sender, EventArgs e)
        { Clicar(this, "AluguelImprimir_Click"); }

        public void PessoaPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "PessoaPesquisar_Click"); }

        public void AdminPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "AdminPesquisar_Click"); }

        public void CompradorPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "CompradorPesquisar_Click"); }

        public void MovimentacaoEntradaPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoEntradaPesquisar_Click"); }

        public void MovimentacaoSaidaPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoSaidaPesquisar_Click"); }

        public void MovimentacaoPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "MovimentacaoPesquisar_Click"); }

        public void DizimoPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "DizimoPesquisar_Click"); }

        public void CantinaPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "CantinaPesquisar_Click"); }

        public void OfertaPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "OfertaPesquisar_Click"); }

        public void BazarPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "BazarPesquisar_Click"); }

        public void Lava_RapidoPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "Lava_RapidoPesquisar_Click"); }

        public void CompraPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "CompraPesquisar_Click"); }

        public void TransportePesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "TransportePesquisar_Click"); }

        public void TransacaoPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "TransacaoPesquisar_Click"); }

        public void RetiroPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "RetiroPesquisar_Click"); }

        public void AluguelPesquisar_Click(object sender, EventArgs e)
        { Clicar(this, "AluguelPesquisar_Click"); }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void gráficoDeMovimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGrafico form = new FrmGrafico();
            form.MdiParent = this;
            form.Show();
        }

        private void gráficoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficoCaixa form = new FrmGraficoCaixa();
            form.MdiParent = this;
            form.Show();
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, this);
        }

        public void Clicar(Form form, string function)
        {
            crudForm.Clicar(form, function);
        }
    }
}
