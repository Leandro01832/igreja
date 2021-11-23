using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.classes.financeiro
{
    [Table("Lava_Rapido")]
    public class Lava_Rapido : MovimentacaoEntrada
    {
        public Lava_Rapido() : base(){ }
    }
}
