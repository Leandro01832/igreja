﻿using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
    interface IMudancaEstado
    {
        void MudarEstado(int id, modelocrud m);
    }
}