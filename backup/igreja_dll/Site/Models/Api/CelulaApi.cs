using business.classes.Abstrato;
using business.classes.Celula;
using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class CelulaApi
    {
        public int IdCelula { get; set; }        
        public string Nome { get; set; }        
        public string Dia_semana { get; set; }        
        public TimeSpan? Horario { get; set; }
        public virtual List<Pessoa> Pessoas { get; set; }        
        public int Maximo_pessoa { get; set; }
        public virtual List<MinisterioCelula> Ministerios { get; set; }
        public virtual EnderecoCelula EnderecoCelula { get; set; }
    }
}