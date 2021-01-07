using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class FinalizarCadastro : WFIgrejaLgpd.Formulario.FormCrudPessoa
    {
        public FinalizarCadastro(business.classes.Pessoas.PessoaLgpd p, bool Deletar, bool Atualizar,  bool Detalhes)
            :base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        public business.classes.Pessoas.PessoaLgpd P { get; }

        

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
