using System;

namespace WindowsFormsApp1.Formulario.Reuniao
{
    public partial class ListReuniao : FormularioListView
    {
        public ListReuniao() :base(typeof(business.classes.Reuniao))
        {
            InitializeComponent();
        }

        private void FrmReuniao_Load(object sender, EventArgs e)
        {

        }
    }
}
