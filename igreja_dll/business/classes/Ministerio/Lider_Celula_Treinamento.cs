using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Lider_Celula_Treinamento")]
    public class Lider_Celula_Treinamento : Abstrato.Ministerio
    {
        public Lider_Celula_Treinamento() : base(){ }
        public Lider_Celula_Treinamento(int m) : base(m) { }
    }
}
