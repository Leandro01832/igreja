using business.classes.Pessoas;
using database;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes
{
    public class Telefone : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual PessoaDado Pessoa { get; set; }

        public string Fone { get; set; }

        public string Celular { get; set; }

        public string Whatsapp { get; set; }
        

        public Telefone() : base(){}
    }
}
