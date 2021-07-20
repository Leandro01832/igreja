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
            if (modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().Count > 0 && ListView is ListViewPessoa && Tipo.IsAbstract)
            {
                if (Tipo == typeof(business.classes.Abstrato.Pessoa))
                    ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<business.classes.Abstrato.Pessoa>().ToList();

                if (Tipo == typeof(PessoaDado))
                    ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<PessoaDado>().ToList();

                if (Tipo == typeof(PessoaLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<PessoaLgpd>().ToList();

                if (Tipo == typeof(MembroLgpd))
                    ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<MembroLgpd>().ToList();

                if (Tipo == typeof(Membro))
                    ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<Membro>().ToList();
            }

            if (modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().Count > 0 && ListView is ListViewCelula && Tipo.IsAbstract)
            ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList();            

            if (modelocrud.Modelos.OfType<Ministerio>().ToList().Count > 0 && ListView is ListViewMinisterio && Tipo.IsAbstract)
            ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList();            

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
               var Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().First(i => i.Codigo == ListView.numero);
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
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa(Modelo,
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
                  var  Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().First(i => i.Id == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro(Modelo, false, false, true);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMinisterio)
            {
                try
                {
                  var  Modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().First(i => i.Id == ListView.numero);
                    FinalizarCadastroMinisterio dp = new FinalizarCadastroMinisterio(Modelo,
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
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().First(i => i.Id == ListView.numero);
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
                   var Modelo = modelocrud.Modelos.OfType<MudancaEstado>().ToList().First(i => i.Id == ListView.numero);
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
                  var  Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa(Modelo
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
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().First(i => i.Id == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro(Modelo
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
                   var Modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().First(i => i.Id == ListView.numero);
                    FinalizarCadastroMinisterio dp =
                    new FinalizarCadastroMinisterio(Modelo, false, true, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewReuniao)
            {
                try
                {
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().First(i => i.Id == ListView.numero);
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
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().First(i => i.Codigo == ListView.numero);
                    FinalizarCadastroPessoa fc = new FinalizarCadastroPessoa(Modelo
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
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().First(i => i.Id == ListView.numero);
                    Celula.FinalizarCadastro dp =
                new Celula.FinalizarCadastro(Modelo, true, false, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewMinisterio)
            {
                try
                {
                   var Modelo = modelocrud.Modelos.OfType<Ministerio>().ToList().First(i => i.Id == ListView.numero);
                    FinalizarCadastroMinisterio dp =
                new FinalizarCadastroMinisterio(Modelo, true, false, false);
                    dp.MdiParent = this.MdiParent;
                    dp.Show();
                }
                catch {  }
            }

            if (ListView is ListViewReuniao)
            {
                try
                {
                   var Modelo = modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().First(i => i.Id == ListView.numero);
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
                    foreach (var m in modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList())
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().Count > 0 && condicao)
                        ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Codigo).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(business.classes.Abstrato.Celula)))
                {
                    foreach (var m in modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList())
                        if (Tipo.Name == m.GetType().Name)
                        {
                            condicao = true;
                            break;
                        }

                    if (modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().Count > 0 && condicao)
                        ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().Where(p => p.GetType().Name == Tipo.Name)
                            .OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo.IsSubclassOf(typeof(Ministerio)))
                {
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
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(business.classes.Reuniao))
                {
                    if (modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().Count > 0)
                        ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Reuniao>().ToList().OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }

                if (Tipo == typeof(MudancaEstado))
                {
                    if (modelocrud.Modelos.OfType<MudancaEstado>().ToList().Count > 0)
                        ListView.DataSource = modelocrud.Modelos.OfType<MudancaEstado>().ToList().OrderBy(p => p.Id).ToList();
                    else
                        ListView.DataSource = await AtualizarComProgressBar(Tipo);
                }
            }
            else 
            if (Tipo == typeof(business.classes.Abstrato.Celula) || Tipo == typeof(Ministerio))
            {
                if (Tipo == typeof(business.classes.Abstrato.Celula))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Celula>().ToList().OrderBy(p => p.Id).ToList();

                if (Tipo == typeof(Ministerio))                
                 ListView.DataSource = modelocrud.Modelos.OfType<Ministerio>().ToList().OrderBy(p => p.Id).ToList();                
            }
            else 
            if(Tipo == typeof(business.classes.Abstrato.Pessoa) || Tipo == typeof(PessoaDado) || Tipo == typeof(PessoaLgpd)
            || Tipo == typeof(MembroLgpd) || Tipo == typeof(Membro))
            {
                Mudanca.Visible = true;
                if (Tipo == typeof(business.classes.Abstrato.Pessoa))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OrderBy(p => p.Id).ToList();                

                if (Tipo == typeof(PessoaDado))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<PessoaDado>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(PessoaLgpd))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<PessoaLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(MembroLgpd))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<MembroLgpd>().OrderBy(p => p.Codigo).ToList();

                if (Tipo == typeof(Membro))
                ListView.DataSource = modelocrud.Modelos.OfType<business.classes.Abstrato.Pessoa>().ToList().OfType<Membro>().OrderBy(p => p.Codigo).ToList();
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
