using business.classes.Pessoas;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class DadoPessoal : WFCrud
    {
        public DadoPessoal() : base()
        {
            InitializeComponent();
        }

        private void DadoPessoal_Load(object sender, EventArgs e)
        {
            this.Text = "Daddos pessoais.";

            var p = (PessoaDado)modelo;
            try { text_nome.Text = p.NomePessoa; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_rg.Text = p.Rg; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { text_cpf.Text = p.Cpf; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { listestado_civil.Text = p.Estado_civil; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { listBox_status.Text = p.Status; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { mask_data_nascimento.Text = p.Data_nascimento.ToString("dd/MM/yyyy"); }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { textemail.Text = p.Email; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { radioButton_masculino.Checked = p.Sexo_masculino; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            try { radioButton_feminino.Checked = p.Sexo_feminino; }
            catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }



        }

        private void text_nome_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                p.NomePessoa = text_nome.Text;
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                p.NomePessoa = text_nome.Text;
            }

        }

        private void text_rg_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Rg = text_rg.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Rg = text_rg.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }

        }

        private void text_cpf_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Cpf = text_cpf.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Cpf = text_cpf.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }

        }

        private void listestado_civil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Estado_civil = listestado_civil.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Estado_civil = listestado_civil.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }

        }

        private void listBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Status = listBox_status.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Status = listBox_status.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }

        }

        private void mask_data_nascimento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mask_data_nascimento.Text = "";
        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Email = textemail.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Email = textemail.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(modelo.exibirMensagemErro(ex, 2));
                }
            }

        }

        private void radioButton_masculino_CheckedChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                p.Sexo_masculino = radioButton_masculino.Checked;
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                p.Sexo_masculino = radioButton_masculino.Checked;
            }
        }

        private void radioButton_feminino_CheckedChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                p.Sexo_feminino = radioButton_feminino.Checked;
            }
            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                p.Sexo_feminino = radioButton_feminino.Checked;
            }
        }

        private void mask_data_nascimento_MaskChanged(object sender, EventArgs e)
        {
        }

        private void mask_data_nascimento_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                var p = (PessoaDado)modelo;
                try
                {
                    p.Data_nascimento = Convert.ToDateTime(mask_data_nascimento.Text.ToString());
                }
                catch (Exception )
                {
                }
            }

            if (ModeloNovo != null)
            {
                var p = (PessoaDado)ModeloNovo;
                try
                {
                    p.Data_nascimento = Convert.ToDateTime(mask_data_nascimento.Text.ToString());
                }
                catch (Exception )
                {
                }
            }
        }
    }
}
