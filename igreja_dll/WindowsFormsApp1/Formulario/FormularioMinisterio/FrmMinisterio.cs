using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMinisterio : FormularioListView
    {

        public FrmMinisterio(bool Lgpd) : base(new ListViewMinisterio(null, "Ministerio"), Lgpd)
        {
            InitializeComponent();
        }       

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de ministérios";
        }
    }
}
