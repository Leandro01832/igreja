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
    public partial class MembroBatismo : FormularioListView
    {
        public MembroBatismo() : base(
            new ListViewMembroBatismo
            (new business.classes.PessoasLgpd.Membro_BatismoLgpd()))
        {
            InitializeComponent();
        }

        private void MembroBatismo_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de membro por batismo";
        }
    }
}
