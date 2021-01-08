using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class FinalizarCadastroPessoa : WindowsFormsApp1.Formulario.FormCrudPessoa
    {
        public FinalizarCadastroPessoa(business.classes.Pessoas.PessoaDado p,
            bool Deletar, bool Atualizar,  bool Detalhes)
            :base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public business.classes.Pessoas.PessoaDado P { get; }

        

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
