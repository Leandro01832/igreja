using database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business
{
    public class Body : modelocrud
    {
        [Key, ForeignKey("EmailIgreja")]
        public new int Id { get; set; }
        public string Html { get; set; }
        public EmailIgreja EmailIgreja { get; set; }
    }
}