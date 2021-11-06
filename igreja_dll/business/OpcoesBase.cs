using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business
{
   public class OpcoesBase : Attribute
    {
        public bool Obrigatorio { get; set; }
        public bool ChavePrimaria { get; set; }
        public bool ChaveEstrangeira { get; set; }
        public bool Index { get; set; }
    }
}
