using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class ReuniaoApi
    {       
        public int Id { get; set; }        
        public DateTime Data_reuniao { get; set; }         
        public TimeSpan? Horario_inicio { get; set; }       
        public TimeSpan? Horario_fim { get; set; }       
        public string Local_reuniao { get; set; }        
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }        
    }
}