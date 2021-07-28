using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioMinisterio
{
    public partial class FinalizarCadastroMinisterio : FormCrudMinisterio
    {
        public FinalizarCadastroMinisterio(Ministerio p,
            bool Deletar, bool Atualizar, bool Detalhes)
          : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            if(CondicaoAtualizar)
            this.Text = "Atualizar ministério.";

            if (CondicaoDeletar)
                this.Text = "Deletar ministério.";

            if (CondicaoDetalhes)
                this.Text = "Detalhes do ministério.";
        }
    }
}
