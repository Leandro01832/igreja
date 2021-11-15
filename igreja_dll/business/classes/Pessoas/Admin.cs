using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace business.classes.Pessoas
{
    [Table("Admin")]
    public class Admin : PessoaDado
    {
        public string Password { get; set; }
    }
}
