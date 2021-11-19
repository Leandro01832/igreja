using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Lider_Celula")]
    public class Lider_Celula : Abstrato.Ministerio
    {
        public Lider_Celula(bool v) : base(v){ }
        public Lider_Celula() : base(){ }
    }
}
