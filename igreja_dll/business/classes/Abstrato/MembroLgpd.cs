using business.classes.Pessoas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Abstrato
{
    [Table("MembroLgpd")]
    public abstract class MembroLgpd : PessoaLgpd
    {        
        [Display(Name = "Ano de batismo")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        // Verificar se propriedade fica nesta classe abstrata. provavelmente não.
        public int Data_batismo { get; set; }

        public bool Desligamento { get; set; }
        
        public string Motivo_desligamento { get; set; }

        public MembroLgpd() : base(){ }

        protected MembroLgpd(bool v) : base(v)
        {
        }
    }
}
