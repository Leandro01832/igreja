
using System;

namespace AplicativoXamarin.models
{
    public  class Chamada 
    {
        public int Id { get; set; }
        public  DateTime Data_inicio{ get; set; }
        public int Numero_chamada { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public Chamada()
        {
        }

        
    }
}
