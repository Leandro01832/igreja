using System;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class FrmPessoa : FormularioListView
    {

        public FrmPessoa(Type Tipo) : base(Tipo)
        {     
            InitializeComponent();
        }
        
        private void Pessoa_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de pessoas";
        }
    }
}
