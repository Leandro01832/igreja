using business.classes.Ministerio;
using System;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class LiderMinisterio : FormularioListView
    {
        public LiderMinisterio( bool Lgpd) : base(
         new ListViewLiderMinisterio
         (new Lider_Ministerio(), ""), Lgpd)
        {
            InitializeComponent();
        }

        private void LiderMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Liderança de Ministérios";
        }
    }
}
