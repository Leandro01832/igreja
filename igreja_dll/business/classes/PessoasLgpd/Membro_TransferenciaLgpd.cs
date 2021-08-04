using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.PessoasLgpd
{
    [Table("Membro_TransferenciaLgpd")]
    public class Membro_TransferenciaLgpd : MembroLgpd
    {
        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_cidade_transferencia { get; set; }

        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_transferencia { get; set; }

        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_igreja_transferencia { get; set; }        

        public Membro_TransferenciaLgpd() : base(){ }
        public Membro_TransferenciaLgpd(int m) : base(m) {  }
    }
}
