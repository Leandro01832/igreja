﻿using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFIgrejaLgpd.ListViews
{
    class ListViewMembroBatismo : ListViewPessoa
    {
        public ListViewMembroBatismo(modelocrud modelo, string tipo) : base(modelo, tipo)
        {

        }
    }
}