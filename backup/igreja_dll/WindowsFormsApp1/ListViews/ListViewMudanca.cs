﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database;

namespace WindowsFormsApp1.ListViews
{
    public class ListViewMudanca : TodosListViews
    {
        public ListViewMudanca(modelocrud modelo, string tipo) : base(modelo, tipo)
        {
        }
    }
}