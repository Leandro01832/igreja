using business.classes;
using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.Formulario.Reuniao;
using WindowsFormsApp1.ListViews;


namespace WindowsFormsApp1.Formulario
{
    public partial class FormularioListView : FormPadrao
    {
        public FormularioListView() { }

        List<modelocrud> lista;

        public FormularioListView(TodosListViews ListView)
        {
            this.Modelo = ListView.Modelo;
            this.Tipo = ListView.Tipo;            

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

            Controls.Add(ListView);
            Controls.Add(botaoDetalhes);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDeletar);
            Controls.Add(Mudanca);
            this.ListView = ListView;
            InitializeComponent();
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            Modelo = lista.OfType<business.classes.Abstrato.Pessoa>().First(i => i.Codigo == ListView.numero);
            // Modelo = Modelo.recuperar(ListView.numero)[0];

            FrmMudancaEstado frm = new FrmMudancaEstado(Modelo);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private Button Mudanca { get; }
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        public modelocrud Modelo { get; set; }
        public TodosListViews ListView { get; }
        public string Tipo { get; set; }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            if (ListView is ListViewPessoa)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Pessoa>().First(i => i.Codigo == ListView.numero);


                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo
                , false, false, true);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Celula>().First(i => i.IdCelula == ListView.numero);


                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.OfType<Ministerio>().First(i => i.IdMinisterio == ListView.numero);


                FinalizarCadastroMinisterio dp = new FinalizarCadastroMinisterio((Ministerio)Modelo,
                false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewReuniao)
            {
                Modelo = lista.OfType<business.classes.Reuniao>().First(i => i.IdReuniao == ListView.numero);


                FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, false, false, true);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }

            if (ListView is ListViewMudanca)
            {
                Modelo = lista.OfType<MudancaEstado>().First(i => i.IdMudanca == ListView.numero);


                DetalhesMudancaEstado frm = new DetalhesMudancaEstado(Modelo, false, false, true);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            if (ListView is ListViewPessoa)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Pessoa>().First(i => i.Codigo == ListView.numero);


                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo
                , false, true, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Celula>().First(i => i.IdCelula == ListView.numero);


                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.OfType<Ministerio>().First(i => i.IdMinisterio == ListView.numero);


                FinalizarCadastroMinisterio dp =
                new FinalizarCadastroMinisterio((Ministerio)Modelo, false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewReuniao)
            {
                Modelo = lista.OfType<business.classes.Reuniao>().First(i => i.IdReuniao == ListView.numero);


                FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, false, true, false);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }

            if (ListView is ListViewPessoa)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Pessoa>().First(i => i.Codigo == ListView.numero);


                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo
                , true, false, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.OfType<business.classes.Abstrato.Celula>().First(i => i.IdCelula == ListView.numero);


                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.OfType<Ministerio>().First(i => i.IdMinisterio == ListView.numero);


                FinalizarCadastroMinisterio dp =
            new FinalizarCadastroMinisterio((Ministerio)Modelo, true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewReuniao)
            {
                Modelo = lista.OfType<business.classes.Reuniao>().First(i => i.IdReuniao == ListView.numero);


                FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, true, false, false);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }

        }

        private async void FormularioListView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 350);
            ListView.Dock = DockStyle.Left;

            if (Modelo is MudancaEstado)
            {
                botaoAtualizar.Visible = false;
                botaoDeletar.Visible = false;
            }

            lista = new List<modelocrud>();
            if (Modelo != null)
            {
                FormProgressBar form = new FormProgressBar();
                form.MdiParent = this.MdiParent;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Text = $"Barra de processamento - {Modelo.GetType().Name}";
                form.Show();
                lista = await Task.Run(() => Modelo.recuperar(null));
                form.Close();
                if (Modelo is business.classes.Abstrato.Pessoa)
                    Mudanca.Visible = true;
            }
            else
            {
                if (Tipo == "Celula")
                {
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaCelulas)
                    lista.Add(item);
                    
                    
                }
                    

                if (Tipo == "Ministerio")
                {
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaMinisterios)
                        lista.Add(item);
                }
                    

                if (Tipo == "Pessoa")
                {
                    Mudanca.Visible = true;
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaPessoas)
                        lista.Add(item);
                }

                if (Tipo == "PessoaDado")
                {
                    Mudanca.Visible = true;
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaPessoas.OfType<PessoaDado>())
                        lista.Add(item);
                }


                if (Tipo == "PessoaLgpd")
                {
                    Mudanca.Visible = true;
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaPessoas.OfType<PessoaLgpd>())
                        lista.Add(item);
                }


                if (Tipo == "MembroLgpd")
                {
                    Mudanca.Visible = true;
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaPessoas.OfType<MembroLgpd>())
                        lista.Add(item);
                }


                if (Tipo == "Membro")
                {
                    Mudanca.Visible = true;
                    var modelos = new List<modelocrud>();
                    foreach (var item in listaPessoas.OfType<Membro>())
                        lista.Add(item);
                }

            }

            if (lista != null)
            {

                foreach (var v in lista)
                {
                    ListView.Items.Add(v.ToString());
                }
            }
        }
    }
}
