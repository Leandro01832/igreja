using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.financeiro
{
    [Table("MovimentacaoEntrada")]
    public abstract class MovimentacaoEntrada : Movimentacao
    {
        public MovimentacaoEntrada(bool v) : base(v)
        {

        }public MovimentacaoEntrada() : base()
        {

        }

        public DateTime? DataRecebimento { get; set; }
        public int? Pessoa_ { get; set; }
        [ForeignKey("Pessoa_")]
        public virtual Pessoa Pessoa { get; set; }
    }
}
