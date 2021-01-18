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

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class FrmReuniao : FormularioListView
    {
        public FrmReuniao() :base(new ListViewReuniao(new business.classes.Reuniao(), ""))
        {
            InitializeComponent();
        }

        private void FrmReuniao_Load(object sender, EventArgs e)
        {

        }
    }
}
