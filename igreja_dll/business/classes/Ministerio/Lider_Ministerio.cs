using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Lider_Ministerio")]
    public class Lider_Ministerio : Abstrato.Ministerio
    {
        public Lider_Ministerio(bool v) : base(v){ }
        public Lider_Ministerio() : base(){ }
    }
}
