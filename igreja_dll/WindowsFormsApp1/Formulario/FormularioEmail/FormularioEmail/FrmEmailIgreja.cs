using business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formulario.FormularioEmail.FormularioEmail
{
    public partial class FrmEmailIgreja : WFCrud
    {
        public FrmEmailIgreja() : base()
        {
            InitializeComponent();
        }
        

        private void FrmEmailAdvocacia_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
            LoadCrudForm();
        }
    }
}
