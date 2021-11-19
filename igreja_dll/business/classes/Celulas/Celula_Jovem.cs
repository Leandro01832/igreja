using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Jovem")]
    public class Celula_Jovem : Abstrato.Celula
    {
        public Celula_Jovem(bool v) : base(v){ }
        public Celula_Jovem() : base(){ }
    }
}
