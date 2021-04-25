using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class PessoaMinisterioApi
    {
        public int IdPessoaMinisterio { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int MinisterioId { get; set; }
        public virtual Ministerio Ministerio { get; set; }
    }
}