using business.classes.Pessoas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Abstrato
{
    [Table("Membro")]
    public abstract class Membro : PessoaDado
    {                
        [Display(Name = "Ano de batismo")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        // Verificar se propriedade fica nesta classe abstrata. provavelmente não.
        public int Data_batismo { get; set; }

        [ScaffoldColumn(false)]
        public bool Desligamento { get; set; }

        public bool Save()
        {
            return true;
        }

        public string Motivo_desligamento { get; set; }

        public Membro() : base()
        {
            Desligamento = false;
        }

        protected Membro(int m) : base(m) { }
    }
}
