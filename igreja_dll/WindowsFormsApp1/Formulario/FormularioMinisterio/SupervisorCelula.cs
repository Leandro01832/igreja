using business.classes.Ministerio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class SupervisorCelula : FormularioListView
    {
        public SupervisorCelula(bool Lgpd) : base(
        new ListViewSupervisorCelula(new Supervisor_Celula(), ""), Lgpd)
        {
            InitializeComponent();
        }

        private void SupervisorCelula_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de celulas";
        }
    }
}
