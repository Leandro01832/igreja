using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.Formulario
{
    public partial class FormCrudMinisterio : WFCrud
    {
        public FormCrudMinisterio()
        {

        }

        public FormCrudMinisterio(business.classes.Abstrato.Ministerio p, bool Deletar, bool Atualizar, bool Detalhes)
           : base(p, Deletar, Atualizar, Detalhes)
        {
            InitializeComponent();
        }

        private void FormCrudMinisterio_Load(object sender, EventArgs e)
        {

        }
    }
}
