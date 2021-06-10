using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMinisterio : FormularioListView
    {

        public FrmMinisterio() : base(new ListViewMinisterio(typeof(business.classes.Abstrato.Ministerio)))
        {
            InitializeComponent();
        }       

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de ministérios";
        }
    }
}
