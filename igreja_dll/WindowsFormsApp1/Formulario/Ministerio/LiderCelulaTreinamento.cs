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

namespace WindowsFormsApp1.Formulario.Ministerio
{
    public partial class LiderCelulaTreinamento : FormularioListView
    {
        public LiderCelulaTreinamento() : base(
         new ListViewLiderCelulaTtreinamento
         (new business.classes.Ministerio.Lider_Celula_Treinamento(), ""))
        {
            InitializeComponent();
        }

        private void LiderCelulaTreinamento_Load(object sender, EventArgs e)
        {
            this.Text = " - Lider em treinamento de celulas";
        }
    }
}
