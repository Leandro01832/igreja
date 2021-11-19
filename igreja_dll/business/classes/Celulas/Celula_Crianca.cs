using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Crianca")]
    public class Celula_Crianca : Abstrato.Celula
    {
        public Celula_Crianca() : base() { }
        public Celula_Crianca(bool v) : base(v) { }
    }
}
