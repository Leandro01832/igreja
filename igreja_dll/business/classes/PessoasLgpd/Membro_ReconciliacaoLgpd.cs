using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_ReconciliacaoLgpd")]
    public class Membro_ReconciliacaoLgpd : MembroLgpd
    {
        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao { get; set; }        

        public Membro_ReconciliacaoLgpd() : base(){}

        public Membro_ReconciliacaoLgpd(int m) : base(m) {  }
    }
}
