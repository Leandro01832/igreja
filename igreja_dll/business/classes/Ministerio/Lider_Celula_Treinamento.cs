using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Lider_Celula_Treinamento")]
    public class Lider_Celula_Treinamento : Abstrato.Ministerio
    {
        public Lider_Celula_Treinamento(bool v) : base(v){ }
        public Lider_Celula_Treinamento() : base(){ }
    }
}
