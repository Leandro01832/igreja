using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario.Celula
{
    public partial class FinalizarCadastro : FormularioCrudCelula
    {
        public FinalizarCadastro(business.classes.Abstrato.Celula p, bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void FinalizarCadastro_Load(object sender, EventArgs e)
        {
            if(CondicaoDeletar)
            this.Text = " - Deletar celula.";

            if(CondicaoAtualizar)
                this.Text = " - Atualizar celula.";

            if (CondicaoDetalhes)
                this.Text = " - Detalhes de celula.";
        }
    }
}
