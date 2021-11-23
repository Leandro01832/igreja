using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : Pessoa
    {
        public PessoaLgpd() : base(){ }
        
        public override string ToString()
        {
            return this.Codigo + " - " + this.Email;
        }
    }
}
