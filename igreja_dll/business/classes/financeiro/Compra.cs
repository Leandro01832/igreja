using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Compra")]
    public class Compra : MovimentacaoSaida
    {
        public Compra() : base(){ }

        public string NomeProduto { get; set; }
    }
}
