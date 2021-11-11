using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Text;

namespace business
{
   public class PermissaoPessoa : modelocrud
    {
        public int PermissaoId { get; set; }
        public Permissao Permissao { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
