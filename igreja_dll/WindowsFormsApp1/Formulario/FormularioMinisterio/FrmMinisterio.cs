using System;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FrmMinisterio : FormularioListView
    {

        public FrmMinisterio(Type tipo) : base(tipo)
        {
            InitializeComponent();
        }       

        private void Ministerio_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de ministérios";
        }
    }
}
