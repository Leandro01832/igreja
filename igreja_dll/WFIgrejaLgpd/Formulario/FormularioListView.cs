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
using WFIgrejaLgpd.Formulario.Pessoa;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario
{
    public partial class FormularioListView : Form
    {
        public FormularioListView()
        {

        }

        List<modelocrud> lista;

        public FormularioListView(TodosListViews ListView)
        {
            this.Tipo = ListView.Tipo;
            this.Modelo = ListView.Modelo;

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
            List<business.classes.Pessoas.PessoaLgpd> lista2 = new List<business.classes.Pessoas.PessoaLgpd>();
            foreach (var item in lista)
                lista2.Add((business.classes.Pessoas.PessoaLgpd)item);
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
            if (ListView is ListViewPessoa)
            {
                List<business.classes.Pessoas.PessoaLgpd> lista2 = new List<business.classes.Pessoas.PessoaLgpd>();
                foreach (var item in lista)
                    lista2.Add((business.classes.Pessoas.PessoaLgpd)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaLgpd)Modelo
                , false, false, true);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , false, false, true);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            if (ListView is ListViewPessoa)
            {
                List<business.classes.Pessoas.PessoaLgpd> lista2 = new List<business.classes.Pessoas.PessoaLgpd>();
                foreach (var item in lista)
                    lista2.Add((business.classes.Pessoas.PessoaLgpd)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);

                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaLgpd)Modelo
                , false, true, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);

                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , false, true, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }        

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            if (ListView is ListViewPessoa)
            {
                List<business.classes.Pessoas.PessoaLgpd> lista2 = new List<business.classes.Pessoas.PessoaLgpd>();
                foreach (var item in lista)
                    lista2.Add((business.classes.Pessoas.PessoaLgpd)item);
                Modelo = lista2.First(i => i.Codigo == ListView.numero);

                Modelo = Modelo.recuperar(Modelo.Id)[0];

                FinalizarCadastro fc = new FinalizarCadastro((business.classes.Pessoas.PessoaLgpd)Modelo
                , true, false, false);
                fc.MdiParent = this.MdiParent;
                fc.Show();
            }

            if (ListView is ListViewCelula)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

            if (ListView is ListViewMinisterio)
            {
                Modelo = lista.First(i => i.Id == ListView.numero);
                Modelo = Modelo.recuperar(Modelo.Id)[0];

                WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro dp =
            new WFIgrejaLgpd.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , true, false, false);
                dp.MdiParent = this.MdiParent;
                dp.Show();
            }

        }
        
        private async void FormularioListView_Load(object sender, EventArgs e)
        {
             lista = new List<modelocrud>();
            if (Modelo != null)
                lista = await Task.Run(() => Modelo.recuperar(null));
            else
            {
                if (Tipo == "Celula")
                    lista = await Task.Run(() => business.classes.Abstrato.Celula.recuperarTodasCelulas());

                if (Tipo == "Ministerio")
                    lista = await Task.Run(() => business.classes.Abstrato.Ministerio.recuperarTodosMinisterios());

                if (Tipo == "MembroLgpd")
                    lista = await Task.Run(() => business.classes.Abstrato.MembroLgpd.recuperarTodosMembros());

                if (Tipo == "PessoaLgpd")
                    lista = await Task.Run(() => business.classes.Pessoas.PessoaLgpd.recuperarTodos());
            }



            ListView.Dock = DockStyle.Left;

            if (lista != null)
                foreach (var v in lista)
                {
                    if (v is business.classes.Pessoas.PessoaLgpd)
                    {
                        business.classes.Pessoas.PessoaLgpd p;
                        switch (v.GetType().Name)
                        {
                            case "Pessoa":
                                p = (business.classes.Pessoas.PessoaLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Crianca":
                                p = (business.classes.PessoasLgpd.CriancaLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Membro":
                                p = (business.classes.Abstrato.MembroLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Membro_Aclamacao":
                                p = (business.classes.PessoasLgpd.Membro_AclamacaoLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Membro_Reconciliacao":
                                p = (business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Membro_Batismo":
                                p = (business.classes.PessoasLgpd.Membro_BatismoLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Membro_Transferencia":
                                p = (business.classes.PessoasLgpd.Membro_TransferenciaLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

                                break;

                            case "Visitante":
                                p = (business.classes.PessoasLgpd.VisitanteLgpd)v;
                                ListView.Items.Add(p.Codigo.ToString() + " - " + p.Email);

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
