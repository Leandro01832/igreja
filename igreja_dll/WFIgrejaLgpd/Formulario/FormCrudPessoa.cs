using database;
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
    public partial class FormCrudPessoa : WFCrud
    {
        public FormCrudPessoa()
        {

        }

        public FormCrudPessoa(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FormCrudPessoa_Load(object sender, EventArgs e)
        {

        }
    }
}
