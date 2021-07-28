using business.classes;
using business.implementacao;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class ListaMudancaEstado : FormularioListView
    {
        public ListaMudancaEstado() : base(typeof(MudancaEstado))
        {
            InitializeComponent();
        }

        private void ListaMudancaEstado_Load(object sender, EventArgs e)
        {

        }
    }
}
