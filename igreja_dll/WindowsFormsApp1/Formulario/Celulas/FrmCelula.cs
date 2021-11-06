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

namespace WindowsFormsApp1.Formulario.Celulas
{
    public partial class FrmCelula : FormularioCrudCelula
    {
        public FrmCelula(): base()
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
