using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_ReconciliacaoLgpd")]
    public class Membro_ReconciliacaoLgpd : MembroLgpd
    {
        private int data_reconciliacao = 0;
        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public int Data_reconciliacao
        {
            get
            {
                if (data_reconciliacao == 0)
                    throw new Exception("Data_reconciliacao");
                return data_reconciliacao;
            }
            set { data_reconciliacao = value; }
        }

        public Membro_ReconciliacaoLgpd() : base(){}

    }
}
