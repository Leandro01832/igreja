using business.classes.Pessoas;
using database;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes
{

    public class Endereco : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual PessoaDado Pessoa { get; set; }

        private string pais = "pais";
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Pais
        {
            get
            {
                if (string.IsNullOrWhiteSpace(pais))
                    throw new Exception("Pais");
                return pais;
            }
            set
            {
                pais = value;
                if (string.IsNullOrWhiteSpace(pais))
                    throw new Exception("Pais");
            }
        }

        private string estado = "estado";
        [OpcoesBase(Obrigatorio =true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(estado))
                    throw new Exception("Estado");
                return estado;
            }
            set
            {
                estado = value;
                if (string.IsNullOrWhiteSpace(estado))
                    throw new Exception("Estado");
            }
        }

        private string cidade = "cidade";
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio = true)]
        public string Cidade
        {
            get
            {
                if (string.IsNullOrWhiteSpace(cidade))
                    throw new Exception("Cidade");
                return cidade;
            }
            set
            {
                cidade = value;
                if (string.IsNullOrWhiteSpace(cidade))
                    throw new Exception("Cidade");
            }
        }

        private string bairro = "bairro";
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Bairro
        {
            get
            {
                if (string.IsNullOrWhiteSpace(bairro))
                    throw new Exception("Bairro");
                return bairro;
            }
            set
            {
                bairro = value;
                if (string.IsNullOrWhiteSpace(bairro))
                    throw new Exception("Bairro");
            }
        }

        private string rua = "rua";
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Rua
        {
            get
            {
                if (string.IsNullOrWhiteSpace(rua))
                    throw new Exception("Rua");
                return rua;
            }
            set
            {
                rua = value;
                if (string.IsNullOrWhiteSpace(rua))
                    throw new Exception("Rua");
            }
        }

        private int numero_casa = 10;
        [Display(Name = "Numero da casa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public int Numero_casa
        {
            get
            {
                if (numero_casa == 0)
                    throw new Exception("Numero_casa");
                return numero_casa;
            }
            set
            {
                numero_casa = value;
            }
        }

        private long cep = 10;
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public long Cep
        {
            get
            {
                if (cep == 0)
                    throw new Exception("Cep");
                return cep;
            }
            set
            {
                cep = value;
            }
        }

        private string complemento = "complemento";
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Complemento
        {
            get
            {
                if (string.IsNullOrWhiteSpace(complemento))
                    throw new Exception("Complemento");
                return complemento;
            }
            set
            {
                complemento = value;
                if (string.IsNullOrWhiteSpace(complemento))
                    throw new Exception("Complemento");
            }
        }

        public Endereco() : base(){ }
    }
}
