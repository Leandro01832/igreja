using business.classes.Abstrato;
using business.classes.Pessoas;
using business.implementacao;
using database;
using System;
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

        private async void BotaoAtualizarLista_Click(object sender, EventArgs e)
        {
            if (Tipo == typeof(Pessoa) || Tipo.IsSubclassOf(typeof(Pessoa)))
            {
                if (Tipo == typeof(Pessoa))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Pessoa>().ToList();

                if (Tipo == typeof(PessoaDado))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<PessoaDado>().ToList();

                if (Tipo == typeof(PessoaLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<PessoaLgpd>().ToList();

                if (Tipo == typeof(MembroLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<MembroLgpd>().ToList();

                if (Tipo == typeof(Membro))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro>().ToList();
            }

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
                    FrmMudancaEstado frm = new FrmMudancaEstado((modelocrud)ListView.SelectedItem);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                catch { }
            }

            if (Tipo == typeof(Ministerio) || Tipo.IsSubclassOf(typeof(Ministerio)))
            {
                try
                {
                    FrmMudancaEstadoMinisterio frm = new FrmMudancaEstadoMinisterio((modelocrud)ListView.SelectedItem);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
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

            if (!Tipo.IsAbstract)
            {
                bool condicao = false;
                atualizar = false;
                botaoAtualizarLista.Enabled = atualizar;
                botaoDetalhes.Enabled = atualizar;
                botaoAtualizar.Enabled = atualizar;
                botaoDeletar.Enabled = atualizar;
                Mudanca.Enabled = atualizar;


                if (Tipo.IsSubclassOf(typeof(Pessoa)))
                {
                    Mudanca.Visible = true;
                    foreach (var m in modelocrud.Modelos.OfType<Pessoa>().ToList())
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (modelocrud.Modelos.OfType<Pessoa>().ToList().Count > 0 && condicao)
                        ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Codigo).ToList();
                    else
                        ListView.DataSource = await FormPadrao.AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(Celula)))
                {
                    foreach (var m in modelocrud.Modelos.OfType<Celula>().ToList())
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (modelocrud.Modelos.OfType<Celula>().ToList().Count > 0 && condicao)
                        ListView.DataSource = modelocrud.Modelos.OfType<Celula>().ToList().Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await FormPadrao.AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(Ministerio)))
                {
                    Mudanca.Visible = true;
                    foreach (var m in modelocrud.Modelos.OfType<Ministerio>().ToList())
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0 && condicao)
                        ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList().Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await FormPadrao.AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(business.classes.Reuniao))
                {
                    if (modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().Count > 0)
                        ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await FormPadrao.AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(MudancaEstado))
                {
                    if (modelocrud.Modelos.OfType<MudancaEstado>().ToList().Count > 0)
                        ListView.DataSource = modelocrud.Modelos.OfType<MudancaEstado>().ToList().OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await FormPadrao.AtualizarComProgressBar(Tipo);
                }
            }
            else
            if (Tipo == typeof(Celula) || Tipo == typeof(Ministerio))
            {
                if (Tipo == typeof(Celula))
                    ListView.DataSource = modelocrud.Modelos.OfType<Celula>().ToList().OrderBy(p => p.Id).ToList();

                if (Tipo == typeof(Ministerio))
                    ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList().OrderBy(p => p.Id).ToList();
            }
            else
            if (Tipo == typeof(Pessoa) || Tipo == typeof(PessoaDado) || Tipo == typeof(PessoaLgpd)
            || Tipo == typeof(MembroLgpd) || Tipo == typeof(Membro))
            {
                Mudanca.Visible = true;
                if (Tipo == typeof(Pessoa))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OrderBy(p => p.Id).ToList();

                if (Tipo == typeof(PessoaDado))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<PessoaDado>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(PessoaLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<PessoaLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(MembroLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<MembroLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(Membro))
                    ListView.DataSource = modelocrud.Modelos.OfType<Pessoa>().ToList().OfType<Membro>().OrderBy(p => p.Codigo).ToList();
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

                if (ListView.SelectedItem.GetType().BaseType == typeof(modelocrud))
                    foreach (var item in listaTypes)
                        foreach (var item2 in lista)
                            if ("Frm" + ListView.SelectedItem.GetType().Name == item2.Name)
                                result = (WFCrud)Activator.CreateInstance(item2);

                if (ListView.SelectedItem.GetType().BaseType != typeof(modelocrud))
                {
                    Type BaseModel = ReturnBase(ListView.SelectedItem.GetType());

                    foreach (var item in listaTypes)
                        foreach (var item2 in lista)
                            if ("Frm" + BaseModel.Name == item2.Name)
                                result = (WFCrud)Activator.CreateInstance(item2);
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

        private Type ReturnBase(Type type)
        {
            if (type.BaseType != typeof(modelocrud))
                ReturnBase(type.BaseType);         
                return type;
        }
    }
}
