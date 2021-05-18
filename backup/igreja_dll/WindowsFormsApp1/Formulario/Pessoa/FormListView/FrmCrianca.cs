﻿using business.classes.Pessoas;
using database;
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
    public partial class FrmCrianca : FormularioListView
    {
        

        public FrmCrianca(modelocrud modelo) : base(new ListViewCrianca(modelo, ""))
        {
            
            InitializeComponent();
        }

        private void Crianca_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de Crianças";
        }
    }
}