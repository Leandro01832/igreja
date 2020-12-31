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
    public partial class MembroAclamacao : FormularioListView
    {

        public MembroAclamacao() : base(
            new ListViewMembroAclamacao
            (new business.classes.PessoasLgpd.Membro_AclamacaoLgpd(), ""))
        {
            InitializeComponent();
        }

        private void MembroAclamacao_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de membros por aclamação";
        }

        
    }
}
