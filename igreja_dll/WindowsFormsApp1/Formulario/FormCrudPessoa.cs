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

        private void MudarEstado_Click(object sender, EventArgs e)
        {
            var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
            p.MudarEstado(ModeloVelho.Id, ModeloNovo);
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
