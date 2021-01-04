﻿using System;
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
    public partial class LiderCelula : FormularioListView
    {
        public LiderCelula() : base(
         new ListViewLiderCelula
         (new business.classes.Ministerio.Lider_Celula(), ""))
        {
            InitializeComponent();
        }

        private void LiderCelula_Load(object sender, EventArgs e)
        {
            this.Text = " - Lider de celula";
        }
    }
}