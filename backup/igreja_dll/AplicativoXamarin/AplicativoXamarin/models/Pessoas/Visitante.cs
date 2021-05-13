
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.Pessoas
{
    public class Visitante : PessoaDado
    {       
        public DateTime Data_visita { get; set; }
        public string Condicao_religiosa { get; set; }


        public Visitante() : base()
        {
        }

        internal string ReturnJson(Visitante v)
        {
            var j = JsonConvert.SerializeObject(v);
            return j;
        }
    }
}
