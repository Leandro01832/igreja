using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Membro_Reconciliacao")]
    public class Membro_Reconciliacao : Membro
    {
        private int data_reconciacao = 10;
        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public int Data_reconciliacao
        {
            get
            {
                if (data_reconciacao == 0)
                    throw new Exception("data_reconciacao");
                return data_reconciacao;
            }
            set { data_reconciacao = value; }
        }

        public Membro_Reconciliacao() : base(){ }
    }
}
