using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("MovimentacaoSaida")]
    public abstract class MovimentacaoSaida : Movimentacao
    {
        public MovimentacaoSaida()
        {

        }
    }
}
