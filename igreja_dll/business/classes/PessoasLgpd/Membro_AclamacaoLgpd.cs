using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_AclamacaoLgpd")]
    public class Membro_AclamacaoLgpd : MembroLgpd
    {
        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Denominacao { get; set; }
        
        public Membro_AclamacaoLgpd() : base(){ }
    }
}
