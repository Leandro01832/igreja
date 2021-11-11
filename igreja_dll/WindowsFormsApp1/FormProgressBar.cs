using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormProgressBar : Form
    {
        public FormProgressBar()
        {
            InitializeComponent();
            
            label1.Text = modelocrud.textoPorcentagem;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
        }

        private void ProgressBar_Tick(object sender, EventArgs e)
        {
            label1.Text = modelocrud.textoPorcentagem;
            var numero = modelocrud.textoPorcentagem.Replace("%", "");

            if (int.Parse(numero) <= 100)
                progressBar1.Value = int.Parse(numero);
            else
                progressBar1.Value = 100;
        }
    }
}
