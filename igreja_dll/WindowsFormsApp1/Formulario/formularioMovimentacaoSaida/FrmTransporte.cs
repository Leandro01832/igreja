using business.Classe.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    public partial class FrmTransporte : WFCrud
    {
        public FrmTransporte() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarTransporte_Load(object sender, EventArgs e)
        {
            var form = "Transporte";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Transporte a = (Transporte)modelo;
            txtValor.Text = a.Valor.ToString();
            checkBoxPagou.Checked = a.Pago;
        }

        private void checkBoxPagou_CheckedChanged(object sender, EventArgs e)
        {
            Transporte a = (Transporte)modelo;

            if (checkBoxPagou.Checked)
                a.Pago = true;
            else
                a.Pago = false;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Transporte a = (Transporte)modelo;
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }

        private void radioDiesel_CheckedChanged(object sender, EventArgs e)
        {
            Transporte a = (Transporte)modelo;
            if (radioDiesel.Checked) a.Diesel = true;
            else a.Diesel = false;
        }

        private void radioAlcool_CheckedChanged(object sender, EventArgs e)
        {
            Transporte a = (Transporte)modelo;
            if (radioAlcool.Checked) a.Alcool = true;
            else a.Alcool = false;
        }

        private void radioGasolina_CheckedChanged(object sender, EventArgs e)
        {
            Transporte a = (Transporte)modelo;
            if (radioGasolina.Checked) a.Gasolina = true;
            else a.Gasolina = false;
        }
    }
}
