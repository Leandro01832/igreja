using business.classes.Intermediario;
using business.classes.Ministerio;
using business.contrato;
using business.implementacao;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
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

        private string nome;
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(nome) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(nome))
                    throw new Exception("Nome");
                return nome;
            }
            set { nome = value; }
        }

        private string proposito;
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(proposito) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(proposito))
                    throw new Exception("Proposito");
                return proposito;
            }
            set { proposito = value; }
        }

        private List<PessoaMinisterio> pessoas;
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Pessoas
        {
            get
            {
                try
                {
                    if (this.Operacao == "insert" && pessoas.Count > Maximo_pessoa ||
                        this.Operacao == "update" && pessoas.Count > Maximo_pessoa)
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
                if (this.Operacao == "insert" && maximo_pessoa == 0 ||
                    this.Operacao == "update" && maximo_pessoa == 0)
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
        

        public async static void recuperarTodosMinisterios()
        {
            List<Type> list = listTypes(typeof(Ministerio));
            foreach(var item in list)
            {
                var modelo = (modelocrud) Activator.CreateInstance(item);
                await Task.Run(() => modelo.recuperar());
            }            
        }
        
        public static int TotalRegistro()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Ministerio", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
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
