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

        private DateTime data_inicio = new DateTime(2001, 01, 01);
        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_inicio
        {
            get
            {
                if (data_inicio.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_inicio");
                return data_inicio;
            }
            set
            {
                data_inicio = value;
                if (data_inicio.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_inicio");
            }
        }

        [Display(Name = "Numero da chamada")]
        public int Numero_chamada { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        

        public Chamada()
        {
            if (!EntityCrud)
            {
                Data_inicio = DateTime.Now;
                Numero_chamada = 0;

            }
        }
        
    }
}
