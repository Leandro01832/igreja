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

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class Visitante : FormularioListView
    {
        public Visitante() : base(
            new ListViewVisitante(new business.classes.PessoasLgpd.VisitanteLgpd()))
        {
            InitializeComponent();
        }

        private void Visitante_Load(object sender, EventArgs e)
        {
            this.Text += " - Visitantes";
        }
    }
}
