using database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
   public interface IPesquisar
    {
        List<modelocrud> PesquisarPorData   (List<modelocrud> modelos, DateTime comecar, DateTime terminar, string campo);
        List<modelocrud> PesquisarPorData   (List<modelocrud> modelos, DateTime apenasUmDia, string campo);
        List<modelocrud> PesquisarPorNumero (List<modelocrud> modelos, int comecar, int terminar, string campo);
        List<modelocrud> PesquisarPorNumero (List<modelocrud> modelos, int apenasUmNumero, string campo);
        List<modelocrud> PesquisarPorTexto  (List<modelocrud> modelos, string texto, string campo);
        List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos, TimeSpan comecar, TimeSpan terminar, string campo);
        List<modelocrud> PesquisarPorHorario(List<modelocrud> modelos,  TimeSpan apenasUmHorario, string campo);   

    }                 
}
