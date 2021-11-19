using business.classes.Esboco.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Esboco.Fontes
{
    [Table("CanalTv")]
   public class CanalTv : Fonte
    {
        public string NomeCanal { get; set; }
        public string NomePrograma { get; set; }

        [Display(Name = "Horário")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Horario { get; set; }

        public CanalTv(bool v) : base(v)
        {

        }
        public CanalTv() : base()
        {

        }
    }
}
