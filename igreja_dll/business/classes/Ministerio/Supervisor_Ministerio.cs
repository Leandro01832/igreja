using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio")]
    public class Supervisor_Ministerio : Abstrato.Ministerio
    {

        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Ministerio() : base()
        {
            this.Maximo_celula = 5;
        }

        public Supervisor_Ministerio(int m) : base(m) { }
    }
}
