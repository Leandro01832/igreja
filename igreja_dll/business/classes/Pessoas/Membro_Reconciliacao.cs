using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Membro_Reconciliacao")]
    public class Membro_Reconciliacao : Membro
    {
        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao { get; set; }
        
        public Membro_Reconciliacao() : base(){ }
        public Membro_Reconciliacao(int m) : base(m) { }
    }
}
