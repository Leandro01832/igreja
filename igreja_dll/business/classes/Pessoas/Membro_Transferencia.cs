using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Membro_Transferencia")]
    public class Membro_Transferencia : Membro
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

        public Membro_Transferencia() : base(){ }
        public Membro_Transferencia(int m) : base(m) { }
    }
}
