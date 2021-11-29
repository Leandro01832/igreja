using business.classes.Intermediario;
using business.contrato;
using business.implementacao;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
namespace business.classes.Abstrato
{
    [Table("Ministerio")]
    public abstract class Ministerio : modelocrud, IMudancaEstado
    {
        #region Properties
        [OpcoesBase(ChavePrimaria = false, Index = true, Obrigatorio = true)]
        [Index("CODIGOMINISTERIO", 2, IsUnique = true)]
        public int CodigoMinisterio { get; set; }

        private string nome = "nome";
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome
        {
            get
            {
                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
                return nome;
            }
            set
            {
                nome = value;
                if (string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
            }
        }

        private string proposito= "proposito";
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito
        {
            get
            {
                if (string.IsNullOrWhiteSpace(proposito))
                    throw new Exception("Proposito");
                return proposito;
            }
            set
            {
                proposito = value;
                if (string.IsNullOrWhiteSpace(proposito))
                    throw new Exception("Proposito");
            }
        }

        private List<PessoaMinisterio> pessoas;
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Pessoas
        {
            get
            {
                try
                {
                    if ( pessoas.Count > Maximo_pessoa )
                    {
                        ErroCadastro = "Pessoas não podem mais participar deste ministério." +
                        " Nº total de pessoas que podem participar deste ministério: " + Maximo_pessoa;
                        throw new Exception("Pessoas");
                    }
                }
                catch { }

                return pessoas;
            }
            set
            { pessoas = value; }
        }

        public int? Ministro_ { get; set; }
        [JsonIgnore]
        public virtual List<MinisterioCelula> Celulas { get; set; }

        private int maximo_pessoa;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Maximo de pessoas")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Maximo_pessoa
        {
            get
            {
                if ( maximo_pessoa == 0)
                    throw new Exception("Maximo_pessoa");
                return maximo_pessoa;
            }
            set { maximo_pessoa = value; }
        }

        public static int UltimoRegistro;

        private MudancaEstado mudanca;
        #endregion
        
        public Ministerio() : base()
        {
            
            if (!EntityCrud)
            {
                this.Maximo_pessoa = 50;
                mudanca = new MudancaEstado();
                Pessoas = new List<PessoaMinisterio>();
                Celulas = new List<MinisterioCelula>();
            }
        }
        
        
        public override string ToString()
        {
            return this.Id.ToString() + " - " + this.Nome;
        }

        public void MudarEstado(int id, modelocrud m)
        {
            mudanca.MudarEstado(id, m);
        }
    }
}
