using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Ministerio;
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
        
        private List<MinisterioCelula> ministerios;
        [JsonIgnore]
        public virtual List<MinisterioCelula> Ministerios
        {
            get { return ministerios; }
            set
            {
                if (value.Count <= 1)
                    ErroNalista = @"Celula precisa de pelo menos um líder de celula e um líder de celula em treinamento.
                                    Verifique a lista de ministérios";
                else
                {
                    bool condicao1 = false;
                    bool condicao2 = false;
                    foreach(var item in value)
                    {
                        var model1 = new Lider_Celula            (item.MinisterioId); var p1 = model1.recuperar(item.MinisterioId);
                        var model2 = new Lider_Celula_Treinamento(item.MinisterioId); var p2 = model2.recuperar(item.MinisterioId);

                        if (p1) condicao1 = true;
                        if (p2) condicao2 = true;
                        if(condicao1 && condicao2)
                        {
                            ErroNalista = "";
                            break;
                        }
                    }

                }
                ministerios = value;
            }
        }
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
            EnderecoCelula = new EnderecoCelula();
            ErroNalista = @"Celula precisa de pelo menos um lider de celula e um lider de celula em treinamento.
                            Verifique a lista de ministérios da celula";
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
