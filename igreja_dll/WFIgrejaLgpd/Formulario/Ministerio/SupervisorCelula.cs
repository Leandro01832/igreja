﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFIgrejaLgpd.ListViews;

namespace WFIgrejaLgpd.Formulario.Ministerio
{
    public partial class SupervisorCelula : FormularioListView
    {
        public SupervisorCelula() : base(
        new ListViewSupervisorCelula(new business.classes.Ministerio.Supervisor_Celula(), ""))
        {
            InitializeComponent();
        }

        private void SupervisorCelula_Load(object sender, EventArgs e)
        {
            this.Text = " -  Supervisionamento de celulas";
        }
    }
}