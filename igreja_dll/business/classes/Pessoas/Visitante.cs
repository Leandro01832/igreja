using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Visitante")]
    public class Visitante : PessoaDado
    {
        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita { get; set; }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa { get; set; }        

        public Visitante() : base() { }

        public Visitante(int m) : base(m) {  }        
    }
}
