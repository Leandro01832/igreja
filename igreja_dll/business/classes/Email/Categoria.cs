using database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business
{
    public class Categoria : modelocrud
    {
        [Key, ForeignKey("Permissao")]
        public new int Id { get; set; }

        public virtual List<Email> Email { get; set; }

        public virtual Permissao Permissao { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Permissao.Nome;
        }
    }
}