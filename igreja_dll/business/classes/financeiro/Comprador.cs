using business.classes.Abstrato;
using business.classes.Pessoas;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.Classe.financeiro
{
    [Table("Comprador")]
    public class Comprador : PessoaDado
    {
    }
}