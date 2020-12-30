using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Pessoa
{
    public partial class MembroTransferencia : FormularioListView
    {
        public MembroTransferencia() : base(
            new ListViewMembroTransferencia(new business.classes.PessoasLgpd.Membro_TransferenciaLgpd()))
        {
            InitializeComponent();
        }

        private void MembroTransferencia_Load(object sender, EventArgs e)
        {
            this.Text = " - Membro por transferência";
        }
    }
}
