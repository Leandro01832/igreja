﻿using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ListViews
{
    class ListViewVisitante : ListViewPessoa
    {
        public ListViewVisitante(modelocrud modelo, string tipo) : base(modelo, tipo)
        {

        }

    }
}