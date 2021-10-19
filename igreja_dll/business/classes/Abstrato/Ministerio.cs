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

        public static List<Lider_Celula> lideresCelula;
        public static List<Lider_Celula_Treinamento> LideresCelulaTreinamento;
        public static List<Lider_Ministerio> lideresMinisterio;
        public static List<Lider_Ministerio_Treinamento> lideresMinisterioTreinamento;
        public static List<Supervisor_Celula> supervisoresCelula;
        public static List<Supervisor_Celula_Treinamento> supervisoresCelulaTreinamento;
        public static List<Supervisor_Ministerio> supervisoresMinisterio;
        public static List<Supervisor_Ministerio_Treinamento> supervisoresMinisterioTreinamento;

        private MudancaEstado mudanca;
        #endregion
        
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
            mudanca = new MudancaEstado();
        }

        protected Ministerio(int m) : base(m){ mudanca = new MudancaEstado(); }

        public static List<modelocrud> recuperarTodosMinisterios()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                if (lideresCelula == null && new Lider_Celula().recuperar())
                { lista.AddRange(lideresCelula); Modelos.AddRange(lideresCelula); }

                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (LideresCelulaTreinamento == null && new Lider_Celula_Treinamento().recuperar())
                { task.Result.AddRange(LideresCelulaTreinamento); Modelos.AddRange(LideresCelulaTreinamento); }

                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (lideresMinisterio == null && new Lider_Ministerio().recuperar())
                { task.Result.AddRange(lideresMinisterio); Modelos.AddRange(lideresMinisterio); }

                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (lideresMinisterioTreinamento == null && new Lider_Ministerio_Treinamento().recuperar())
                { task.Result.AddRange(lideresMinisterioTreinamento); Modelos.AddRange(lideresMinisterioTreinamento); }

                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (supervisoresCelula == null && new Supervisor_Celula().recuperar())
                { task.Result.AddRange(supervisoresCelula); Modelos.AddRange(supervisoresCelula); }

                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                if (supervisoresCelulaTreinamento == null && new Supervisor_Celula_Treinamento().recuperar())
                { task.Result.AddRange(supervisoresCelulaTreinamento); Modelos.AddRange(supervisoresCelulaTreinamento); }

                return task.Result;
            });

            Task<List<modelocrud>> t7 = t6.ContinueWith((task) =>
            {

                if (supervisoresMinisterio == null && new Supervisor_Ministerio().recuperar())
                { task.Result.AddRange(supervisoresMinisterio); Modelos.AddRange(supervisoresMinisterio); }

                return task.Result;
            });

            Task<List<modelocrud>> t8 = t7.ContinueWith((task) =>
            {
                if (supervisoresMinisterioTreinamento == null && new Supervisor_Ministerio_Treinamento().recuperar())
                { task.Result.AddRange(supervisoresMinisterioTreinamento); Modelos.AddRange(supervisoresMinisterioTreinamento); }

                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6, t7, t8);

            return t8.Result;
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
