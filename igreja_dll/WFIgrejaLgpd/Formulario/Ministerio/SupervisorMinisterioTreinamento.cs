using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Ministerio
{
    public partial class SupervisorMinisterioTreinamento : FormularioListView
    {
        public SupervisorMinisterioTreinamento() : base(
        new ListViewSupervisorMinisterioTreinanemnto(new business.classes.Ministerio.Supervisor_Ministerio_Treinamento()))
        {
            InitializeComponent();
        }

        private void SupervisorMinisterioTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de ministérios em treinamento";
        }
    }
}
