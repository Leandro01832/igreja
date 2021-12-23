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

        MdiForm crudForm;
        private List<modelocrud> list;

        public Button MudancaEstado { get; set; }
        public Button Detalhes { get; set; }
        public Button Atualizar { get; set; }
        public Button Deletar { get; set; }
        public Button AtualizarLista { get; set; }
        private Type Tipo { get; }
        public ListBox ListView { get; set; }

        public FormularioListView(Type tipo)
        {
            crudForm = new MdiForm();
            this.Tipo = tipo;

            ListView = new ListBox();
            
            ListView.Size = new Size(600, 300);
            ListView.Location = new Point(50, 50);
            ListView.Font = new Font("Arial", 14);
            ListView.SelectedValueChanged += ListView_SelectedValueChanged;

            var props = this.GetType().GetProperties().Where(p => p.PropertyType == typeof(Button)).ToList();
            var posicaoY = 40;
            foreach (var item in props)
            {
                item.SetValue(this, new Button());
                var botao = (Button)item.GetValue(this);
                botao.Size = new Size(135, 50);
                botao.Dock = DockStyle.Right;
                botao.Text = modelocrud.formatarTexto(item.Name);
                botao.Location = new Point(570, posicaoY);
                botao.Font = new Font("Arial", 14);
                Controls.Add(botao);
                posicaoY += 80;
            }
            
            MudancaEstado.Click += MudancaEstado_Click;            
            Deletar.Click += botaoExcluir_Click;            
            Atualizar.Click += botaoAtualizar_Click;            
            Detalhes.Click += BotaoDetalhes_Click;            
            AtualizarLista.Click += BotaoAtualizarLista_Click;

            Controls.Add(ListView);
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

        private void BotaoAtualizarLista_Click(object sender, EventArgs e)
        {

            ListView.DataSource = modelocrud.Modelos.Where(m => m.GetType() == Tipo || m.GetType().IsSubclassOf(Tipo)).ToList();


            if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0 && Tipo.IsAbstract)
                ListView.DataSource = modelocrud.Modelos.OfType<Celula>().ToList();

            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0 && Tipo.IsAbstract)
                ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList();
            
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
            this.Size = new Size(1100, 350);
            ListView.Dock = DockStyle.Left;

            if (Tipo == typeof(MudancaEstado))
            {
                Atualizar.Visible = false;
                Deletar.Visible = false;
            }
            
                ListView.DataSource = modelocrud.Modelos.Where(m => m.GetType() == Tipo
                || m.GetType().IsSubclassOf(Tipo)).OrderBy(m => m.Id).ToList();            

            if (ListView.Items.Count > 0)
                ListView.SetSelected(0, false);
            atualizarStatusBotao();
        }

        private void atualizarStatusBotao()
        {
            if (Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)) ||
                Tipo == typeof(Ministerio) || Tipo.IsSubclassOf(typeof(Ministerio)))
                MudancaEstado.Visible = true;

            AtualizarLista.Enabled = ListView.SelectedIndex >= 0;
            Detalhes.Enabled = ListView.SelectedIndex >= 0;
            Atualizar.Enabled = ListView.SelectedIndex >= 0;
            Deletar.Enabled = ListView.SelectedIndex >= 0;
            MudancaEstado.Enabled = ListView.SelectedIndex >= 0;
        }

        public void LoadFormCrud(modelocrud modelo, bool detalhes, bool deletar, bool atualizar, Form Atual)
        {
            crudForm.LoadFormCrud(modelo, detalhes, deletar, atualizar, Atual);
        }

        public void Clicar(Form form, string function, modelocrud Modelo = null,
            bool detalhes = false, bool deletar = false, bool atualizar = false)
        {
            crudForm.Clicar(form, function, Modelo, detalhes, deletar, atualizar);
        }
    }
}
