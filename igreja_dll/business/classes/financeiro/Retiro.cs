using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Retiro")]
    public class Retiro : MovimentacaoSaida
    {

        public Retiro(bool v) : base(v){  }
        public Retiro() : base(){  }

        public string Local { get; set; }
    }
}
