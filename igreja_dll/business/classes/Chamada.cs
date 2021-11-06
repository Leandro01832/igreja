using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{
    public class Chamada : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_inicio { get; set; }

        [Display(Name = "Numero da chamada")]
        public int Numero_chamada { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        

        public Chamada()
        {
            Data_inicio = DateTime.Now;
            Numero_chamada = 0;
        }
        
    }
}
