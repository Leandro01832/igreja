using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Retiro")]
    public class Retiro : MovimentacaoSaida
    {
        public Retiro() : base(){  }

        public string Local { get; set; }
    }
}
