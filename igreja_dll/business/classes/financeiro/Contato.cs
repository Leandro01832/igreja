using business.classes.Abstrato;
using database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.Classe.financeiro
{
    [Table("Contato")]
    public class Contato : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int  Id { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public string Telefone { get; set; }
        public string Whatsapp { get; set; }
        public string Email { get; set; }
    }
}