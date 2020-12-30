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
    public partial class CelulaCasado : FormularioListView
    {
        public CelulaCasado() : base(
            new ListViewCelulaCasado
            (new business.classes.Celulas.Celula_Casado()))
        {
            InitializeComponent();
        }

        private void CelulaCasado_Load(object sender, EventArgs e)
        {
            this.Text = " - Celulas para casados";
        }
    }
}
