﻿using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.ListViews
{
    class ListViewMembro : ListViewPessoa
    {
        public ListViewMembro(modelocrud modelo, string tipo) : base(modelo, tipo)
        {

        }
    }
}
