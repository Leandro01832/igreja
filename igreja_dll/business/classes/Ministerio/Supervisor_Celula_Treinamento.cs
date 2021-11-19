using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula_Treinamento")]
    public class Supervisor_Celula_Treinamento : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula_Treinamento(bool v) : base(v)
        {
            this.Maximo_celula = 5;
        }
        public Supervisor_Celula_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }
        
    }
}
