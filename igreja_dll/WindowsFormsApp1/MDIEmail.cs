using business;
using business.classes.Pessoas;
using database;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.FormularioEmail;

namespace DesktopEmail.Formulario
{
    public partial class MDIEmail : Form, IFormCrud
    {
        private CrudForm crudForm;

        public MDIEmail()
        {
            crudForm = new CrudForm();
            crudForm.Mdi = this;
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Atendente atendente = null;

            if (modelocrud.pessoa is Atendente)
                atendente = (Atendente)modelocrud.pessoa;

            if(modelocrud.pessoa is Admin || modelocrud.ativar || atendente != null &&
                atendente.Permissao.FirstOrDefault(p => p.Permissao.Nome == "CadastrarAtualizarBody") != null)
            {
                Process.Start("https://www.advocacia.somee.com/Home/Email");
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            FrmOpenEmail form = new FrmOpenEmail();
            form.MdiParent = this;
            form.Show();

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
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnviaEmail form = new FrmEnviaEmail();
            form.MdiParent = this;
            form.Show();
        }

        private void cadastrarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crudForm.Form = new FrmPermissao();
            LoadFormCrud(new Permissao(), false, false, false, this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormularioListView form = new FormularioListView(typeof(Permissao));
            form.MdiParent = this;
            form.Show();
        }

        private void MDIEmail_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
        }

        private  void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio imprimir = new ImprimirRelatorio(modelocrud.Modelos);
            imprimir.imprimir(typeof(Email));
        }

        private  void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio imprimir = new ImprimirRelatorio(modelocrud.Modelos);
            imprimir.imprimir(typeof(Permissao));
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, this);
        }

        public void Clicar()
        {
            crudForm.Clicar();
        }
    }
}
