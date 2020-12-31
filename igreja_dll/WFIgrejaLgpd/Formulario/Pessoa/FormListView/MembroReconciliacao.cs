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
    public partial class MembroReconciliacao : FormularioListView
    {
        public MembroReconciliacao() : base(
            new ListViewCrianca
            (new business.classes.PessoasLgpd.Membro_ReconciliacaoLgpd(), ""))
        {
            InitializeComponent();
        }

        private void MembroReconciliacao_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de Membro por reconciliação";
        }
    }
}
