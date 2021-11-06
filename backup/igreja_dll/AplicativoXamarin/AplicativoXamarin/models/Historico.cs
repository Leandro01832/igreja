
using System;

namespace AplicativoXamarin.models
{
    public class Historico 
    {       
        public int IdHistorico { get; set; }
        public DateTime Data_inicio{get; set; }
        public int pessoaid { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int Falta { get; set; }
        public Historico() : base()
        {
        }

    }
}
