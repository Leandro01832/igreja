using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class MinisterioApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Proposito { get; set; }
        public virtual List<PessoaMinisterio> Pessoas { get; set; }
        public int? Ministro_ { get; set; }
        public virtual List<MinisterioCelula> Celulas { get; set; }
        public int Maximo_pessoa { get; set; }
    }
}