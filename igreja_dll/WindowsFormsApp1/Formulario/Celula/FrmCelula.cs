using System;

namespace WindowsFormsApp1.Formulario.Celula
{
    public partial class FrmCelula : FormularioListView
    {
        public FrmCelula(Type tipo) : base(tipo)
        {
            InitializeComponent();
        }

        private void Celula_Load(object sender, EventArgs e)
        {
            this.Text += " - Lista de celulas";
        }
    }
}
