using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class FrmEndereco : WFCrud
    {
        public FrmEndereco() : base()
        {

            InitializeComponent();
        }

        private void Endereco_Load(object sender, EventArgs e)
        {
            this.Text = "Endereço da pessoa.";
            PessoaDado p = null;
            if (modelo != null)
                p = (PessoaDado)modelo;
            else
                p = (PessoaDado)ModeloNovo;
            try { textpais.Text = p.Endereco.Pais; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_cep.Text = p.Endereco.Cep.ToString(); }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_estado.Text = p.Endereco.Estado; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_cidade.Text = p.Endereco.Cidade; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_bairro.Text = p.Endereco.Bairro; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_rua.Text = p.Endereco.Rua; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_complemento.Text = p.Endereco.Complemento; }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            try { text_numero.Text = p.Endereco.Numero_casa.ToString(); }
            catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }

        }

        private void textpais_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Pais = textpais.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Pais = textpais.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }

        }

        private void text_cep_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                try
                {
                    var p = (PessoaDado)modelo;
                    try { p.Endereco.Cep = long.Parse(text_cep.Text); }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                catch (Exception)
                {
                    text_cep.Text = "";
                    MessageBox.Show("informe apenas numeros");
                }
            }
            if (ModeloNovo != null)
            {
                try
                {
                    var p = (PessoaDado)ModeloNovo;
                    try { p.Endereco.Cep = long.Parse(text_cep.Text); }
                    catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
                }
                catch (Exception)
                {
                    text_cep.Text = "";
                    MessageBox.Show("informe apenas numeros");
                }
            }
        }

        private void text_estado_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Estado = text_estado.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Estado = text_estado.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
        }

        private void text_cidade_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Cidade = text_cidade.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Cidade = text_cidade.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
        }

        private void text_bairro_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Bairro = text_bairro.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Bairro = text_bairro.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
        }

        private void text_rua_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Rua = text_rua.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Rua = text_rua.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
        }

        private void text_complemento_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try { p.Endereco.Complemento = text_complemento.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try { p.Endereco.Complemento = text_complemento.Text; }
                catch (Exception ex) { MessageBox.Show(modeloErro.exibirMensagemErro(ex, 2)); }
            }
        }

        private void text_numero_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Endereco.Numero_casa = int.Parse(text_numero.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe a rua corretamente.");
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Endereco.Numero_casa = int.Parse(text_numero.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe a rua corretamente.");
                }
            }
        }
    }
}
