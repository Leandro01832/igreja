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
            progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
        }
        
    }
}
