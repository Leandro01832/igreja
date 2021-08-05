using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Celulas
{
    public class EnderecoCelula : modelocrud
    {

        [Key, ForeignKey("Celula")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual Celula Celula { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rua { get; set; }

        [Display(Name = "Numero da casa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Numero_casa { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public long Cep { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Complemento { get; set; }
        
        public static List<EnderecoCelula> EnderecosCelula;

        public EnderecoCelula() : base(){ }

        public EnderecoCelula(int id) : base(id){ }
    }
}