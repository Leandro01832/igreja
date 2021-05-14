using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
   public interface IPesquisar
    {
        string PesquisarPorData(DateTime comecar, DateTime terminar, string campo);
        string PesquisarPorData(DateTime apenasUmDia, string campo);
        string PesquisarPorNumero(int comecar, int terminar, string campo);
        string PesquisarPorNumero(int apenasUmNumero, string campo);
        string PesquisarPorTexto(string texto, string campo);
        string PesquisarPorHorario(TimeSpan comecar, TimeSpan terminar, string campo);   
        string PesquisarPorHorario(TimeSpan apenasUmHorario, string campo);   

    }                 
}
