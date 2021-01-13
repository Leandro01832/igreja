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

namespace WindowsFormsApp1.Formulario
{
    public partial class FormCrudReuniao : WFCrud
    {
        public FormCrudReuniao()
        {

        }

        public FormCrudReuniao(modelocrud modelo, bool deletar, bool atualizar, bool detalhes)
        : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FormCrudReuniao_Load(object sender, EventArgs e)
        {

        }
    }
}
