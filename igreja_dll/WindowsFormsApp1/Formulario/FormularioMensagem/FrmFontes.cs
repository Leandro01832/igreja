using business.classes.Esboco;
using System;

namespace WindowsFormsApp1.Formulario.FormularioFonte
{
    public partial class FrmFontes : WFCrud
    {
        public FrmFontes() 
            : base()
        {
            InitializeComponent();
        }

        private void FrmFontes_Load(object sender, EventArgs e)
        {
            var m = (Mensagem)modelo;
            lbl_fontes.Text = "As fontes da mensagem: ";

            foreach(var f in m.Fontes)
            {
                lbl_fontes.Text += f.Id.ToString() + ", ";
            }
        }
    }
}
