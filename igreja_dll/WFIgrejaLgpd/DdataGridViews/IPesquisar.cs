﻿using database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFIgrejaLgpd.DdataGridViews
{
    interface IPesquisar
    {
        List<modelocrud> BuscarPorRestricao(modelocrud data, string tipo, string comando);

    }
}