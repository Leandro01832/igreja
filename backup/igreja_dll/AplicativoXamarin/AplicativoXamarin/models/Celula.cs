
using AplicativoXamarin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicativoXamarin.models
{
    public class Celula : modelocrud
    {
        public int IdCelula { get; set; }
        public string Nome { get; set; }
        public string Dia_semana { get; set; }
        public TimeSpan? Horario { get; set; }        
        public virtual List<Pessoa> Pessoas { get; set; }
        public int Maximo_pessoa { get; set; }
        public virtual List<MinisterioCelula> Ministerios { get; set; }
        public virtual EnderecoCelula EnderecoCelula { get; set; }
        public string HorarioCelula
        { get
            {
                return Horario.Value.Hours.ToString()
                + ":" + Horario.Value.Hours.ToString();
            }
        }


        public Celula() : base()
        {
            this.Maximo_pessoa = 50;
            EnderecoCelula = new EnderecoCelula();
        }
        
    }
}
