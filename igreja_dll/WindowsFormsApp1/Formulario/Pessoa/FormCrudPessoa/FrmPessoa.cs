using database;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class FrmPessoa : WFCrud
    {
        public FrmPessoa():base()
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            LoadCrudForm();
            if (CondicaoAtualizar)
            this.Text = "Atualizar dados de pessoa.";

            if (CondicaoDeletar)
                this.Text = "Deletar dados de pessoa.";

            if (CondicaoDetalhes)
                this.Text = "Detalhes de pessoa.";
        }
    }
}
