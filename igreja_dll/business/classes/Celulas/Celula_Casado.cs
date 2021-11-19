using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Casado")]
    public class Celula_Casado : Abstrato.Celula
    {
        public Celula_Casado(bool v) : base(v){ }
        public Celula_Casado() : base(){ }
    }
}
