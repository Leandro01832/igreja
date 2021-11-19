using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : Pessoa
    {
        public PessoaLgpd() : base(){ }

        protected PessoaLgpd(bool v) : base(v)
        {
        }

        public override string ToString()
        {
            return this.Codigo + " - " + this.Email;
        }
    }
}
