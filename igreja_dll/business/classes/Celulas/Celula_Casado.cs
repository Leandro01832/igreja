using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Casado")]
    public class Celula_Casado : Abstrato.Celula
    {
        public Celula_Casado() : base(){ }
        public Celula_Casado(int m) : base(m) { }
    }
}
