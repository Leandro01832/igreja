using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_BatismoLgpd")]
    public class Membro_BatismoLgpd : MembroLgpd
    {
        public Membro_BatismoLgpd() : base(){}

        public Membro_BatismoLgpd(bool v) : base(v)
        {
        }
    }
}
