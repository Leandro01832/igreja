﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormProgressBar2 : Form
    {
        public FormProgressBar2()
        {
            InitializeComponent();
        }

        private void FormProgressBar2_Load(object sender, EventArgs e)
        {
            FormPadrao.LoadForm(this);
            progressBar1.Style = ProgressBarStyle.Marquee;
        }
    }
}
