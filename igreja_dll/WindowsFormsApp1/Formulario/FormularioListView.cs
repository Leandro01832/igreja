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

            this.Tipo = ListBox.Tipo;          

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
            if (business.classes.Abstrato.Pessoa.listaPessoas.Count > 0 && ListView is ListViewPessoa && Tipo.IsAbstract)
            {
                if (Tipo == typeof(business.classes.Abstrato.Pessoa))
                    ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<business.classes.Abstrato.Pessoa>().ToList();

                if (Tipo == typeof(PessoaDado))
                    ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<PessoaDado>().ToList();

                if (Tipo == typeof(PessoaLgpd))
                    ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<PessoaLgpd>().ToList();

                if (Tipo == typeof(MembroLgpd))
                    ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<MembroLgpd>().ToList();

                if (Tipo == typeof(Membro))
                    ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<Membro>().ToList();
            }

            if (business.classes.Abstrato.Celula.listaCelulas.Count > 0 && ListView is ListViewCelula && Tipo.IsAbstract)
            ListView.DataSource = business.classes.Abstrato.Celula.listaCelulas;            

            if (Ministerio.listaMinisterios.Count > 0 && ListView is ListViewMinisterio && Tipo.IsAbstract)
            ListView.DataSource = Ministerio.listaMinisterios;            

            if (!Tipo.IsAbstract && atualizar)
            ListView.DataSource = await AtualizarComModelo(Tipo);                  
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
               var Modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.Codigo == ListView.numero);
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
        private Type Tipo = null;
        public TodosListViews ListView { get; }

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
                   var Modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.Codigo == ListView.numero);
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
                  var  Modelo = business.classes.Abstrato.Celula.listaCelulas.First(i => i.IdCelula == ListView.numero);
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
                  var  Modelo = Ministerio.listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
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
                   var Modelo = business.classes.Reuniao.Reunioes.First(i => i.IdReuniao == ListView.numero);
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
                   var Modelo = MudancaEstado.Mudancas.First(i => i.IdMudanca == ListView.numero);
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
                  var  Modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.Codigo == ListView.numero);
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
                   var Modelo = business.classes.Abstrato.Celula.listaCelulas.First(i => i.IdCelula == ListView.numero);
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
                   var Modelo = Ministerio.listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
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
                   var Modelo = business.classes.Reuniao.Reunioes.First(i => i.IdReuniao == ListView.numero);
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
                   var Modelo = business.classes.Abstrato.Pessoa.listaPessoas.First(i => i.Codigo == ListView.numero);
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
                   var Modelo = business.classes.Abstrato.Celula.listaCelulas.First(i => i.IdCelula == ListView.numero);
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
                   var Modelo = Ministerio.listaMinisterios.First(i => i.IdMinisterio == ListView.numero);
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
                   var Modelo = business.classes.Reuniao.Reunioes.First(i => i.IdReuniao == ListView.numero);
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


                if (Tipo.IsSubclassOf(typeof(business.classes.Abstrato.Pessoa)))
                {
                    Mudanca.Visible = true;
                    foreach (var m in business.classes.Abstrato.Pessoa.listaPessoas)
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (business.classes.Abstrato.Pessoa.listaPessoas.Count > 0 && condicao)
                        ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Codigo).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(business.classes.Abstrato.Celula)))
                {
                    foreach (var m in business.classes.Abstrato.Celula.listaCelulas)
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (business.classes.Abstrato.Celula.listaCelulas.Count > 0 && condicao)
                        ListView.DataSource = business.classes.Abstrato.Celula.listaCelulas.Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.IdCelula).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(Ministerio)))
                {
                    foreach (var m in Ministerio.listaMinisterios)
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (Ministerio.listaMinisterios.Count > 0 && condicao)
                        ListView.DataSource = Ministerio.listaMinisterios.Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.IdMinisterio).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(business.classes.Reuniao))
                {
                    if (business.classes.Reuniao.Reunioes.Count > 0)
                        ListView.DataSource = business.classes.Reuniao.Reunioes.OrderBy(p => p.IdReuniao).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(MudancaEstado))
                {
                    if (MudancaEstado.Mudancas.Count > 0)
                        ListView.DataSource = MudancaEstado.Mudancas.OrderBy(p => p.IdMudanca).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }
            }
            else 
            if (Tipo == typeof(business.classes.Abstrato.Celula) || Tipo == typeof(Ministerio))
            {
                if (Tipo == typeof(business.classes.Abstrato.Celula))
                ListView.DataSource = business.classes.Abstrato.Celula.listaCelulas.OrderBy(p => p.IdCelula).ToList();

                if (Tipo == typeof(Ministerio))                
                 ListView.DataSource = Ministerio.listaMinisterios.OrderBy(p => p.IdMinisterio).ToList();                
            }
            else 
            if(Tipo == typeof(business.classes.Abstrato.Pessoa) || Tipo == typeof(PessoaDado) || Tipo == typeof(PessoaLgpd)
            || Tipo == typeof(MembroLgpd) || Tipo == typeof(Membro))
            {
                Mudanca.Visible = true;
                if (Tipo == typeof(business.classes.Abstrato.Pessoa))
                ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OrderBy(p => p.IdPessoa).ToList();                

                if (Tipo == typeof(PessoaDado))
                ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<PessoaDado>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(PessoaLgpd))
                ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<PessoaLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(MembroLgpd))
                ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<MembroLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(Membro))
                ListView.DataSource = business.classes.Abstrato.Pessoa.listaPessoas.OfType<Membro>().OrderBy(p => p.Codigo).ToList();
            }

            atualizar = true;
            botaoAtualizarLista.Enabled = atualizar;
            botaoDetalhes.Enabled = atualizar;
            botaoAtualizar.Enabled = atualizar;
            botaoDeletar.Enabled = atualizar;
            Mudanca.Enabled = atualizar;

        }        
    }
}
