using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Dizimo")]
    public class Dizimo : MovimentacaoEntrada
    {
        public Dizimo() : base()
        {
            this.Pessoa_ = null;
        }

        public Dizimo(bool v) : base(v) { this.Pessoa_ = null; }
    }
}
