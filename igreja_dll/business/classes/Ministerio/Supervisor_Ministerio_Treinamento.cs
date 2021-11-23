using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio_Treinamento")]
    public class Supervisor_Ministerio_Treinamento : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisionar")]
        public int Maximo_celula { get; set; }
        
        public Supervisor_Ministerio_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }
    }
}
