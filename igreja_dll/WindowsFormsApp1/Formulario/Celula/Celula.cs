using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class Celula : Form
    {
        ListView Celulas;
        public Button botaoDetalhes;
        public Button botaoExcluir;
        public Button botaoAtualizar;
        public modelocrud Modelo { get; set; }

        public Celula()
        {
            var lista = business.classes.Abstrato.Celula.recuperarTodasCelulas();

            Celulas = new ListView();
            Celulas.View = View.List;
            Celulas.ItemSelectionChanged += Celulas_ItemSelectionChanged;
            Celulas.Size = new System.Drawing.Size(500, 300);
            Celulas.Location = new System.Drawing.Point(50, 50);
            Celulas.Font = new System.Drawing.Font("Arial", 15);

            foreach (var item in lista)
            {
                business.classes.Abstrato.Celula p = (business.classes.Abstrato.Celula)item;
                Celulas.Items.Add(p.Id.ToString() + " - " + p.Nome);
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

            Controls.Add(Celulas);
            Controls.Add(botaoExcluir);
            Controls.Add(botaoAtualizar);
            Controls.Add(botaoDetalhes);


            InitializeComponent();
        }

        private void Celulas_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                Celulas.Text = Celulas.SelectedItems[0].Text;
            }
            catch (Exception)
            {
            }
        }

        private void BotaoDetalhes_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Celulas.Text, @"\d+").Value;

            Modelo = business.classes.Abstrato.Celula.recuperarCelula(int.Parse(numero));

            if (Modelo is business.classes.Celulas.Celula_Adolescente)
                Modelo =
            new business.classes.Celulas.Celula_Adolescente(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Celulas.Celula_Adulto)
                Modelo =
            new business.classes.Celulas.Celula_Adulto(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Celulas.Celula_Casado)
                Modelo =
            new business.classes.Celulas.Celula_Casado(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Celulas.Celula_Crianca)
                Modelo =
            new business.classes.Celulas.Celula_Crianca(Modelo.Id, true).recuperar(Modelo.Id)[0];

            if (Modelo is business.classes.Celulas.Celula_Jovem)
                Modelo =
            new business.classes.Celulas.Celula_Jovem(Modelo.Id, true).recuperar(Modelo.Id)[0];

            WindowsFormsApp1.Formulario.Celula.FinalizarCadastro fc = 
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, false, true);
            fc.MdiParent = this.MdiParent;
            fc.Show();
            
        }

        private void botaoAtualizar_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Celulas.Text, @"\d+").Value;

            Modelo = business.classes.Abstrato.Celula.recuperarCelula(int.Parse(numero));
            
            WindowsFormsApp1.Formulario.Celula.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , false, true, false);
            dp.MdiParent = this.MdiParent;
            dp.Show();

        }

        private void botaoExcluir_Click(object sender, EventArgs e)
        {
            var numero = Regex.Match(Celulas.Text, @"\d+").Value;
            Modelo = business.classes.Abstrato.Celula.recuperarCelula(int.Parse(numero));

            WindowsFormsApp1.Formulario.Celula.FinalizarCadastro dp =
            new WindowsFormsApp1.Formulario.Celula.FinalizarCadastro((business.classes.Abstrato.Celula)Modelo
            , true, false, false);
            dp.MdiParent = this.MdiParent;
            dp.Show();
                        
        }

        private void Celula_Load(object sender, EventArgs e)
        {
            this.Text += " - Lista de celulas";

            Celulas.Dock = DockStyle.Left;
        }
    }
}
