
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoXamarin.models
{
    public class ReuniaoPessoa : modelocrud
    {
        public int IdReuniaoPessoa { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int ReuniaoId { get; set; }
        public virtual Reuniao Reuniao { get; set; }
    }
}
