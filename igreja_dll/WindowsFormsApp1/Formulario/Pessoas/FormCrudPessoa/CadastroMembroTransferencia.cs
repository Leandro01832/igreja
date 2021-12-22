using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class CadastroMembroTransferencia : WFCrud
    {
        public CadastroMembroTransferencia() : base()
        {
            InitializeComponent();
        }

        private void CadastroMembroTransferencia_Load(object sender, EventArgs e)
        {
            this.Text = "Cadastro de membro por transferência.";

            if (modelo is Membro_Transferencia)
            {
                Membro_Transferencia p = null;
                if (modelo != null)
                    p = (Membro_Transferencia)modelo;
                else
                    p = (Membro_Transferencia)ModeloNovo;
                try { txt_nome_igreja.Text = p.Nome_igreja_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                try { txt_nome_estado.Text = p.Estado_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                try { txt_nome_cidade.Text = p.Nome_cidade_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (modelo is Membro_TransferenciaLgpd)
            {
                Membro_TransferenciaLgpd p = null;
                if (modelo != null)
                    p = (Membro_TransferenciaLgpd)modelo;
                else
                    p = (Membro_TransferenciaLgpd)ModeloNovo;
                try { txt_nome_igreja.Text = p.Nome_igreja_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                try { txt_nome_estado.Text = p.Estado_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                try { txt_nome_cidade.Text = p.Nome_cidade_transferencia; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }


        }

        private void txt_nome_igreja_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    try { p.Nome_igreja_transferencia = txt_nome_igreja.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    try { p.Nome_igreja_transferencia = txt_nome_igreja.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    try { p.Nome_igreja_transferencia = txt_nome_igreja.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    try { p.Nome_igreja_transferencia = txt_nome_igreja.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
            }

        }

        private void txt_nome_estado_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    try { p.Estado_transferencia = txt_nome_estado.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    try { p.Estado_transferencia = txt_nome_estado.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    try { p.Estado_transferencia = txt_nome_estado.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    try { p.Estado_transferencia = txt_nome_estado.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
            }
        }

        private void txt_nome_cidade_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)modelo;
                    try { p.Nome_cidade_transferencia = txt_nome_cidade.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)modelo;
                    try { p.Nome_cidade_transferencia = txt_nome_cidade.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }

            }
            if (ModeloNovo != null)
            {
                if (ModeloNovo is Membro_Transferencia)
                {
                    var p = (Membro_Transferencia)ModeloNovo;
                    try { p.Nome_cidade_transferencia = txt_nome_cidade.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                if (ModeloNovo is Membro_TransferenciaLgpd)
                {
                    var p = (Membro_TransferenciaLgpd)ModeloNovo;
                    try { p.Nome_cidade_transferencia = txt_nome_cidade.Text; }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
            }

        }
    }
}
