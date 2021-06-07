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
        bool atualizar = true;

        public FormularioListView(TodosListViews ListBox)
        {
            ListView = ListBox;
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

            botaoAtualizarLista = new Button();
            botaoAtualizarLista.Location = new Point(570, 360);
            botaoAtualizarLista.Size = new Size(100, 50);
            botaoAtualizarLista.Text = "Atualizar lista";
            botaoAtualizarLista.Click += BotaoAtualizarLista_Click;
            botaoAtualizarLista.Dock = DockStyle.Right;

            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled =       atualizar;
            botaoAtualizar.Enabled =      atualizar;
            botaoDeletar.Enabled =        atualizar;
            Mudanca.Enabled =             atualizar;

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
            if (listaPessoas.Count > 0 && ListView is ListViewPessoa && Modelo == null)
            {
                if (Tipo == "Pessoa")
                    ListView.DataSource = listaPessoas.OfType<business.classes.Abstrato.Pessoa>().ToList();

                if (Tipo == "PessoaDado")
                    ListView.DataSource = listaPessoas.OfType<PessoaDado>().ToList();

                if (Tipo == "PessoaLgpd")
                    ListView.DataSource = listaPessoas.OfType<PessoaLgpd>().ToList();

                if (Tipo == "MembroLgpd")
                    ListView.DataSource = listaPessoas.OfType<MembroLgpd>().ToList();

                if (Tipo == "Membro")
                    ListView.DataSource = listaPessoas.OfType<Membro>().ToList();
            }

            if (listaCelulas.Count > 0 && ListView is ListViewCelula && Modelo == null)
            ListView.DataSource = listaCelulas;            

            if (listaMinisterios.Count > 0 && ListView is ListViewMinisterio && Modelo == null)
            ListView.DataSource = listaMinisterios;            

            if (Modelo != null && atualizar)
            ListView.DataSource = await AtualizarComModelo(Modelo);                  
        }

        private void MudancaEstado_Click(object sender, EventArgs e)
        {

            if (ListView.numero == 0)
            {
                MessageBox.Show("Escolha um item da lista.");
                return;
            }
            try
            {
                Modelo = listaPessoas.First(i => i.Codigo == ListView.numero);
                FrmMudancaEstado frm = new FrmMudancaEstado(Modelo);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
            catch {  }
        }

        private Button Mudanca { get; }
        private Button botaoDetalhes { get; }
        private Button botaoAtualizar { get; }
        private Button botaoDeletar { get; }
        private Button botaoAtualizarLista { get; }
        private modelocrud Modelo { get; set; }
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
                try
                {
                    Modelo = listaPessoas.First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo,
                     false, false, true);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch {  }
            }

            if (ListView is ListViewCelula)
            {
                try
                {
                    Modelo = listaCelulas.First(i => i.IdCelula == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
                , false, false, true);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMinisterio)
            {
                try
                {
                    Modelo = listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
                    FinalizarCadastroMinisterio dp = new FinalizarCadastroMinisterio((Ministerio)Modelo,
                    false, false, true);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewReuniao)
            {
                try
                {
                    Modelo = listaReuniao.First(i => i.IdReuniao == ListView.numero);
                    FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, false, false, true);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMudanca)
            {
                try
                {
                    Modelo = listaMudancaEstado.First(i => i.IdMudanca == ListView.numero);
                    DetalhesMudancaEstado frm = new DetalhesMudancaEstado(Modelo, false, false, true);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                catch {  }
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
                try
                {
                    Modelo = listaPessoas.First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo
                    , false, true, false);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch {  }
            }

            if (ListView is ListViewCelula)
            {
                try
                {
                    Modelo = listaCelulas.First(i => i.IdCelula == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
                , false, true, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMinisterio)
            {
                try
                {
                    Modelo = listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
                    FinalizarCadastroMinisterio dp =
                    new FinalizarCadastroMinisterio((Ministerio)Modelo, false, true, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewReuniao)
            {
                try
                {
                    Modelo = listaReuniao.First(i => i.IdReuniao == ListView.numero);
                    FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, false, true, false);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                catch {  }
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
                try
                {
                    Modelo = listaPessoas.First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa((business.classes.Abstrato.Pessoa)Modelo
                    , true, false, false);
                    fc.MdiParent = this.MdiParent;
                    fc.Show();
                }
                catch {  }
            }

            if (ListView is ListViewCelula)
            {
                try
                {
                    Modelo = listaCelulas.First(i => i.IdCelula == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
                , true, false, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMinisterio)
            {
                try
                {
                    Modelo = listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
                    FinalizarCadastroMinisterio dp =
                new FinalizarCadastroMinisterio((Ministerio)Modelo, true, false, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewReuniao)
            {
                try
                {
                    Modelo = listaReuniao.First(i => i.IdReuniao == ListView.numero);
                    FinalizarCadastroReuniao frm = new FinalizarCadastroReuniao(Modelo, true, false, false);
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
                catch {  }
            }

        }

        private async void FormularioListView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 350);
            ListView.Dock = DockStyle.Left;

            if (Modelo is MudancaEstado)
            {
                botaoAtualizar.Visible = false;
                botaoDeletar.Visible = false;
            }
            
            if (Modelo != null)
            {
                bool condicao = false;
                atualizar = false;
                botaoAtualizarLista.Enabled = atualizar;
                botaoDetalhes.Enabled = atualizar;
                botaoAtualizar.Enabled = atualizar;
                botaoDeletar.Enabled = atualizar;
                Mudanca.Enabled = atualizar;


                if (Modelo is business.classes.Abstrato.Pessoa)
                {
                    Mudanca.Visible = true;
                    foreach (var m in listaPessoas)
                        if (Modelo.GetType().Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (listaPessoas.Count > 0 && condicao)
                        ListView.DataSource = listaPessoas.Where(p => p.GetType().Name == Modelo.GetType().Name)
                            .OrderBy(p => p.Codigo).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Modelo);
                }

                if (Modelo is business.classes.Abstrato.Celula)
                {
                    foreach (var m in listaCelulas)
                        if (Modelo.GetType().Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (listaCelulas.Count > 0 && condicao)
                        ListView.DataSource = listaCelulas.Where(p => p.GetType().Name == Modelo.GetType().Name)
                            .OrderBy(p => p.IdCelula).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Modelo);
                }

                if (Modelo is Ministerio)
                {
                    foreach (var m in listaMinisterios)
                        if (Modelo.GetType().Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (listaMinisterios.Count > 0 && condicao)
                        ListView.DataSource = listaMinisterios.Where(p => p.GetType().Name == Modelo.GetType().Name)
                            .OrderBy(p => p.IdMinisterio).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Modelo);
                }

                if (Modelo is business.classes.Reuniao)
                {
                    if (listaReuniao.Count > 0)
                        ListView.DataSource = listaReuniao.OrderBy(p => p.IdReuniao).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Modelo);
                }

                if (Modelo is MudancaEstado)
                {
                    if (listaReuniao.Count > 0)
                        ListView.DataSource = listaMudancaEstado.OrderBy(p => p.IdMudanca).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Modelo);
                }
            }
            else 
            if (Tipo == "Celula" || Tipo == "Ministerio")
            {
                if (Tipo == "Celula")
                ListView.DataSource = listaCelulas.OrderBy(p => p.IdCelula).ToList();

                if (Tipo == "Ministerio")                
                 ListView.DataSource = listaMinisterios.OrderBy(p => p.IdMinisterio).ToList();                
            }
            else 
            if(Tipo == "Pessoa" || Tipo == "PessoaDado" || Tipo == "PessoaLgpd" 
            || Tipo == "MembroLgpd" || Tipo == "Membro")
            {
                Mudanca.Visible = true;
                if (Tipo == "Pessoa")
                ListView.DataSource = listaPessoas.OrderBy(p => p.IdPessoa).ToList();                

                if (Tipo == "PessoaDado")
                ListView.DataSource = listaPessoas.OfType<PessoaDado>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == "PessoaLgpd")
                ListView.DataSource = listaPessoas.OfType<PessoaLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == "MembroLgpd")
                ListView.DataSource = listaPessoas.OfType<MembroLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == "Membro")
                ListView.DataSource = listaPessoas.OfType<Membro>().OrderBy(p => p.Codigo).ToList();
            }

            atualizar = true;
            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;
            Mudanca.Enabled = atualizar;

        }

        // Atualizar lista
        private void timer1_Tick(object sender, EventArgs e)
        {           
        }
    }
}
