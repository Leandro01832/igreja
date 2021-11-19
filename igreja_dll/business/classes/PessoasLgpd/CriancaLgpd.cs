using business.classes.Pessoas;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.PessoasLgpd
{
    [Table("CriancaLgpd")]
    public class CriancaLgpd : PessoaLgpd
    {
        private string nome_pai = "nome";
        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Nome_pai
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_pai))
                    throw new Exception("Nome_pai");
                return nome_pai;
            }
            set
            {
                nome_pai = value;
                if (string.IsNullOrWhiteSpace(nome_pai))
                    throw new Exception("Nome_pai");
            }
        }

        private string nome_mae = "nome";
        [Display(Name = "Nome da mãe")]
        [OpcoesBase(Obrigatorio =true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_mae))
                    throw new Exception("Nome_mae");
                return nome_mae;
            }
            set
            {
                nome_mae = value;
                if (string.IsNullOrWhiteSpace(nome_mae))
                    throw new Exception("Nome_mae");
            }
        }


        public CriancaLgpd() : base() { }

        public CriancaLgpd(bool v) : base(v)
        {
        }
    }
}
