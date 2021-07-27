using database;
using System.Collections.Generic;

namespace business.contrato
{
    interface IBuscaLista
    {
        List<int> buscarLista(modelocrud TipoDaLista, modelocrud Ligacao, string nomeDaChave, int id);
    }
}
