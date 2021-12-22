using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Cantina")]
    public class Cantina : MovimentacaoEntrada
    {
        public Cantina() : base() { }
    }
}
