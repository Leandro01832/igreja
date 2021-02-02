using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.models
{
   public class Ministerio 
    {
        public int IdMinisterio { get; set; }        
        public string Nome { get; set; }        
        public string Proposito { get; set; }
        public virtual List<PessoaMinisterio> Pessoas { get; set; }
        public int? Ministro_ { get; set; }
        public virtual List<MinisterioCelula> Celulas { get; set; }
        public int Maximo_pessoa { get; set; }
        public Ministerio() 
        {
            this.Maximo_pessoa = 50;
        }
    }
}
