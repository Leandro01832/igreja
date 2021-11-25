using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace business
{
    [Table("EmailIgreja")]
    public class EmailIgreja : Email
    {
        public EmailIgreja()
        {
            if(!EntityCrud)
            Body = new Body();
        }

        public bool Enviado { get; set; }

        private int pessoaId = 0;
        [OpcoesBase(ChaveEstrangeira = true, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        public int PessoaId
        {
            get
            {
                if (pessoaId == 0)
                    throw new Exception("PessoaId");
                return pessoaId;
            }
            set
            {
                pessoaId = value;
                if (pessoaId == 0)
                    throw new Exception("PessoaId");
            }
        }
        [ForeignKey("PessoaId")]
        public virtual Pessoa Pessoa  { get; set; }
        public virtual Body Body { get; set; }
    }
}
