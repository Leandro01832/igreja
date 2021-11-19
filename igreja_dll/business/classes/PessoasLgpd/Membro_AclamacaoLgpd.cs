using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_AclamacaoLgpd")]
    public class Membro_AclamacaoLgpd : MembroLgpd
    {
        private string denominacao = "denominação";
        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Denominacao
        {
            get
            {
                if (string.IsNullOrWhiteSpace(denominacao))
                    throw new Exception("Denominacao");
                return denominacao;
            }
            set { denominacao = value; }
        }

        public Membro_AclamacaoLgpd() : base(){ }

        public Membro_AclamacaoLgpd(bool v)
        {
        }
    }
}
