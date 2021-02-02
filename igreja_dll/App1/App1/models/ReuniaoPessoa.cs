
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mobile.models
{
    public class ReuniaoPessoa 
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int ReuniaoId { get; set; }
        public virtual Reuniao Reuniao { get; set; }
    }
}
