using System;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class LiderMinisterio : FormularioListView
    {
        public LiderMinisterio() : base(
         new ListViewLiderMinisterio
         (new business.classes.Ministerio.Lider_Ministerio(), ""))
        {
            InitializeComponent();
        }

        private void LiderMinisterio_Load(object sender, EventArgs e)
        {
            this.Text = " - Liderança de Ministérios";
        }
    }
}
