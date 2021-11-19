using business.classes.Abstrato;
using business.classes.Ministerio;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMudancaEstadoMinisterio : WFCrud
    {
        public FrmMudancaEstadoMinisterio()
        {
            InitializeComponent();
        }

        public FrmMudancaEstadoMinisterio(modelocrud modelo)
        {
            ModeloVelho = modelo;
        }
        

        private void btnMudanca_Click(object sender, EventArgs e)
        {
            var ministerio = (Ministerio)ModeloVelho;

            if (ModeloVelho is Lider_Celula)
                ministerio.MudarEstado(ministerio.Id, new Lider_Celula_Treinamento());
            if (ModeloVelho is Lider_Celula_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Lider_Celula());
            if (ModeloVelho is Lider_Ministerio)
                ministerio.MudarEstado(ministerio.Id, new Lider_Ministerio_Treinamento());
            if (ModeloVelho is Lider_Ministerio_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Lider_Ministerio());
            if (ModeloVelho is Supervisor_Celula)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Celula_Treinamento());
            if (ModeloVelho is Supervisor_Celula_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Celula());
            if (ModeloVelho is Supervisor_Ministerio)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Ministerio_Treinamento());
            if (ModeloVelho is Supervisor_Ministerio_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Ministerio());

            MessageBox.Show("Mudança realizada com sucesso!!!");

        }

        private void FrmMudancaEstadoMinisterio_Load(object sender, EventArgs e)
        {
            if (ModeloVelho is Lider_Celula)
                lblMudanca.Text = "Alterar lider de celula para lider de celula em treinamento?";
            if (ModeloVelho is Lider_Celula_Treinamento)
                lblMudanca.Text = "Alterar lider de celula em treinamento para lider de celula?";
            if (ModeloVelho is Lider_Ministerio)
                lblMudanca.Text = "Alterar lider de ministério para lider de ministério em treinamento?";
            if (ModeloVelho is Lider_Ministerio_Treinamento)
                lblMudanca.Text = "Alterar lider de ministério em treinamento para lider de ministério?";
            if (ModeloVelho is Supervisor_Celula)
                lblMudanca.Text = "Alterar supervisor de celula para supervisor de celula em treinamento?";
            if (ModeloVelho is Supervisor_Celula_Treinamento)
                lblMudanca.Text = "Alterar supervisor de celula em treinamento para supervisor de celula?";
            if (ModeloVelho is Supervisor_Ministerio)
                lblMudanca.Text = "Alterar supervisor de ministério para supervisor de ministério em treinamento?";
            if (ModeloVelho is Supervisor_Ministerio_Treinamento)
                lblMudanca.Text = "Alterar supervisor de ministério em treinamento para supervisor de ministério?";
        }
    }
}
