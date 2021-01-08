using System;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class LiderMinisterioTreinamento : FormularioListView
    {
        public LiderMinisterioTreinamento() : base(
         new ListViewLiderMinisterioTreinamento
         (new business.classes.Ministerio.Lider_Ministerio_Treinamento(), ""))
        {
            InitializeComponent();
        }

        private void LiderMinisterioTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " - Lider em treinamento de ministérios";
        }
    }
}
