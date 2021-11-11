using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class Chamada : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public Chamada() : base()
        {
            InitializeComponent();
        }

        private void Chamada_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
        }
    }
}
