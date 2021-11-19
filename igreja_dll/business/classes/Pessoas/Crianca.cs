using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.Pessoas
{
    [Table("Crianca")]
    public class Crianca : PessoaDado
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
            set { nome_pai = value; }
        }



        private string nome_mae = "nome";
        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Nome_mae
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_mae))
                    throw new Exception("Nome_mae");
                return nome_mae;
            }
            set { nome_mae = value; }
        }

        public Crianca() : base(){ }

        public Crianca(bool v) : base(v)
        {
        }
    }
}
