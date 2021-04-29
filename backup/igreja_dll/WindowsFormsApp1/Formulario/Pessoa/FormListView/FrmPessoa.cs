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
    public partial class FrmPessoa : FormularioListView
    {

        public FrmPessoa(modelocrud modelo, string tipo) : base(new ListViewPessoa(modelo, tipo))
        {     
            InitializeComponent();
        }
        
        private void Pessoa_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de pessoas";
        }
    }
}
