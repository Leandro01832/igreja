using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes
{
   public class Cargo_Lider_Ministerio
    {
        [Key, ForeignKey("Ministerio")]
        public int Id_Lider_Ministerio { get; set; }

        public int? pessoa_ { get; set; }
        [ForeignKey("pessoa_")]
        public virtual Pessoa Pessoa { get; set; }

        public virtual Ministerio Ministerio { get; set; }
    }
}
