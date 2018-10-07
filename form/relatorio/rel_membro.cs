﻿using igreja2.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.form.relatorio
{
    public partial class rel_membro : Form
    {
        public rel_membro()
        {
            InitializeComponent();
        }

        private void rel_membro_Load(object sender, EventArgs e)
        {

            Membro mem = new Membro();

            string comando = mem.recuperar();

            bindingSource_membro.DataSource = 
                mem.bd.montar_relatorio(comando, false, false, null);

            this.reportViewer1.RefreshReport();
        }
    }
}
