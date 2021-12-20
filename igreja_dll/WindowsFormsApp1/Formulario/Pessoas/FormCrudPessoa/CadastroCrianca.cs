using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoas.FormCrudPessoa
{
    public partial class CadastroCrianca : WFCrud
    {

        public CadastroCrianca() : base()
        {
            InitializeComponent();
        }


        public PessoaDado P { get; }

        private void Proximo_Click(object sender, EventArgs e)
        {

        }

        private void CadastroCrianca_Load_1(object sender, EventArgs e)
        {
            this.Text = "Cadastro de Criança.";

            if (modelo is Crianca)
            {
                var p = (Crianca)modelo;
                try { textBox1.Text = p.Nome_pai; }
                catch (Exception ex)
                { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                try { textBox2.Text = p.Nome_mae; }
                catch (Exception ex)
                { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }

            if (modelo is CriancaLgpd)
            {
                var p = (CriancaLgpd)modelo;
                try { textBox1.Text = p.Nome_pai; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                try { textBox2.Text = p.Nome_mae; }
                catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Crianca)
                {
                    var p = (Crianca)modelo;
                    try { p.Nome_mae = textBox2.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
                if (modelo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)modelo;
                    try { p.Nome_mae = textBox2.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Crianca)
                {
                    var p = (Crianca)ModeloNovo;
                    try { p.Nome_mae = textBox2.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
                if (ModeloNovo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)ModeloNovo;
                    try { p.Nome_mae = textBox2.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (modelo != null)
            {
                if (modelo is Crianca)
                {
                    var p = (Crianca)modelo;
                    try { p.Nome_pai = textBox1.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }

                if (modelo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)modelo;
                    try { p.Nome_pai = textBox1.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
            }

            if (ModeloNovo != null)
            {
                if (ModeloNovo is Crianca)
                {
                    var p = (Crianca)ModeloNovo;
                    try { p.Nome_pai = textBox1.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }

                if (ModeloNovo is CriancaLgpd)
                {
                    var p = (CriancaLgpd)ModeloNovo;
                    try { p.Nome_pai = textBox1.Text; }
                    catch (Exception ex) { MessageBox.Show(modelo.exibirMensagemErro(ex, 2)); }
                }
            }
        }
    }
}
