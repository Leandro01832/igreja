using business.classes.Pessoas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.PessoasLgpd
{
    [Table("CriancaLgpd")]
    public class CriancaLgpd : PessoaLgpd
    {
        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_pai { get; set; }

        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae { get; set; }
        

        public CriancaLgpd() : base() { }
        public CriancaLgpd(int m) : base(m) {  }
    }
}
