using business.Classe;
using business.Classe.financeiro;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

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
            txtValor.Text = a.Valor.ToString();
            checkBoxPagou.Checked = a.Pago;
            txtNomeProduto.Text = a.NomeProduto;
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
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            Compra a = (Compra)modelo;
            a.NomeProduto = txtNomeProduto.Text;
        }
    }
}
