using business.implementacao;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class DetalhesMudancaEstado : WFCrud
    {
        public DetalhesMudancaEstado(): base()
        {
            InitializeComponent();
        }

        private void DetalhesMudancaEstado_Load(object sender, EventArgs e)
        {
            if(modelo != null)
            {
                var mudanca = (MudancaEstado)modelo;
                lbl_data_mudanca.Text += mudanca.Data.ToString();
                lbl_modelo_antigo.Text += mudanca.velhoEstado.ToString();
                lbl_modelo_novo.Text += mudanca.novoEstado.ToString();
                lbl_id_pessoa.Text += mudanca.Codigo.ToString();
            }
        }
    }
}
