using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("Membro_Aclamacao")]
    public class Membro_Aclamacao : Membro
    {
        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Denominacao { get; set; }        

        public Membro_Aclamacao() : base() { }
        public Membro_Aclamacao(int m) : base(m) {  }
    }
}
