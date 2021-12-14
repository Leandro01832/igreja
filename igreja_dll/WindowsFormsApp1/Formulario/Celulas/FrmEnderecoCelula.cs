using business.classes.Abstrato;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmEnderecoCelula : WFCrud
    {
        public FrmEnderecoCelula() : base()
        {
            InitializeComponent();
        }

        private void EnderecoCelula_Load(object sender, EventArgs e)
        {
            FrmPrincipal.LoadForm(this);

            var p = (Celula)modelo;
            try { textpais.Text = p.EnderecoCelula.Pais; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_cep.Text = p.EnderecoCelula.Cep.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_estado.Text = p.EnderecoCelula.Estado; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_cidade.Text = p.EnderecoCelula.Cidade; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_bairro.Text = p.EnderecoCelula.Bairro; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_rua.Text = p.EnderecoCelula.Rua; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_complemento.Text = p.EnderecoCelula.Complemento; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_numero.Text = p.EnderecoCelula.Numero_casa.ToString(); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }

        }

        private void textpais_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Pais = textpais.Text;
        }

        private void text_cep_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            try
            {
                c.EnderecoCelula.Cep = long.Parse(text_cep.Text);
            }
            catch (Exception)
            {
                text_cep.Text = "";
                MessageBox.Show("Informe apenas numeros.");
            }
        }

        private void text_estado_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Estado = text_estado.Text;
        }

        private void text_cidade_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Cidade = text_cidade.Text;
        }

        private void text_bairro_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Bairro = text_bairro.Text;
        }

        private void text_rua_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Rua = text_rua.Text;
        }

        private void text_complemento_TextChanged(object sender, EventArgs e)
        {
            var c = (Celula)modelo;
            c.EnderecoCelula.Complemento = text_complemento.Text;
        }

        private void text_numero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var c = (Celula)modelo;
                c.EnderecoCelula.Numero_casa = int.Parse(text_numero.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Digite apenas numeros.");
                text_numero.Text = "";
                text_numero.Focus();
            }
        }
    }
}
