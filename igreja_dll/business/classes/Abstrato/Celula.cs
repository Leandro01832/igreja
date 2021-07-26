using business.classes.Celula;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace business.classes.Abstrato
{
    [Table("Celula")]
    public abstract  class Celula : modelocrud, IAddNalista, IBuscaLista
    {
        #region properties        
        [Display(Name = "Nome da celula")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Dia da semana")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Dia_semana { get; set; }

        [Display(Name = "Horário")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario { get; set; }
        [JsonIgnore]
        public virtual List<Pessoa> Pessoas { get; set; }

        [Display(Name = "Máximo de pessoas")]
        public int Maximo_pessoa { get; set; }
        [JsonIgnore]
        public virtual List<MinisterioCelula> Ministerios { get; set; }
        [JsonIgnore]
        public virtual EnderecoCelula EnderecoCelula { get; set; }

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        public static List<Celula_Adolescente> celulasAdolescente { get; set; }
        public static List<Celula_Jovem> celulasJovem { get; set; }
        public static List<Celula_Adulto> celulasAdulto { get; set; }
        public static List<Celula_Crianca> celulasCrianca { get; set; }
        public static List<Celula_Casado> celulasCasado { get; set; }
        #endregion

        AddNalista AddNalista;
        BuscaLista BuscaLista;

        public Celula() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
            BuscaLista = new BuscaLista();
        }

        protected Celula(int m) : base(m) { }

        #region Methods
        public override string alterar(int id)
        {
            UpdateProperties(T, id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            T = T.BaseType; 
            var delete =
            new EnderecoCelula(id).excluir(id)
            + Delete_padrao.Replace(GetType().Name, T.Name);
            return delete;
        }

        public override bool recuperar(int id)
        {
            this.EnderecoCelula = new EnderecoCelula(id);
            this.EnderecoCelula.recuperar(id);

            this.Ministerios = new List<MinisterioCelula>();
            var listaMinisterios = recuperarMinisterios(id);
            if (listaMinisterios != null)
                foreach (var item in listaMinisterios)
                    this.Ministerios.Add((MinisterioCelula)item);

            this.Pessoas = new List<Pessoa>();
            var listaPessoas = buscarPessoas(id);
            if (listaPessoas != null)
                foreach (var item in listaPessoas)
                    this.Pessoas.Add((Pessoa)item);

            if (SetProperties(T))
                return true;
            return false;
        }

        public override string salvar()
        {
            GetProperties(T);
            Insert_padrao += this.EnderecoCelula.salvar();
            return Insert_padrao;
        }
        #endregion

        public static List<modelocrud> recuperarTodasCelulas()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                if (celulasAdolescente == null && new Celula_Adolescente().recuperar())
                { lista.AddRange(celulasAdolescente); Modelos.AddRange(celulasAdolescente); }

                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (celulasAdulto == null && new Celula_Adulto().recuperar())
                { task.Result.AddRange(celulasAdulto); Modelos.AddRange(celulasAdulto); }

                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (celulasCasado == null && new Celula_Casado().recuperar())
                { task.Result.AddRange(celulasCasado); Modelos.AddRange(celulasCasado); }

                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (celulasCrianca == null && new Celula_Crianca().recuperar())
                { task.Result.AddRange(celulasCasado); Modelos.AddRange(celulasCrianca); }

                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (celulasJovem == null && new Celula_Jovem().recuperar())
                { task.Result.AddRange(celulasJovem); Modelos.AddRange(celulasJovem); }

                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5);

            return t5.Result;
        }

        private List<modelocrud> recuperarMinisterios(int id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<MinisterioCelula>().ToList().Count != MinisterioCelula.GeTotalRegistrosMinisterioCelula()) { }
                lista = Modelos.OfType<MinisterioCelula>().Where(m => m.CelulaId == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
        }

        private List<modelocrud> buscarPessoas(int id)
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

        public List<int> buscarLista(modelocrud TipoDaLista, modelocrud Ligacao, string nomeDaChave, int id)
        {
           return  BuscaLista.buscarLista(TipoDaLista, Ligacao, nomeDaChave, id);
        }

        public static int GeTotalRegistrosCelulas()
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
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Celula", con);
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
            return base.Id.ToString() + " - " + this.Nome;
        }
    }
}
