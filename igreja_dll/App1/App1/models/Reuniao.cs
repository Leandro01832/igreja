
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mobile.models
{
    public class Reuniao 
    {
        public int IdReuniao { get; set; }
        public DateTime Data_reuniao { get; set; }
        public TimeSpan? Horario_inicio { get; set; }
        public TimeSpan? Horario_fim { get; set; }
        public string Local_reuniao { get; set; }
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }
        

        public Reuniao() : base()
        {
        }
    }
}
