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
    public partial class LiderMinisterio : FormularioListView
    {
        public LiderMinisterio() : base(
         new ListViewLiderMinisterio
         (new business.classes.Ministerio.Lider_Ministerio()))
        {
            InitializeComponent();
        }

        private void LiderMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Liderança de Ministérios";
        }
    }
}
