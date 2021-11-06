using database;
using System;

namespace WindowsFormsApp1.Formulario.Pessoas
{
    public partial class FormPessoa : FormCrudPessoa
    {
        public FormPessoa():base()
        {
            InitializeComponent();
        }

        public FormPessoa(bool Deletar, bool Atualizar, bool Detalhes, modelocrud modeloVelho,
            modelocrud modeloNovo)
            : base(Deletar, Atualizar, Detalhes, modeloVelho, modeloNovo)
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            if(CondicaoAtualizar)
            this.Text = "Atualizar dados de pessoa.";

            if (CondicaoDeletar)
                this.Text = "Deletar dados de pessoa.";

            if (CondicaoDetalhes)
                this.Text = "Detalhes de pessoa.";
        }
    }
}
