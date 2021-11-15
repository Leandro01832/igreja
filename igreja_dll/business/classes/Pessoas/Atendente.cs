using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace business.classes.Pessoas
{
    [Table("Atendente")]
    public class Atendente : PessoaDado
    {
        public virtual List<EmailPessoa> EmailPessoa { get; set; }
        public virtual List<PermissaoPessoa> Permissao { get; set; }
        public string Senha { get; set; }
    }
}
