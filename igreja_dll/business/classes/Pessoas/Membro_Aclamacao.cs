using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("Membro_Aclamacao")]
    public class Membro_Aclamacao : Membro
    {
        private string denominacao = "denominacao";
        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Denominacao
        {
            get
            {
                if (string.IsNullOrWhiteSpace(denominacao))
                    throw new Exception("Denominacao");
                return denominacao;
            }
            set
            {
                denominacao = value;
                if (string.IsNullOrWhiteSpace(denominacao))
                    throw new Exception("Denominacao");
            }
        }

        public Membro_Aclamacao() : base() { }

        public Membro_Aclamacao(bool v): base(v)
        {
        }
    }
}
