
using System;
using System.Collections.Generic;

namespace AplicativoXamarin.models
{
    public class EnderecoCelula 
    {      
        
        public int Id { get; set; }
        public virtual Celula Celula { get; set; }
        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public int Numero_casa { get; set; }

        public long Cep { get; set; }

        public string Complemento { get; set; }

        public EnderecoCelula() : base()
        {
        }

    }

}