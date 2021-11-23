using business.classes.Abstrato;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace business.classes.PessoasLgpd
{
    [Table("Membro_TransferenciaLgpd")]
    public class Membro_TransferenciaLgpd : MembroLgpd
    {
        private string nome_cidade_transferencia = "nome";
        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Nome_cidade_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_cidade_transferencia))
                    throw new Exception("Nome_cidade_transferencia");
                return nome_cidade_transferencia;
            }
            set
            {
                nome_cidade_transferencia = value;
                if (string.IsNullOrWhiteSpace(nome_cidade_transferencia))
                    throw new Exception("Nome_cidade_transferencia");
            }
        }

        private string estado_transferencia = "estado";
        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Estado_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(estado_transferencia))
                    throw new Exception("Estado_transferencia");
                return estado_transferencia;
            }
            set
            {
                estado_transferencia = value;
                if (string.IsNullOrWhiteSpace(estado_transferencia))
                    throw new Exception("Estado_transferencia");
            }
        }

        private string nome_igreja_transferencia = "nome";
        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Nome_igreja_transferencia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome_igreja_transferencia))
                    throw new Exception("Nome_igreja_transferencia");
                return nome_igreja_transferencia;
            }
            set
            {
                nome_igreja_transferencia = value;
                if (string.IsNullOrWhiteSpace(nome_igreja_transferencia))
                    throw new Exception("Nome_igreja_transferencia");
            }
        }

        public Membro_TransferenciaLgpd() : base(){ }
    }
}
