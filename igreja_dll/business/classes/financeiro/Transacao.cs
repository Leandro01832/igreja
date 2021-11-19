using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Transacao")]
    public class Transacao : MovimentacaoSaida
    {

        public Transacao(bool v) : base(v) { }
        public Transacao() : base() { }
    }
}
