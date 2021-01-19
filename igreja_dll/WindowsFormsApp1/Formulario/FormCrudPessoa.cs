using database;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoa;

namespace WindowsFormsApp1.Formulario
{
    public partial class FormCrudPessoa : WFCrud
    {
        private modelocrud modeloNovo;
        private modelocrud modeloVelho;
        private Button MudarEstado;

        public FormCrudPessoa()
        {

        }

        public FormCrudPessoa(modelocrud modelo, modelocrud modeloNovo)
            : base(modelo, modeloNovo)
        {

            this.modeloVelho = modelo;
            this.modeloNovo = modeloNovo;

            this.MudarEstado = new Button();
            this.MudarEstado.Location = new System.Drawing.Point(570, 140);
            this.MudarEstado.Size = new System.Drawing.Size(100, 50);
            this.MudarEstado.Text = "Fazer mudança";
            this.MudarEstado.Click += MudarEstado_Click;
            this.MudarEstado.Dock = DockStyle.Right;
            this.MudarEstado.Visible = true;

            this.Controls.Add(this.MudarEstado);
            InitializeComponent();
        }

        public FormCrudPessoa(bool deletar, bool atualizar, bool detalhes, modelocrud modelo, modelocrud modeloNovo)
            : base(deletar, atualizar, detalhes, modelo, modeloNovo)
        {
            if(this is FinalizarCadastroPessoa)
            {
                Proximo.Visible = false;
                this.MudarEstado = new Button();
                this.MudarEstado.Location = new System.Drawing.Point(570, 140);
                this.MudarEstado.Size = new System.Drawing.Size(100, 50);
                this.MudarEstado.Text = "Fazer mudança";
                this.MudarEstado.Click += MudarEstado_Click;
                this.MudarEstado.Dock = DockStyle.Right;
                this.MudarEstado.Visible = true;
                this.Controls.Add(this.MudarEstado);
            }

            InitializeComponent();
        }

        private void MudarEstado_Click(object sender, EventArgs e)
        {
            var p = (business.classes.Abstrato.Pessoa)ModeloNovo;
            p.MudarEstado(ModeloVelho.Id, ModeloNovo);

            MessageBox.Show("Mudança realizada com sucesso!!!");
        }

        public FormCrudPessoa(modelocrud modelo,
            bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FormCrudPessoa_Load(object sender, EventArgs e)
        {

        }
    }
}
