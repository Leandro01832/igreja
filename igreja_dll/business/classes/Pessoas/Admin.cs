using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.classes.Pessoas
{
    public class Admin : PessoaDado
    {
        public string Password { get; set; }
    }
}
