using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class FrmCelula : FormularioListView
    {
        public FrmCelula() : base(new ListViewCelula(typeof(business.classes.Abstrato.Celula)))
        {
            InitializeComponent();
        }

        private void Celula_Load(object sender, EventArgs e)
        {
            this.Text += " - Lista de celulas";
        }
    }
}
