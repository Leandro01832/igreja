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

namespace WindowsFormsApp1.Formulario.Ministerio
{
    public partial class SupervisorCelulaTreinamento : FormularioListView
    {
        public SupervisorCelulaTreinamento() : base(
        new ListViewSupervisorCelulaTreinamento(new business.classes.Ministerio.Supervisor_Celula_Treinamento(), ""))
        {
            InitializeComponent();
        }

        private void SupervisorCelulaTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de celulas em treinamento";
        }
    }
}
