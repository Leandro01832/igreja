using business.classes;
using business.classes.Abstrato;
using business.classes.Intermediario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class PessoaApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Email { get; set; }
        public int Falta { get; set; }
        public int? celula_ { get; set; }
        public virtual Celula Celula { get; set; }
        public virtual Chamada Chamada { get; set; }
        public virtual List<PessoaMinisterio> Ministerios { get; set; }
        public virtual List<Historico> Historico { get; set; }
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }
        public string Img { get; set; }
    }
}