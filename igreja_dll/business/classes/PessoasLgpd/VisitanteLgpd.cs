using business.classes.Pessoas;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("VisitanteLgpd")]
    public class VisitanteLgpd : PessoaLgpd
    {
        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita { get; set; }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa { get; set; }
        
        public VisitanteLgpd() : base(){ }
        public VisitanteLgpd(int m) : base(m) { }
    }
}
