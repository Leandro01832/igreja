using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.FormularioMinisterio;
using WindowsFormsApp1.Formulario.Pessoa;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario
{
    public partial class FormularioListView : Form
    {
        public FormularioListView()
        {

        }

        List<modelocrud> lista;

        public FormularioListView(TodosListViews ListView, bool Lgpd)
        {
            this.Modelo = ListView.Modelo;
            this.Tipo = ListView.Tipo;

            MudancaEstado = new Button();
            MudancaEstado.Location = new System.Drawing.Point(570, 40);
            MudancaEstado.Size = new System.Drawing.Size(100, 50);
            MudancaEstado.Text = "Mudança de estado";
            MudancaEstado.Click += MudancaEstado_Click;
            MudancaEstado.Dock = DockStyle.Right;
            MudancaEstado.Visible = false;

            botaoDeletar = new Button();
            botaoDeletar.Location = new System.Drawing.Point(570, 120);
            botaoDeletar.Size = new System.Drawing.Size(100, 50);
            botaoDeletar.Text = "Excluir";
            botaoDeletar.Click += botaoExcluir_Click;
            botaoDeletar.Dock = DockStyle.Right;

            botaoAtualizar = new Button();
            botaoAtualizar.Location = new System.Drawing.Point(570, 200);
            botaoAtualizar.Size = new System.Drawing.Size(100, 50);
            botaoAtualizar.Text = "Atualizar";
            botaoAtualizar.Click += botaoAtualizar_Click;
            botaoAtualizar.Dock = DockStyle.Right;

            botaoDetalhes = new Button();
            botaoDetalhes.Location = new System.Drawing.Point(570, 280);
            botaoDetalhes.Size = new System.Drawing.Size(100, 50);
            botaoDetalhes.Text = "Detalhes";
            botaoDetalhes.Click += BotaoDetalhes_Click;
            botaoDetalhes.Dock = DockStyle.Right;

            Controls.Add(ListView);
            Controls.Add(botaoDetalhes);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDeletar);
            Controls.Add(MudancaEstado);
            this.ListView = ListView;
            this.Lgpd = Lgpd;
            InitializeComponent();
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            List<business.classes.Abstrato.Pessoa> lista2 = new List<business.classes.Abstrato.Pessoa>();
            foreach (var item in lista)
            lista2.Add((business.classes.Abstrato.Pessoa)item);
            Modelo = lista2.First(i => i.Codigo == ListView.numero);
            Modelo = Modelo.recuperar(Modelo.Id)[0];

            FrmMudancaEstado frm = new FrmMudancaEstado(Modelo, Lgpd);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private Button MudancaEstado { get; }
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        public modelocrud Modelo { get; set; }
        public TodosListViews ListView { get; }
        public bool Lgpd { get; }
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
                List<PessoaDado> lista2 = new List<PessoaDado>();
                foreach (var item in lista)
                lista2.Add((PessoaDado)item);
                Modelo = lista2.First(i =>  i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((PessoaDado)Modelo
                , false, false, true);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FormularioMinisterio.FinalizarCadastroMinisterio dp =
            new FormularioMinisterio.FinalizarCadastroMinisterio((Ministerio)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }
        }
        
        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            if(ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            if (ListView is ListViewPessoa)
            {
                List<PessoaDado> lista2 = new List<PessoaDado>();
                foreach (var item in lista)
                lista2.Add((PessoaDado)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((PessoaDado)Modelo
                , false, true, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                List<business.classes.Abstrato.Celula> lista2 = new List<business.classes.Abstrato.Celula>();
                foreach (var item in lista)
                lista2.Add((business.classes.Abstrato.Celula)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                List<Ministerio> lista2 = new List<Ministerio>();
                foreach (var item in lista)
                lista2.Add((Ministerio)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastroMinisterio dp =
                new FinalizarCadastroMinisterio((Ministerio)Modelo, false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
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
                List<PessoaDado> lista2 = new List<PessoaDado>();
                foreach (var item in lista)
                lista2.Add((PessoaDado)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((PessoaDado)Modelo
                , true, false, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                List<business.classes.Abstrato.Celula> lista2 = new List<business.classes.Abstrato.Celula>();
                foreach (var item in lista)
                lista2.Add((business.classes.Abstrato.Celula)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                Celula.FinalizarCadastro dp =
            new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                List<Ministerio> lista2 = new List<Ministerio>();
                foreach (var item in lista)
                lista2.Add((Ministerio)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastroMinisterio dp =
            new FinalizarCadastroMinisterio((Ministerio)Modelo, true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }
        
        private async void FormularioListView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 350);
            lista = new List<modelocrud>();
            if (Modelo != null)
            {
                lista = await Task.Run(() => Modelo.recuperar(null));
                if(Modelo is business.classes.Abstrato.Pessoa)
                MudancaEstado.Visible = true;
            }            
            else
            {
                if (Tipo == "Celula")
                    lista = await Task.Run(() => business.classes.Abstrato.Celula.recuperarTodasCelulas());

                if (Tipo == "Ministerio")
                    lista = await Task.Run(() => Ministerio.recuperarTodosMinisterios());

                if (Tipo == "Membro")
                {
                    lista = await Task.Run(() => Membro.recuperarTodosMembros());
                    MudancaEstado.Visible = true;
                }
                    

                if (Tipo == "Pessoa")
                {
                    lista = await Task.Run(() => business.classes.Abstrato.Pessoa.recuperarTodos());
                    MudancaEstado.Visible = true;
                }
                    
            }


            ListView.Dock = DockStyle.Left;

            if (lista != null)
                foreach (var v in lista)
                {
                    ListView.Items.Add(v.ToString());
                }
        }
    }
}
