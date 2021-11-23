using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Lider_Ministerio_Treinamento")]
    public class Lider_Ministerio_Treinamento : Abstrato.Ministerio
    {
        public Lider_Ministerio_Treinamento() : base(){ }
    }
}
