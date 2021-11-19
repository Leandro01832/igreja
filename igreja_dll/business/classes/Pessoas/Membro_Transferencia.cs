using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Membro_Transferencia")]
    public class Membro_Transferencia : Membro
    {
        string nome_cidade_transferencia = "nome";
        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio = true)]
        public string Nome_cidade_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_cidade_transferencia))
                    throw new Exception("Nome_cidade_transferencia");
                return nome_cidade_transferencia;
            }
            set { nome_cidade_transferencia = value; }
        }

        private string estado_transferecia = "estado";
        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio = true)]
        public string Estado_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(estado_transferecia))
                    throw new Exception("Estado_transferecia");
                return estado_transferecia;
            }
            set { estado_transferecia = value; }
        }

        private string nome_igreja_transferencia = "nome";
        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio = true)]
        public string Nome_igreja_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_igreja_transferencia))
                    throw new Exception("Nome_igreja_transferencia");
                return nome_igreja_transferencia;
            }
            set { nome_igreja_transferencia = value; }
        }

        public Membro_Transferencia() : base(){ }

        public Membro_Transferencia(bool v) : base(v)
        {
        }
    }
}
