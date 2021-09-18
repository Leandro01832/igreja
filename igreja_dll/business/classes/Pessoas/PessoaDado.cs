using business.classes.Abstrato;
using business.implementacao;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("PessoaDado")]
    public abstract class PessoaDado : Pessoa
    {
        public PessoaDado() : base()
        {
            if (!EntityCrud)
            {
                Endereco = new Endereco();
                Telefone = new Telefone();
            }
            
        }

        protected PessoaDado(int m) : base(m)
        {
            
        }

        #region Properties
        private DateTime data_nascimento;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]        
        public DateTime Data_nascimento
        {
            get
            {
                if (data_nascimento.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                throw new Exception("Data_nascimento");
                return data_nascimento;
            }
            set {data_nascimento = value; }
        }

        private string rg;
        [Display(Name = "RG")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rg
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(rg) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(rg))
                throw new Exception("Rg");
                return rg;
            }
            set { rg = value; }
        }

        private string cpf;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "CPF")]
        [StringLength(11)]
        [Index("CPF", 2, IsUnique = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cpf
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(cpf) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(cpf))
                    throw new Exception("Cpf");
                if(this.Operacao == "insert" && cpf.Length != 11 || 
                    this.Operacao == "update" && cpf.Length != 11)
                {
                    this.ErroCadastro = "Esta campo precisa ter 11 caracteres.";
                    throw new Exception("Cpf");
                }
                return cpf;
            }
            set { cpf = value; }
        }

        private string estado_civil;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_civil
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(estado_civil) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(estado_civil))
                    throw new Exception("Estado_civil");
                return estado_civil;
            }
            set { estado_civil = value; }
        }

        [Display(Name = "Sexo masculino")]
        public bool Sexo_masculino { get; set; }

        [Display(Name = "Sexo feminino")]
        public bool Sexo_feminino { get; set; }

        [ScaffoldColumn(false)]
        public bool Falescimento { get; set; }

        private string status;
        [OpcoesBase(Obrigatorio =true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Status
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(status) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(status))
                    throw new Exception("Status");
                return status;
            }
            set { status = value; }
        }

        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [JsonIgnore]
        public virtual Telefone Telefone { get; set; }
        
        #endregion
    }
}
