using business.Classe;
using business.Classe.financeiro;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    public partial class FrmAluguel : WFCrud
    {
        public FrmAluguel() : base()
        {
            InitializeComponent();
        }
        

        private void FrmCadastrarAluguel_Load(object sender, EventArgs e)
        {
            var form = "Aluguel";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Aluguel a = (Aluguel)modelo;
            txtValor.Text = a.Valor.ToString();
            checkBoxPagou.Checked = a.Pago;
            txtNomeProduto.Text = a.NomeProduto;
        }

        private void checkBoxPagou_CheckedChanged(object sender, EventArgs e)
        {
            Aluguel a = (Aluguel)modelo;

            if (checkBoxPagou.Checked)
                a.Pago = true;
            else
                a.Pago = false;
        }        

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Aluguel a = (Aluguel)modelo;
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = "";}
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            Aluguel a = (Aluguel)modelo;
            a.NomeProduto = txtNomeProduto.Text;
        }
    }
}
