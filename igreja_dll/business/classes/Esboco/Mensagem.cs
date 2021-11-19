using business.classes.Esboco.Abstrato;
using database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Esboco
{
    [Table("Mensagem")]
    public class Mensagem : modelocrud
    {
        public Mensagem(bool v) : base(v) {  }
        public Mensagem() : base() {  }

        public List<Fonte> Fontes { get; set; }
        public string Tipo { get; set; }        

        public override string ToString()
        {
            return "Id: " + base.Id.ToString() + " Tipo de Msm: " + Tipo;
        }
    }
}
