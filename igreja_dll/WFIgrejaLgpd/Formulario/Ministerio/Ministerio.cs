using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Ministerio
{
    public partial class Ministerio : FormularioListView
    {
        public Ministerio() : base(new ListViewMinisterio(null, "Ministerio"))
        {
            InitializeComponent();
        }       

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de ministerios";
        }
    }
}
