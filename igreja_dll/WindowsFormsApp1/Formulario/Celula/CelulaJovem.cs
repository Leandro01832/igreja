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
    public partial class CelulaJovem : FormularioListView
    {
        public CelulaJovem() : base(new ListViewCelulaJovem(typeof(Celula_Jovem)))
        {
            InitializeComponent();
        }

        private void CelulaJovem_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas para jovens";
        }
    }
}
