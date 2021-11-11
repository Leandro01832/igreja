using business.Classe.financeiro;
using business.classes.financeiro;
using database;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.formulario.formularioMovimentacaoEntrada
{
    public partial class FrmOferta : WFCrud
    {
        public FrmOferta() : base()
        {
            InitializeComponent();
        }

        private void FrmCadastrarOferta_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            FormPadrao.LoadForm(this);
            var form = "Oferta";
            if (CondicaoAtualizar) this.Text = "Atualizar registro - " + form;
            if (CondicaoDeletar) this.Text = "Deletar registro - " + form;
            if (CondicaoDetalhes) this.Text = "Detalhes registro - " + form;
            if (!CondicaoDeletar && !CondicaoAtualizar && !CondicaoDetalhes) this.Text = "Cadastro - " + form;

            Oferta a = (Oferta)modelo;
            txtValor.Text = a.Valor.ToString();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            Oferta a = (Oferta)modelo;
            try
            {
                a.Valor = double.Parse(txtValor.Text);
                a.Valor = double.Parse(a.Valor.ToString("F2"));
            }
            catch { MessageBox.Show("digite numeros"); txtValor.Text = ""; }
        }
    }
}
