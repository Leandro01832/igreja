using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Models.Api
{
    public class MinisterioCelulaApi
    {
        public int Id { get; set; }
        public int CelulaId { get; set; }
        public virtual Celula Celula { get; set; }
        public int MinisterioId { get; set; }
        public virtual Ministerio Ministerio { get; set; }
    }
}