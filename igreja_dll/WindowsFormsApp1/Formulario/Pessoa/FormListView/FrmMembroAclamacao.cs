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
    public partial class FrmMembroAclamacao : FormularioListView
    {

        public FrmMembroAclamacao(modelocrud modelo, bool Lgpd) : base(new ListViewMembroAclamacao(modelo, ""), Lgpd)
        {
            InitializeComponent();
        }

        private void MembroAclamacao_Load(object sender, EventArgs e)
        {
            this.Text = " - Lista de membros por aclamação";
        }

        
    }
}
