using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Cantina")]
    public class Cantina : MovimentacaoEntrada
    {
        public Cantina(bool v) : base(v) { }
        public Cantina() : base() { }
    }
}
