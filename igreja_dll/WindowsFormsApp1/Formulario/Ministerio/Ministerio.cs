using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Ministerio
{
    public partial class Ministerio : Form
    {
        ListView Ministerios;
        public Button botaoDetalhes;
        public Button botaoExcluir;
        public Button botaoAtualizar;
        public modelocrud Modelo { get; set; }

        public Ministerio()
        {
            var lista = business.classes.Abstrato.Ministerio.recuperarTodosMinisterios();

            Ministerios = new ListView();
            Ministerios.View = View.List;
            Ministerios.ItemSelectionChanged += Ministerios_ItemSelectionChanged;
            Ministerios.Size = new System.Drawing.Size(500, 300);
            Ministerios.Location = new System.Drawing.Point(50, 50);
            Ministerios.Font = new System.Drawing.Font("Arial", 15);

            foreach (var item in lista)
            {
                business.classes.Abstrato.Ministerio p = (business.classes.Abstrato.Ministerio)item;
                Ministerios.Items.Add(p.Id.ToString() + " - " + p.Nome);
            }

            botaoExcluir = new Button();
            botaoExcluir.Location = new System.Drawing.Point(570, 120);
            botaoExcluir.Size = new System.Drawing.Size(100, 50);
            botaoExcluir.Text = "Excluir";
            botaoExcluir.Click += botaoExcluir_Click;
            botaoExcluir.Dock = DockStyle.Right;

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

            Controls.Add(Ministerios);
            Controls.Add(botaoExcluir);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDetalhes);


            InitializeComponent();
        }

        private void Ministerios_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                Ministerios.Text = Ministerios.SelectedItems[0].Text;
            }
            catch (Exception)
            {
            }
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Ministerios.Text, @"\d+").Value;
            Modelo = business.classes.Abstrato.Ministerio.recuperarMinisterio(int.Parse(numero));
            VerificarModelo();

            WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , false, false, true);
            dp.MdiParent = this.MdiParent;
            dp.Show();
        }

        private void VerificarModelo()
        {
            if (Modelo is business.classes.Ministerio.Lider_Celula)
                Modelo =
                new business.classes.Ministerio.Lider_Celula(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Lider_Celula_Treinamento)
                Modelo =
                new business.classes.Ministerio.Lider_Celula_Treinamento(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Lider_Ministerio)
                Modelo =
                new business.classes.Ministerio.Lider_Ministerio(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Lider_Ministerio_Treinamento)
                Modelo =
                new business.classes.Ministerio.Lider_Ministerio_Treinamento(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Supervisor_Celula)
                Modelo =
                new business.classes.Ministerio.Supervisor_Celula(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Supervisor_Celula_Treinamento)
                Modelo =
                new business.classes.Ministerio.Supervisor_Celula_Treinamento(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Supervisor_Ministerio)
                Modelo =
                new business.classes.Ministerio.Supervisor_Ministerio(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Ministerio.Supervisor_Ministerio_Treinamento)
                Modelo =
                new business.classes.Ministerio.Supervisor_Ministerio_Treinamento(Modelo.Id, true).recuperar(Modelo.Id)[0];
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Ministerios.Text, @"\d+").Value;
            Modelo = business.classes.Abstrato.Ministerio.recuperarMinisterio(int.Parse(numero));
            VerificarModelo();

            WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , false, true, false);
            dp.MdiParent = this.MdiParent;
            dp.Show();            
        }
        
        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Ministerios.Text, @"\d+").Value;
            Modelo = business.classes.Abstrato.Ministerio.recuperarMinisterio(int.Parse(numero));
            VerificarModelo();

            WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Ministerio.FinalizarCadastro((business.classes.Abstrato.Ministerio)Modelo
            , true, false, false);
            dp.MdiParent = this.MdiParent;
            dp.Show();            
        }
        

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de ministerios";

            Ministerios.Dock = DockStyle.Left;
        }
    }
}
