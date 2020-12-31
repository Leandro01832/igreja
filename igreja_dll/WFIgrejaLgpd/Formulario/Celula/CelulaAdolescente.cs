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

namespace WFIgrejaLgpd.Formulario.Celula
{
    public partial class CelulaAdolescente : FormularioListView
    {
        public CelulaAdolescente() : base(
            new ListViewCelulaAdolescente
            (new business.classes.Celulas.Celula_Adolescente(), ""))
        {
            InitializeComponent();
        }

        private void CelulaAdolescente_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas para adolescentes";
        }
    }
}
