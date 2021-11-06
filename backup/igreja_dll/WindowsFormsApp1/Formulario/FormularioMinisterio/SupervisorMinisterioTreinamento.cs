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
    public partial class SupervisorMinisterioTreinamento : FormularioListView
    {
        public SupervisorMinisterioTreinamento() : base(
        new ListViewSupervisorMinisterioTreinanemnto(new Supervisor_Ministerio_Treinamento(), ""))
        {
            InitializeComponent();
        }

        private void SupervisorMinisterioTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de ministérios em treinamento";
        }
    }
}
