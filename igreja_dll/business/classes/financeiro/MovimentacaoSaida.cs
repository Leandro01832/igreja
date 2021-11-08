using System.ComponentModel.DataAnnotations.Schema;

namespace business.Classe.financeiro
{
    [Table("MovimentacaoSaida")]
    public abstract class MovimentacaoSaida : Movimentacao
    {
        public MovimentacaoSaida()
        {

        }
    }
}
