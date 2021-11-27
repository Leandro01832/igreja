﻿
using business.classes.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoSaida
{
    public partial class FrmRetiro : WFCrud
    {
        public FrmRetiro() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarRetiro_Load(object sender, EventArgs e)
        {
            var form = "Retiro";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Retiro a = (Retiro)modelo;
           try{ txtValor.Text = a.Valor.ToString(); } catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
           try{ checkBoxPagou.Checked = a.Pago;     } catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
            try { txtLocal.Text = a.Local; }          catch(Exception ex){ MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void checkBoxPagou_CheckedChanged(object sender, EventArgs e)
        {
            Retiro a = (Retiro)modelo;

            if (checkBoxPagou.Checked)
                a.Pago = true;
            else
                a.Pago = false;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Retiro a = (Retiro)modelo;
            try
            {
                a.Valor = decimal.Parse(txtValor.Text);
                a.Valor = decimal.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }

        private void txtLocal_TextChanged(object sender, EventArgs e)
        {
            Retiro a = (Retiro)modelo;
            a.Local = txtLocal.Text;
        }
    }
}