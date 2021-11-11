using business.classes.Abstrato;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.classes.Pessoas
{
   public class Atendente : Pessoa
    {
        public virtual List<EmailPessoa> EmailPessoa { get; set; }
        public virtual List<PermissaoPessoa> Permissao { get; set; }
        public string Senha { get; set; }
    }
}
