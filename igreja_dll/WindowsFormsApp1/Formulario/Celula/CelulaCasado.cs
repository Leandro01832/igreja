using business.classes.Celulas;
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

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class CelulaCasado : FormularioListView
    {
        public CelulaCasado() : base(new ListViewCelulaCasado (typeof(Celula_Casado)))
        {
            InitializeComponent();
        }

        private void CelulaCasado_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas para casados";
        }
    }
}
