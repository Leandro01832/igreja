﻿using database;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Celula
{
    public partial class Celula : FormularioListView
    {

        public Celula() : base(new ListViewCelula(null, "Celula"))
        {
            InitializeComponent();
        }

        private void Celula_Load(object sender, EventArgs e)
        {
            this.Text += " - Lista de celulas";
        }
    }
}
