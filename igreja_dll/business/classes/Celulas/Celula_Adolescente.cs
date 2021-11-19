using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    [Table("Celula_Adolescente")]
    public class Celula_Adolescente : Abstrato.Celula
    {
        public Celula_Adolescente(bool v) : base(v) { }
        public Celula_Adolescente() : base() { }
    }
}
