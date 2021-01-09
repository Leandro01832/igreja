using database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class FrmMembro : FormularioListView
    {

        public FrmMembro(modelocrud modelo, string tipo, bool Lgpd) : base(new ListViewMembro(modelo, tipo), Lgpd)
        {
            InitializeComponent();
        }



        private void Membro_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de membros";
        }
    }
}
