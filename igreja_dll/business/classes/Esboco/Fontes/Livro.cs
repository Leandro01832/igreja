using business.classes.Esboco.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Esboco.Fontes
{
    [Table("Livro")]
    public class Livro : Fonte
    {
        public string NomeLivro { get; set; }
        public string NomeAutor { get; set; }

        public Livro() : base()
        {

        }
        
    }
}
