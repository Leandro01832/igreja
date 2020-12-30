using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ListViews;

namespace WindowsFormsApp1.Formulario.Pessoa
{
    public partial class Crianca : FormularioListView
    {
        

        public Crianca() : base(
            new ListViewCrianca
            (new business.classes.Pessoas.Crianca()))
        {
            
            InitializeComponent();
        }

        private void Crianca_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de Crianças";
        }
    }
}
