
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoXamarin.models
{
    public class Reuniao : modelocrud
    {
        public int IdReuniao { get; set; }
        public DateTime Data_reuniao { get; set; }
        public TimeSpan? Horario_inicio { get; set; }
        public TimeSpan? Horario_fim { get; set; }
        public string Local_reuniao { get; set; }
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }

        public string inicio
        {
            get {
                return Horario_inicio.Value.Hours.ToString() + ":"
                + Horario_inicio.Value.Minutes.ToString();
                }
        }

        public string final
        {
            get
            {
                return Horario_fim.Value.Hours.ToString() + ":"
                + Horario_fim.Value.Minutes.ToString();
            }
        }


        public Reuniao() 
        {
        }
    }
}
