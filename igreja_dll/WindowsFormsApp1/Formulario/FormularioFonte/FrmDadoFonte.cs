using business.classes.Esboco.Abstrato;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmDadoFonte : WFCrud
    {
        public FrmDadoFonte() : base()
        {
            InitializeComponent();
        }

        private void FrmDadoFonte_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var fonte = (Fonte)modelo;
                txt_id_mensagem.Text = fonte.MensagemId.ToString();
            }
        }

        private void txt_id_mensagem_TextChanged(object sender, EventArgs e)
        {
            var fonte = (Fonte)modelo;
            try
            {
                fonte.MensagemId = int.Parse(txt_id_mensagem.Text);
            }
            catch { MessageBox.Show("Informe o numero de identificação da mensagem da fonte."); }
        }
    }
}
