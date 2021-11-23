using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Oferta")]
    public class Oferta : MovimentacaoEntrada
    {
        public Oferta()
        {
            this.Pessoa_ = null;
        }

    }
}
