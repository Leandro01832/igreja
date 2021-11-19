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
    public partial class FormularioListView : Form
    {
        public FormularioListView() { }
        bool atualizar = true;

        WFCrud result = null;
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
            this.Tipo = tipo;

            ListView = new ListBox();

            // this.View = View.Tile;
            ListView.Size = new Size(600, 300);
            ListView.Location = new Point(50, 50);
            ListView.Font = new Font("Arial", 15);

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

            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;
            Mudanca.Enabled = atualizar;

            Controls.Add(ListView);
            Controls.Add(botaoDetalhes);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDeletar);
            Controls.Add(Mudanca);
            Controls.Add(botaoAtualizarLista);
            this.ListView = ListView;
            InitializeComponent();
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

            if (!Tipo.IsAbstract && atualizar)
                ListView.DataSource = await FormPadrao.AtualizarComModelo(Tipo);
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {
            if (Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                try
                {
                    result = new FrmMudancaEstado((modelocrud)ListView.SelectedItem);
                    result.MdiParent = this.MdiParent;
                    result.Show();
                }
                catch { }
            }

            if (Tipo == typeof(Ministerio) || Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                try
                {
                    result = new FrmMudancaEstadoMinisterio((modelocrud)ListView.SelectedItem);
                    result.MdiParent = this.MdiParent;
                    result.Show();
                }
                catch { }
            }
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(true, false, false);
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(false, true, false);
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            AbrirFrmCrud(false, false, true);
        }

        private async void FormularioListView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 350);
            ListView.Dock = DockStyle.Left;

            if (Tipo == typeof(MudancaEstado))
            {
                botaoAtualizar.Visible = false;
                botaoDeletar.Visible = false;
            }


            atualizar = false;
            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;
            Mudanca.Enabled = atualizar;

            ListView.DataSource = modelocrud.Modelos.Where(m => m.GetType() == Tipo
            || m.GetType().IsSubclassOf(Tipo)).OrderBy(m => m.Id).ToList();


            if (modelocrud.Modelos.Where(m => m.GetType() == Tipo || m.GetType().IsSubclassOf(Tipo)).ToList().Count == 0)
            {
                var lista = await FormPadrao.AtualizarComProgressBar(Tipo);
                ListView.DataSource = lista.OrderBy(m => m.Id).ToList();
            }

            atualizar = true;
            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;
            Mudanca.Enabled = atualizar;

        }


        private void AbrirFrmCrud(bool detalhes, bool atualizar, bool deletar)
        {
            try
            {
                var lista = modelocrud.listTypes(typeof(WFCrud));
                var listaTypes = modelocrud.listTypes(typeof(modelocrud));

                Type BaseModel = modelocrud.ReturnBase(ListView.SelectedItem.GetType());

                foreach (var item in listaTypes)
                {
                    foreach (var item2 in lista)
                        if ("Frm" + BaseModel.Name == item2.Name)
                        {
                            result = (WFCrud)Activator.CreateInstance(item2);
                            break;
                        }
                        else if ("Frm" + ListView.SelectedItem.GetType().Name == item2.Name)
                        {
                            result = (WFCrud)Activator.CreateInstance(item2);
                            break;
                        }
                    if (result != null) break;
                }


                result.modelo = (modelocrud)ListView.SelectedItem;
                result.CondicaoDetalhes = detalhes;
                result.CondicaoDeletar = deletar;
                result.CondicaoAtualizar = atualizar;
                result.MdiParent = this.MdiParent;
                result.Show();
            }
            catch { }
        }
        
    }
}
