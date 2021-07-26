using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.Pessoas
{
    [Table("PessoaDado")]
    public abstract class PessoaDado : Pessoa
    {
        public PessoaDado() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
        }

        protected PessoaDado(int m) : base(m)
        {
        }
        
        #region Properties

        AddNalista AddNalista;


        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_nascimento { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rg { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11)]
        [Index("CPF", 2, IsUnique = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cpf { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_civil { get; set; }

        [Display(Name = "Sexo masculino")]
        public bool Sexo_masculino { get; set; }

        [Display(Name = "Sexo feminino")]
        public bool Sexo_feminino { get; set; }

        [ScaffoldColumn(false)]
        public bool Falescimento { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Status { get; set; }

        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [JsonIgnore]
        public virtual Telefone Telefone { get; set; }

        private MudancaEstado MudancaEstado;

        #endregion

        public override string salvar()
        {
            base.salvar();
            GetProperties(T);
            Insert_padrao += this.Endereco.salvar();
            Insert_padrao += this.Telefone.salvar();
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            base.alterar(id);
            UpdateProperties(T, id);
            Update_padrao += this.Endereco.alterar(id);
            Update_padrao += this.Telefone.alterar(id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            T = T.BaseType;
            var delete = 
                 new Endereco(id).excluir(id)
                + new Telefone(id).excluir(id)
                + Delete_padrao.Replace(GetType().Name, T.Name)
                + base.excluir(id);
            return delete;
        }

        public override bool recuperar(int id)
        {
            this.Endereco = new Endereco(id);
            this.Endereco.recuperar(id);
            this.Telefone = new Telefone(id);
            this.Telefone.recuperar(id);

            if (SetProperties(T))
            {
                base.recuperar(id); return true;
            }
            return false;
        }
    }
}
