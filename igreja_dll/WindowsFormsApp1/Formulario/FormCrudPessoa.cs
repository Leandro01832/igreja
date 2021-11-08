﻿using business.classes.Abstrato;
using database;
using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Formulario.Pessoas;

namespace WindowsFormsApp1.Formulario
{
    public partial class FormCrudPessoa : WFCrud
    {
        private Button MudarEstado;

        public FormCrudPessoa() : base()
        {

        }

        public FormCrudPessoa(modelocrud modelo, modelocrud modeloNovo)
            : base(modelo, modeloNovo)
        {
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
            if(this is FrmPessoa)
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
            if (executar)
            {
                var m = (Pessoa)ModeloVelho;
                var p = (Pessoa)ModeloNovo;
                p.MudarEstado(m.Id, ModeloNovo);

                modelocrud.Modelos.OfType<Pessoa>().ToList()
               .Remove(modelocrud.Modelos.OfType<Pessoa>().ToList().First(i => i.Id == m.Id));
                modelocrud.Modelos.OfType<Pessoa>().ToList().Add(p);

                MessageBox.Show("Mudança realizada com sucesso!!!"); 
            }
            else
            {
                MessageBox.Show("Aguarde o processamento!!!");
            }
        }

        

        private void FormCrudPessoa_Load(object sender, EventArgs e)
        {

        }
    }
}
