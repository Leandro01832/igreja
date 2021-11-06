using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
    interface IBuscaLista
    {
        List<int> buscarLista(modelocrud TipoDaLista, modelocrud Ligacao, string nomeDaChave, int id);
    }
}
