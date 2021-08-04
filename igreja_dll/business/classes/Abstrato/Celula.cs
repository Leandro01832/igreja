using business.classes.Celulas;
using business.classes.Intermediario;
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
    public abstract  class Celula : modelocrud
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
        
        public static int UltimoRegistro;

        public static List<Celula_Adolescente> celulasAdolescente;
        public static List<Celula_Jovem> celulasJovem;
        public static List<Celula_Adulto> celulasAdulto;
        public static List<Celula_Crianca> celulasCrianca;
        public static List<Celula_Casado> celulasCasado;
        #endregion
        

        public Celula() : base()
        {
            this.Maximo_pessoa = 50;
        }

        protected Celula(int m) : base(m) { }
        
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
                while (Modelos.OfType<MinisterioCelula>().ToList().Count != MinisterioCelula.TotalRegistro()) { }
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
                while (Modelos.OfType<Pessoa>().ToList().Count != Pessoa.TotalRegistro()) { }
                lista = Modelos.OfType<Pessoa>().Where(m => m.celula_ == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
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
