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
    public partial class LiderMinisterioTreinamento : FormularioListView
    {
        public LiderMinisterioTreinamento() : base(
         new ListViewLiderMinisterioTreinamento
         (new business.classes.Ministerio.Lider_Ministerio_Treinamento()))
        {
            InitializeComponent();
        }

        private void LiderMinisterioTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " - Lider em treinamento de ministérios";
        }
    }
}
