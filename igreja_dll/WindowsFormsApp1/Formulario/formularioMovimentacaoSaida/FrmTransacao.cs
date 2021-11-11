using business.classes.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    public partial class FrmTransacao : WFCrud
    {
        public FrmTransacao() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarTransacao_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            var form = "Transação";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Transacao a = (Transacao)modelo;
            txtValor.Text = a.Valor.ToString();
            checkBoxPagou.Checked = a.Pago;
        }

        private void checkBoxPagou_CheckedChanged(object sender, EventArgs e)
        {
            Transacao a = (Transacao)modelo;

            if (checkBoxPagou.Checked)
                a.Pago = true;
            else
                a.Pago = false;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Transacao a = (Transacao)modelo;
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }
    }
}
