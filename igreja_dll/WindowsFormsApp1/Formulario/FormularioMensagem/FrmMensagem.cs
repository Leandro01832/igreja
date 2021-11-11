using System;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmMensagem : WFCrud
    {
        public FrmMensagem() : base()
        {
            InitializeComponent();
        }

        private void FrmFinalizarCadastroMensagem_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            FormPadrao.LoadForm(this);
        }
    }
}
