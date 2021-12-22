﻿using business.classes.financeiro;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoEntrada
{
    public partial class FrmLava_Rapido : WFCrud
    {
        public FrmLava_Rapido() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarLavaRapido_Load(object sender, EventArgs e)
        {
            var form = "Lava-Rápido";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Lava_Rapido a = (Lava_Rapido)modelo;
           try{ txtValor.Text = a.Valor.ToString(); }  catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
           try{ checkBoxPagou.Checked = a.Pago;     }  catch(Exception ex){MessageBox.Show(modelo.exibirMensagemErro(ex, 2));}
            try { if (a.Pessoa_ != null) txt_numero_id.Text = a.Pessoa_.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Lava_Rapido a = (Lava_Rapido)modelo;
            try { a.Validar(txtValor.Text, "Valor"); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
        }

        private void txt_numero_id_TextChanged(object sender, EventArgs e)
        {
            Lava_Rapido a = (Lava_Rapido)modelo;
            try
            {
                a.Pessoa_ = int.Parse(txt_numero_id.Text);
            }
            catch { MessageBox.Show("Informe um numero de identificação do comprador."); }
        }
    }
}
