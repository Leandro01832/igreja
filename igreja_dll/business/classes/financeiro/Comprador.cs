using business.classes.Pessoas;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Comprador")]
    public class Comprador : PessoaDado
    {
        public Comprador() : base() { }
    }
}