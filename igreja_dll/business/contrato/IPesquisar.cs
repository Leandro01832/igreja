using database;
using System;
using System.Collections.Generic;

namespace business.contrato
{
    public interface IPesquisar
    {
        List<modelocrud> PesquisarPorData   (List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo, Type tipo);
        List<modelocrud> PesquisarPorNumero (List<modelocrud> modelos, int comecar, int terminar, string campo, Type tipo);
        List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo, Type tipo);
        List<modelocrud> PesquisarPorTexto  (List<modelocrud> modelos, string texto, string campo, Type tipo);
        List<modelocrud> PesquisarPorCondicao(List<modelocrud> modelos, bool condicao, string campo, Type tipo);

    }                 
}
