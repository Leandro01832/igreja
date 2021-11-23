using business.classes.Esboco;
using System;
using System.Windows.Forms;

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
            
                var m = (Mensagem)modelo;
            try { txt_tipo.Text = m.Tipo; } catch(Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            
        }

        private void txt_tipo_TextChanged(object sender, EventArgs e)
        {
            var m = (Mensagem)modelo;
            m.Tipo = txt_tipo.Text;
        }
    }
}
