﻿using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Bazar")]
    public class Bazar : MovimentacaoEntrada
    {
        public Bazar() : base(){ }
        public Bazar(bool v) : base(v){ }
    }
}
