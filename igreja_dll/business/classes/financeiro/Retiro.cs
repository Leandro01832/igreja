using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Classe.financeiro
{
    [Table("Retiro")]
    public class Retiro : MovimentacaoSaida
    {
        public string Local { get; set; }
    }
}
