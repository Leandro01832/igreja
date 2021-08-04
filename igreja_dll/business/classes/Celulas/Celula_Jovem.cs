using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Jovem")]
    public class Celula_Jovem : Abstrato.Celula
    {
        public Celula_Jovem() : base(){ }
        public Celula_Jovem(int m) : base(m) { }
    }
}
