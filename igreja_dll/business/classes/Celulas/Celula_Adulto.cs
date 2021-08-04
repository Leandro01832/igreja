using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Adulto")]
    public class Celula_Adulto : Abstrato.Celula
    {
        public Celula_Adulto() : base(){ }
        public Celula_Adulto(int m) : base(m) { }
    }
}
