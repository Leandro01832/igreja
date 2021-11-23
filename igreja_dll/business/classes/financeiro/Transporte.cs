﻿using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("Transporte")]
    public class Transporte : MovimentacaoSaida
    {
        public Transporte() : base() { }

        public bool Gasolina { get; set; }
        public bool Alcool { get; set; }
        public bool Diesel { get; set; }
    }
}
