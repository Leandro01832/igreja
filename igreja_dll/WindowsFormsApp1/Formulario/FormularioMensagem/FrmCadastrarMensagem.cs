using business.classes.Esboco;
using System;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmCadastrarMensagem : WFCrud
    {
        public FrmCadastrarMensagem() : base()
        {
            InitializeComponent();
        }

        private void FrmMensagem_Load(object sender, EventArgs e)
        {
            if(modelo.Id != 0)
            {
                var m = (Mensagem)modelo;
                txt_tipo.Text = m.Tipo;
            }
        }

        private void txt_tipo_TextChanged(object sender, EventArgs e)
        {
            var m = (Mensagem)modelo;
            m.Tipo = txt_tipo.Text;
        }
    }
}
