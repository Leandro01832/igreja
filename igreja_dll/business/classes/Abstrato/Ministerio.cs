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
using System.Threading.Tasks;
namespace business.classes.Abstrato
{
    [Table("Ministerio")]
    public abstract class Ministerio : modelocrud
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
        
        public static int UltimoRegistro;

        public static List<Lider_Celula> lideresCelula;
        public static List<Lider_Celula_Treinamento> LideresCelulaTreinamento;
        public static List<Lider_Ministerio> lideresMinisterio;
        public static List<Lider_Ministerio_Treinamento> lideresMinisterioTreinamento;
        public static List<Supervisor_Celula> supervisoresCelula;
        public static List<Supervisor_Celula_Treinamento> supervisoresCelulaTreinamento;
        public static List<Supervisor_Ministerio> supervisoresMinisterio;
        public static List<Supervisor_Ministerio_Treinamento> supervisoresMinisterioTreinamento;
        #endregion
        
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
        }

        protected Ministerio(int m) : base(m){ }

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
    }
}
