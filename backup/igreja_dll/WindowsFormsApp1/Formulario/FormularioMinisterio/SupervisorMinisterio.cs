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
    
    public partial class SupervisorMinisterio : FormularioListView
    {

        public SupervisorMinisterio() : base(
        new ListViewSupervisorMinisterio(new Supervisor_Ministerio(), ""))
        {
            InitializeComponent();
        }

        private void SupervisorMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de ministério";
        }
    }
}
