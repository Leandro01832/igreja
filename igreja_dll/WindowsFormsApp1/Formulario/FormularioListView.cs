using business.classes.Abstrato;
using business.implementacao;
using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoas;


namespace WindowsFormsApp1.Formulario
{
    public partial class FormularioListView : Form, IFormCrud
    {
        public FormularioListView() { }

        CrudForm crudForm;
        private List<modelocrud> list;

        private Button Mudanca { get; }
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        private Button botaoAtualizarLista { get; }
        private Type Tipo { get; }
        public ListBox ListView { get; set; }

        public FormularioListView(Type tipo)
        {
            crudForm = new CrudForm();
            this.Tipo = tipo;

            ListView = new ListBox();

            // this.View = View.Tile;
            ListView.Size = new Size(600, 300);
            ListView.Location = new Point(50, 50);
            ListView.Font = new Font("Arial", 15);
            ListView.SelectedValueChanged += ListView_SelectedValueChanged;

            

            Mudanca = new Button();
            Mudanca.Location = new Point(570, 40);
            Mudanca.Size = new Size(100, 50);
            Mudanca.Text = "Mudança de estado";
            Mudanca.Click += MudancaEstado_Click;
            Mudanca.Dock = DockStyle.Right;
            Mudanca.Visible = false;

            botaoDeletar = new Button();
            botaoDeletar.Location = new Point(570, 120);
            botaoDeletar.Size = new Size(100, 50);
            botaoDeletar.Text = "Excluir";
            botaoDeletar.Click += botaoExcluir_Click;
            botaoDeletar.Dock = DockStyle.Right;

            botaoAtualizar = new Button();
            botaoAtualizar.Location = new Point(570, 200);
            botaoAtualizar.Size = new Size(100, 50);
            botaoAtualizar.Text = "Atualizar";
            botaoAtualizar.Click += botaoAtualizar_Click;
            botaoAtualizar.Dock = DockStyle.Right;

            botaoDetalhes = new Button();
            botaoDetalhes.Location = new Point(570, 280);
            botaoDetalhes.Size = new Size(100, 50);
            botaoDetalhes.Text = "Detalhes";
            botaoDetalhes.Click += BotaoDetalhes_Click;
            botaoDetalhes.Dock = DockStyle.Right;

            botaoAtualizarLista = new Button();
            botaoAtualizarLista.Location = new Point(570, 360);
            botaoAtualizarLista.Size = new Size(100, 50);
            botaoAtualizarLista.Text = "Atualizar lista";
            botaoAtualizarLista.Click += BotaoAtualizarLista_Click;
            botaoAtualizarLista.Dock = DockStyle.Right;

            Controls.Add(ListView);
            Controls.Add(botaoDetalhes);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDeletar);
            Controls.Add(Mudanca);
            Controls.Add(botaoAtualizarLista);
            this.ListView = ListView;
            InitializeComponent();
        }

        private void ListView_SelectedValueChanged(object sender, EventArgs e)
        {
            atualizarStatusBotao();
        }

        public FormularioListView(List<modelocrud> list)
        {
            this.list = list;
        }

        private async void BotaoAtualizarLista_Click(object sender, EventArgs e)
        {

            ListView.DataSource = modelocrud.Modelos.Where(m => m.GetType() == Tipo || m.GetType().IsSubclassOf(Tipo)).ToList();


            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0 && Tipo.IsAbstract)
                ListView.DataSource = modelocrud.Modelos.OfType<Celula>().ToList();

            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0 && Tipo.IsAbstract)
                ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList();

            if (!Tipo.IsAbstract && ListView.SelectedIndex >= 0)
                ListView.DataSource = await FormPadrao.AtualizarComModelo(Tipo);
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {
            if (Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                try
                {
                    crudForm.Form = new FrmMudancaEstado((modelocrud)ListView.SelectedItem);
                    crudForm.Form.MdiParent = this.MdiParent;
                    crudForm.Form.Show();
                }
                catch { }
            }

            if (Tipo == typeof(Ministerio) || Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                try
                {
                    crudForm.Form = new FrmMudancaEstadoMinisterio((modelocrud)ListView.SelectedItem);
                    crudForm.Form.MdiParent = this.MdiParent;
                    crudForm.Form.Show();
                }
                catch { }
            }
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            LoadFormCrud((modelocrud)ListView.SelectedItem, true, false, false, this);
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            LoadFormCrud((modelocrud)ListView.SelectedItem, false, true, false, this);
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            LoadFormCrud((modelocrud)ListView.SelectedItem, false, false, true, this);
        }

        private void FormularioListView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 350);
            ListView.Dock = DockStyle.Left;

            if (Tipo == typeof(MudancaEstado))
            {
                botaoAtualizar.Visible = false;
                botaoDeletar.Visible = false;
            }


            if (FormPadrao.executar)
                ListView.DataSource = modelocrud.Modelos.Where(m => m.GetType() == Tipo
                || m.GetType().IsSubclassOf(Tipo)).OrderBy(m => m.Id).ToList();
            else
                MessageBox.Show("Aguarde o processamento!!!");

            if (ListView.Items.Count > 0)
                ListView.SetSelected(0, false);

            atualizarStatusBotao();

        }

        private void atualizarStatusBotao()
        {
            botaoAtualizarLista.Enabled = ListView.SelectedIndex >= 0;
            botaoDetalhes.Enabled = ListView.SelectedIndex >= 0;
            botaoAtualizar.Enabled = ListView.SelectedIndex >= 0;
            botaoDeletar.Enabled = ListView.SelectedIndex >= 0;
            Mudanca.Enabled = ListView.SelectedIndex >= 0;
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, Atual);
        }

        public void Clicar(Form form, string function)
        {
            crudForm.Clicar(form, function);
        }
    }
}
