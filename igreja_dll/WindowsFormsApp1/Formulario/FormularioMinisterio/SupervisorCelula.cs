using business.classes.Ministerio;
using System;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class SupervisorCelula : FormularioListView
    {
        public SupervisorCelula() : base(
        new ListViewSupervisorCelula(typeof(Supervisor_Celula)))
        {
            InitializeComponent();
        }

        private void SupervisorCelula_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de celulas";
        }
    }
}
