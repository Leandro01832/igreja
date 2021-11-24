using business.classes.Esboco;
using business.classes.Esboco.Abstrato;
using business.classes.Esboco.Fontes;
using business.classes.Fontes;
using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.FormularioFonte;

namespace WFEsboco
{
    public partial class MDIEsboco : Form, IFormCrud
    {
        private int childFormNumber = 0;

        private CrudForm crudForm;

        public MDIEsboco()
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

        private void mensagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crudForm.Form = new FrmCadastrarMensagem();
            LoadFormCreate(new Mensagem());
        }

        private void LoadFormCreate(modelocrud model)
        {
            LoadFormCrud(model, false, false, false, this);
        }

        private void LoadFormList(Type tipo)
        {
            FormularioListView frm = new FormularioListView(tipo);
            frm.MdiParent = this;
            frm.Text = "Janela " + childFormNumber++;
            frm.Show();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }



        private void    MensagemListar_Click(object sender, EventArgs e)
        { Clicar(this, "MensagemListar_Click"); }

        private void    FonteListar_Click(object sender, EventArgs e)
        { Clicar(this, "FonteListar_Click"); }

        private void    VersiculoCadastrar_Click2(object sender, EventArgs e)
        { Clicar(this, "VersiculoCadastrar_Click2"); }

        private void    VersiculoCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "VersiculoCadastrar_Click"); }

        private void    VersiculoListar_Click(object sender, EventArgs e)
        { Clicar(this, "VersiculoListar_Click"); }

        private void    CanalTvListar_Click(object sender, EventArgs e)
        { Clicar(this, "CanalTvListar_Click"); }

        private void    CanalTvCadastrar_Click(object sender, EventArgs e)
        { Clicar(this, "CanalTvCadastrar_Click"); }

        private void    LivroCadstrar_Click(object sender, EventArgs e)
        { Clicar(this, "LivroCadstrar_Click"); }

        private void    LivroListar_Click(object sender, EventArgs e)
        { Clicar(this, "LivroListar_Click"); }

        private void MDIEsboco_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
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
