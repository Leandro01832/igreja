using business.classes.Ministerio;
using System;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class LiderMinisterioTreinamento : FormularioListView
    {
        public LiderMinisterioTreinamento( bool Lgpd) : base(
         new ListViewLiderMinisterioTreinamento
         (new Lider_Ministerio_Treinamento(), ""), Lgpd)
        {
            InitializeComponent();
        }

        private void LiderMinisterioTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " - Lider em treinamento de ministérios";
        }
    }
}
