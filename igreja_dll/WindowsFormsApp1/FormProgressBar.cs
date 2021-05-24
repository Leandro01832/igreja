using business.classes.Pessoas;
using database;
using database.banco;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FormProgressBar : FormPadrao
    {
        public FormProgressBar()
        {
            InitializeComponent();
            
            label1.Text = textoPorcentagem;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = textoPorcentagem;
            var numero = textoPorcentagem.Replace("%", "");

            if(int.Parse(numero) <= 100)
            progressBar1.Value = int.Parse(numero);
            else
                progressBar1.Value = 100;

        }
    }
}
