using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Compra")]
    public class Compra : MovimentacaoSaida
    {
        public string NomeProduto { get; set; }
    }
}
