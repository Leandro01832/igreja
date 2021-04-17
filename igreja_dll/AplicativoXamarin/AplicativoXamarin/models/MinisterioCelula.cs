
using AplicativoXamarin.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoXamarin.models
{
   public class MinisterioCelula 
    {
        public int CelulaId { get; set; }
        public virtual Celula Celula { get; set; }
        public int MinisterioId { get; set; }
        public virtual Ministerio Ministerio { get; set; }
    }
    
}
