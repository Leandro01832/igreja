using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Compra")]
    public class Compra : MovimentacaoSaida
    {
        public Compra() : base(){ }
        public Compra(bool v) : base(v){ }

        public string NomeProduto { get; set; }
    }
}
