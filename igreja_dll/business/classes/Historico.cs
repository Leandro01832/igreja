using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{
    [Table("Historico")]
    public class Historico : modelocrud
    {
        public DateTime Data_inicio { get; set; }

        public int pessoaid { get; set; }

        [ForeignKey("pessoaid")]
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        public int Falta { get; set; }
        
        public Historico() : base(){ }
        
    }
}
