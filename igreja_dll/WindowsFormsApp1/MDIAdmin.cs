using business;
using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.formulario.formularioFinanceiroPessoa;
using WindowsFormsApp1.Formulario;
using WindowsFormsApp1.Formulario.FormularioEmail;
using WindowsFormsApp1.Formulario.FormularioEmail.FormularioEmail;

namespace WindowsFormsApp1
{
    public partial class MDIAdmin : Form
    {
        private int childFormNumber = 0;

        public MDIAdmin()
        {
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

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdmin form = new FrmAdmin();
            form.CondicaoAtualizar = false;
            form.CondicaoDeletar = false;
            form.CondicaoDetalhes = false;
            form.modelo = new Admin();
            form.MdiParent = this;
            form.Show();
        }

        private void atendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAtendente form = new FrmAtendente();
            form.CondicaoAtualizar = false;
            form.CondicaoDeletar = false;
            form.CondicaoDetalhes = false;
            form.modelo = new Atendente();
            form.MdiParent = this;
            form.Show();
        }
        
        

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            FrmPermissao form = new FrmPermissao();
            form.CondicaoAtualizar = false;
            form.CondicaoDeletar = false;
            form.CondicaoDetalhes = false;
            form.modelo = new Permissao();
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormularioListView form = new FormularioListView(typeof(Admin));
            form.MdiParent = this;
            form.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormularioListView form = new FormularioListView(typeof(Atendente));
            form.MdiParent = this;
            form.Show();
        }
                
        private void MDIFormulario_Load(object sender, EventArgs e)
        {
            FrmPrincipal.LoadForm(this, "- Funcionários e Clientes");

            foreach (Control control in this.Controls)
            {
                if (control is MdiClient)
                {
                    control.BackColor = FrmPrincipal.mus.BackgroundColorFinanceiro;
                    break;
                }
            }
        }

        private  void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio imprimir = new ImprimirRelatorio();
            imprimir.imprimir(typeof(Admin));
        }

        private  void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ImprimirRelatorio imprimir = new ImprimirRelatorio();
            imprimir.imprimir(typeof(Atendente));
        }
        
    }
}
