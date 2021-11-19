using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula")]
    public class Supervisor_Celula : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula(bool v) : base(v)
        {
            this.Maximo_celula = 5;
        }
        public Supervisor_Celula() : base()
        {
            this.Maximo_celula = 5;
        }
        
    }
}
