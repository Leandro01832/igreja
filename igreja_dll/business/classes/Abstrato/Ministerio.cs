using business.classes;
using database.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using business.classes.Ministerio;
using database;
using business.classes.Intermediario;
using Newtonsoft.Json;
using business.contrato;
using business.implementacao;

namespace business.classes.Abstrato
{
    [Table("Ministerio")]
    public abstract class Ministerio : modelocrud, IAddNalista
    {
        #region Properties
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito { get; set; }
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Pessoas { get; set; }

        public int? Ministro_ { get; set; }
        [JsonIgnore]
        public virtual List<MinisterioCelula> Celulas { get; set; }

        [Display(Name = "Maximo de pessoas")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Maximo_pessoa { get; set; }

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        public static List<Lider_Celula> lideresCelula { get; set; }
        public static List<Lider_Celula_Treinamento> LideresCelulaTreinamento { get; set; }
        public static List<Lider_Ministerio> lideresMinisterio { get; set; }
        public static List<Lider_Ministerio_Treinamento> lideresMinisterioTreinamento { get; set; }
        public static List<Supervisor_Celula> supervisoresCelula { get; set; }
        public static List<Supervisor_Celula_Treinamento> supervisoresCelulaTreinamento { get; set; }
        public static List<Supervisor_Ministerio> supervisoresMinisterio { get; set; }
        public static List<Supervisor_Ministerio_Treinamento> supervisoresMinisterioTreinamento { get; set; }
        #endregion

        AddNalista AddNalista;
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
        }

        protected Ministerio(int m) : base(m)
        {
        }

        #region Methods
        public override string alterar(int id)
        {
            UpdateProperties(T, id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            T = T.BaseType;
            var delete = Delete_padrao.Replace(GetType().Name, T.Name);
            return delete;
        }

        public override bool recuperar(int id)
        {
            bd.fecharconexao(conexao);
            this.Pessoas = new List<PessoaMinisterio>();
            var listaPessoas = buscarPessoas(id);
            if (listaPessoas != null)
                foreach (var item in listaPessoas)
                    this.Pessoas.Add((PessoaMinisterio)item);

            this.Celulas = new List<MinisterioCelula>();
            var listaCelulas = buscarCelulas(id);
            if (listaCelulas != null)
                foreach (var item in listaCelulas)
                    this.Celulas.Add((MinisterioCelula)item);

            if (SetProperties(T))
                return true;
            return false;
        }

        public override string salvar()
        {
            GetProperties(T);
            return Insert_padrao;
        }

        #endregion

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

        private List<modelocrud> buscarPessoas(int? id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<Pessoa>().ToList().Count != Pessoa.GeTotalRegistrosPessoas()) { }
                lista = Modelos.OfType<Pessoa>().Where(m => m.celula_ == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
        }

        private List<modelocrud> buscarCelulas(int? id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<MinisterioCelula>().ToList().Count != MinisterioCelula.GeTotalRegistrosMinisterioCelula()) { }
                lista = Modelos.OfType<MinisterioCelula>().Where(m => m.MinisterioId == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
        }
        
        public void AdicionarNaLista(string NomeTabela, modelocrud modeloQRecebe,
            modelocrud modeloQPreenche, string numeros)
        {
            AddNalista.AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }
        
        public void RemoverDaLista(string NomeTabela, modelocrud modeloQRecebe,
            modelocrud modeloQPreenche, string numeros)
        {
            AddNalista.RemoverDaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }

        public static int GeTotalRegistrosMinisterios()
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
    }
}
