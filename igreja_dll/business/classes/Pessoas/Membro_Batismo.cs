using business.classes.Abstrato;
using business.implementacao;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("Membro_Batismo")]
    public class Membro_Batismo : Membro
    {
        public Membro_Batismo() : base() { }
    }
}
