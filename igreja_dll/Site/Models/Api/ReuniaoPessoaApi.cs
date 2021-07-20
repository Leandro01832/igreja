using business.classes;
using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class ReuniaoPessoaApi
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int ReuniaoId { get; set; }
        public virtual Reuniao Reuniao { get; set; }
    }
}