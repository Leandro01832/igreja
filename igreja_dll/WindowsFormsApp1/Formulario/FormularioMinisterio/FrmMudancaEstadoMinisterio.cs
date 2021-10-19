using business.classes.Abstrato;
using business.classes.Ministerio;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMudancaEstadoMinisterio : Form
    {
        public FrmMudancaEstadoMinisterio()
        {
            InitializeComponent();
        }

        public FrmMudancaEstadoMinisterio(modelocrud modelo)
        {
            Modelo = modelo;
        }

        public modelocrud Modelo { get; }

        private void btnMudanca_Click(object sender, EventArgs e)
        {
            var ministerio = (Ministerio)Modelo;

            if (Modelo is Lider_Celula)
                ministerio.MudarEstado(ministerio.Id, new Lider_Celula_Treinamento());
            if (Modelo is Lider_Celula_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Lider_Celula());
            if (Modelo is Lider_Ministerio)
                ministerio.MudarEstado(ministerio.Id, new Lider_Ministerio_Treinamento());
            if (Modelo is Lider_Ministerio_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Lider_Ministerio());
            if (Modelo is Supervisor_Celula)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Celula_Treinamento());
            if (Modelo is Supervisor_Celula_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Celula());
            if (Modelo is Supervisor_Ministerio)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Ministerio_Treinamento());
            if (Modelo is Supervisor_Ministerio_Treinamento)
                ministerio.MudarEstado(ministerio.Id, new Supervisor_Ministerio());

            MessageBox.Show("Mudança realizada com sucesso!!!");

        }

        private void FrmMudancaEstadoMinisterio_Load(object sender, EventArgs e)
        {
            if (Modelo is Lider_Celula)
                lblMudanca.Text = "Alterar lider de celula para lider de celula em treinamento?";
            if (Modelo is Lider_Celula_Treinamento)
                lblMudanca.Text = "Alterar lider de celula em treinamento para lider de celula?";
            if (Modelo is Lider_Ministerio)
                lblMudanca.Text = "Alterar lider de ministério para lider de ministério em treinamento?";
            if (Modelo is Lider_Ministerio_Treinamento)
                lblMudanca.Text = "Alterar lider de ministério em treinamento para lider de ministério?";
            if (Modelo is Supervisor_Celula)
                lblMudanca.Text = "Alterar supervisor de celula para supervisor de celula em treinamento?";
            if (Modelo is Supervisor_Celula_Treinamento)
                lblMudanca.Text = "Alterar supervisor de celula em treinamento para supervisor de celula?";
            if (Modelo is Supervisor_Ministerio)
                lblMudanca.Text = "Alterar supervisor de ministério para supervisor de ministério em treinamento?";
            if (Modelo is Supervisor_Ministerio_Treinamento)
                lblMudanca.Text = "Alterar supervisor de ministério em treinamento para supervisor de ministério?";
        }
    }
}
