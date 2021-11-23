using business.Classe;
using business.Classe.financeiro;
using business.classes.financeiro;
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
          try { txtValor.Text = a.Valor.ToString();  } catch(Exception ex) {MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
          try { checkBoxPagou.Checked = a.Pago;      } catch(Exception ex) {MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
          try { txtNomeProduto.Text = a.NomeProduto; } catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
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
                a.Valor = decimal.Parse(txtValor.Text);
                a.Valor = decimal.Parse(a.Valor.ToString("F2"));
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
