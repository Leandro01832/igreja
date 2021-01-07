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

        public FormularioListView(TodosListViews ListView)
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

            InitializeComponent();
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {
            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            List<business.classes.Pessoas.PessoaDado> lista2 = new List<business.classes.Pessoas.PessoaDado>();
            foreach (var item in lista)
            lista2.Add((business.classes.Pessoas.PessoaDado)item);
            Modelo = lista2.First(i => i.Codigo == ListView.numero);
            Modelo = Modelo.recuperar(Modelo.Id)[0];

            FrmMudancaEstado frm = new FrmMudancaEstado(Modelo);
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private Button MudancaEstado { get; }
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
                List<business.classes.Pessoas.PessoaDado> lista2 = new List<business.classes.Pessoas.PessoaDado>();
                foreach (var item in lista)
                lista2.Add((business.classes.Pessoas.PessoaDado)item);
                Modelo = lista2.First(i =>  i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaDado)Modelo
                , false, false, true);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WindowsFormsApp1.Formulario.Celula.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
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
                List<business.classes.Pessoas.PessoaDado> lista2 = new List<business.classes.Pessoas.PessoaDado>();
                foreach (var item in lista)
                lista2.Add((business.classes.Pessoas.PessoaDado)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaDado)Modelo
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

                WindowsFormsApp1.Formulario.Celula.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                List<business.classes.Abstrato.Ministerio> lista2 = new List<business.classes.Abstrato.Ministerio>();
                foreach (var item in lista)
                lista2.Add((business.classes.Abstrato.Ministerio)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , false, true, false);
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
                List<business.classes.Pessoas.PessoaDado> lista2 = new List<business.classes.Pessoas.PessoaDado>();
                foreach (var item in lista)
                lista2.Add((business.classes.Pessoas.PessoaDado)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaDado)Modelo
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

                WindowsFormsApp1.Formulario.Celula.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                List<business.classes.Abstrato.Ministerio> lista2 = new List<business.classes.Abstrato.Ministerio>();
                foreach (var item in lista)
                lista2.Add((business.classes.Abstrato.Ministerio)item);
                Modelo = lista2.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , true, false, false);
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
                if(Modelo is business.classes.Pessoas.PessoaDado)
                MudancaEstado.Visible = true;
            }            
            else
            {
                if (Tipo == "Celula")
                    lista = await Task.Run(() => business.classes.Abstrato.Celula.recuperarTodasCelulas());

                if (Tipo == "Ministerio")
                    lista = await Task.Run(() => business.classes.Abstrato.Ministerio.recuperarTodosMinisterios());

                if (Tipo == "Membro")
                {
                    lista = await Task.Run(() => business.classes.Abstrato.Membro.recuperarTodosMembros());
                    MudancaEstado.Visible = true;
                }
                    

                if (Tipo == "Pessoa")
                {
                    lista = await Task.Run(() => business.classes.Pessoas.PessoaDado.recuperarTodos());
                    MudancaEstado.Visible = true;
                }
                    
            }


            ListView.Dock = DockStyle.Left;

            if (lista != null)
                foreach (var v in lista)
                {
                    if (v is business.classes.Pessoas.PessoaDado)
                    {
                        business.classes.Pessoas.PessoaDado p;
                        switch (v.GetType().Name)
                        {
                            case "Pessoa":
                                p = (business.classes.Pessoas.PessoaDado)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Crianca":
                                p = (business.classes.Pessoas.Crianca)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Membro":
                                p = (business.classes.Abstrato.Membro)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Membro_Aclamacao":
                                p = (business.classes.Pessoas.Membro_Aclamacao)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Membro_Reconciliacao":
                                p = (business.classes.Pessoas.Membro_Reconciliacao)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Membro_Batismo":
                                p = (business.classes.Pessoas.Membro_Batismo)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Membro_Transferencia":
                                p = (business.classes.Pessoas.Membro_Transferencia)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;

                            case "Visitante":
                                p = (business.classes.Pessoas.Visitante)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Nome);

                                break;
                        }
                    }
                    else
                    if (v is business.classes.Abstrato.Ministerio)
                    {
                        business.classes.Abstrato.Ministerio m;
                        switch (v.GetType().Name)
                        {

                            case "Lider_Celula":
                                m = (business.classes.Ministerio.Lider_Celula)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Lider_Celula_Treinamento":
                                m = (business.classes.Ministerio.Lider_Celula_Treinamento)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Lider_Ministerio":
                                m = (business.classes.Ministerio.Lider_Ministerio)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Lider_Ministerio_Treinamento":
                                m = (business.classes.Ministerio.Lider_Ministerio_Treinamento)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Supervisor_Celula":
                                m = (business.classes.Ministerio.Supervisor_Celula)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Supervisor_Celula_Treinamento":
                                m = (business.classes.Ministerio.Supervisor_Celula_Treinamento)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Supervisor_Ministerio":
                                m = (business.classes.Ministerio.Supervisor_Ministerio)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;

                            case "Supervisor_Ministerio_Treinamento":
                                m = (business.classes.Ministerio.Supervisor_Ministerio_Treinamento)v;
                                ListView.Items.Add(m.Id.ToString() + " - " + m.Nome);

                                break;
                        }
                    }

                    else
                    if (v is business.classes.Abstrato.Celula)
                    {
                        business.classes.Abstrato.Celula c;
                        switch (v.GetType().Name)
                        {

                            case "Celula_Adolescente":
                                c = (business.classes.Celulas.Celula_Adolescente)v;
                                ListView.Items.Add(c.Id.ToString() + " - " + c.Nome);

                                break;

                            case "Celula_Adulto":
                                c = (business.classes.Celulas.Celula_Adulto)v;
                                ListView.Items.Add(c.Id.ToString() + " - " + c.Nome);

                                break;

                            case "Celula_Casado":
                                c = (business.classes.Celulas.Celula_Casado)v;
                                ListView.Items.Add(c.Id.ToString() + " - " + c.Nome);

                                break;

                            case "Celula_Crianca":
                                c = (business.classes.Celulas.Celula_Crianca)v;
                                ListView.Items.Add(c.Id.ToString() + " - " + c.Nome);

                                break;

                            case "Celula_Jovem":
                                c = (business.classes.Celulas.Celula_Jovem)v;
                                ListView.Items.Add(c.Id.ToString() + " - " + c.Nome);

                                break;
                        }
                    }
                }
        }
    }
}
