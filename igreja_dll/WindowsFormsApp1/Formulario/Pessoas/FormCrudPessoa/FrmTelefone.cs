using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class FrmTelefone : WFCrud
    {
        public FrmTelefone() : base()
        {
            InitializeComponent();
        }

        private void Contato_Load(object sender, EventArgs e)
        {
            this.Text = "Contatos.";

            var p = (business.classes.Pessoas.PessoaDado)modelo;
            try { mask_tel1.Text = p.Telefone.Fone; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { mask_tel2.Text = p.Telefone.Celular; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { mask_tel3.Text = p.Telefone.Whatsapp; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }


        }

        private void mask_tel1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                try { p.Telefone.Fone = mask_tel1.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                try { p.Telefone.Fone = mask_tel1.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }

        }

        private void mask_tel2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                try { p.Telefone.Celular = mask_tel2.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                try { p.Telefone.Celular = mask_tel2.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
        }

        private void mask_tel3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (modelo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)modelo;
                try { p.Telefone.Whatsapp = mask_tel3.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (business.classes.Pessoas.PessoaDado)ModeloNovo;
                try { p.Telefone.Whatsapp = mask_tel3.Text; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }
        }
    }
}
