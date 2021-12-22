using business.classes.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    public partial class FrmCompra : WFCrud
    {
        public FrmCompra() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarCompra_Load(object sender, EventArgs e)
        {
            var form = "Compra";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Compra a = (Compra)modelo;
            try { txtValor.Text = a.Valor.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { checkBoxPagou.Checked = a.Pago; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { txtNomeProduto.Text = a.NomeProduto; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void checkBoxPagou_CheckedChanged(object sender, EventArgs e)
        {
            Compra a = (Compra)modelo;

            if (checkBoxPagou.Checked)
                a.Pago = true;
            else
                a.Pago = false;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Compra a = (Compra)modelo;
            try { a.Validar(txtValor.Text, "Valor"); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            Compra a = (Compra)modelo;
            try { a.NomeProduto = txtNomeProduto.Text; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }
    }
}
