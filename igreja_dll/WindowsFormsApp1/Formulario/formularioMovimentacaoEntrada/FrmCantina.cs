﻿using business.Classe.financeiro;
using business.classes.financeiro;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoEntrada
{
    public partial class FrmCantina : WFCrud
    {
        public FrmCantina()
            : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarCantina_Load(object sender, EventArgs e)
        {
            var form = "Cantina";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Cantina a = (Cantina)modelo;
            txtValor.Text = a.Valor.ToString();
            checkBoxPagou.Checked = a.Pago;
            if (a.Pessoa_ != null)
                txt_numero_id.Text = a.Pessoa_.ToString();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Cantina a = (Cantina)modelo;
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }

        private void mask_data_recebimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            Cantina a = (Cantina)modelo;
            try
            {
                a.DataRecebimento = Convert.ToDateTime(mask_data_recebimento.Text);
            }
            catch {  }
        }

        private void txt_numero_id_TextChanged(object sender, EventArgs e)
        {
            Bazar a = (Bazar)modelo;
            try
            {
                a.Pessoa_ = int.Parse(txt_numero_id.Text);
            }
            catch { MessageBox.Show("Informe um numero de identificação do comprador."); }
        }
    }
}
