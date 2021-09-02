using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace business.classes.Abstrato
{
    [Table("Pessoa")]
    public abstract class Pessoa : modelocrud, IMudancaEstado
    {
        public Pessoa() : base()
        {
            if (!EntityCrud)
            {
                MudancaEstado = new MudancaEstado();
                Chamada = new Chamada();
            }
            
        }

        protected Pessoa(int m) : base(m)
        {
            
        }

        #region Properties
        public HttpPostedFileBase FiguraFile;

        public static List<Visitante> visitantes;

        public static List<VisitanteLgpd> visitantesLgpd;

        public static List<Crianca> criancas;

        public static List<CriancaLgpd> criancasLgpd;

        public static List<Membro_Aclamacao> membros_Aclamacao;

        public static List<Membro_AclamacaoLgpd> membros_AclamacaoLgpd;

        public static List<Membro_Transferencia> membros_Transferencia;

        public static List<Membro_TransferenciaLgpd> membros_TransferenciaLgpd;

        public static List<Membro_Reconciliacao> membros_Reconciliacao;

        public static List<Membro_ReconciliacaoLgpd> membros_ReconciliacaoLgpd;

        public static List<Membro_Batismo> membros_Batismo;

        public static List<Membro_BatismoLgpd> membros_BatismoLgpd;

        [Display(Name ="Nome completo")]
        public string NomePessoa { get; set; }
        
        [Index("CODIGO", 2, IsUnique = true)]
        public int Codigo { get; set; }
        
        public static int UltimoRegistro;
        
        public string password;

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [Index("EMAIL", 2, IsUnique = true)]
        [MaxLength(80, ErrorMessage ="No maximo 80 caracteres!!!")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }
        public int Falta { get; set; }        
        public int? celula_ { get; set; }
        [ForeignKey("celula_")]
        [JsonIgnore]
        public virtual Celula Celula { get; set; }
        [JsonIgnore]
        public virtual Chamada Chamada { get; set; }
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Ministerios { get; set; }
        [JsonIgnore]
        public virtual List<Historico> Historicos { get; set; }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        [NotMapped]
        public byte[] ImgArrayBytes;

        [JsonIgnore]
        private MudancaEstado MudancaEstado;
        #endregion

        public static List<modelocrud> recuperarTodos()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                if (visitantesLgpd == null && new VisitanteLgpd().recuperar())
                { lista.AddRange(visitantesLgpd); Modelos.AddRange(visitantesLgpd); }

                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (criancasLgpd == null && new CriancaLgpd().recuperar())
                { task.Result.AddRange(criancasLgpd); Modelos.AddRange(criancasLgpd); }

                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (membros_AclamacaoLgpd == null && new Membro_AclamacaoLgpd().recuperar())
                { task.Result.AddRange(membros_AclamacaoLgpd); Modelos.AddRange(membros_AclamacaoLgpd); }

                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (membros_ReconciliacaoLgpd == null && new Membro_ReconciliacaoLgpd().recuperar())
                { task.Result.AddRange(membros_ReconciliacaoLgpd); Modelos.AddRange(membros_ReconciliacaoLgpd); }

                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (membros_BatismoLgpd == null && new Membro_BatismoLgpd().recuperar())
                { task.Result.AddRange(membros_BatismoLgpd); Modelos.AddRange(membros_BatismoLgpd); }

                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                if (membros_TransferenciaLgpd == null && new Membro_TransferenciaLgpd().recuperar())
                { task.Result.AddRange(membros_TransferenciaLgpd); Modelos.AddRange(membros_TransferenciaLgpd); }

                return task.Result;
            });

            Task<List<modelocrud>> t7 = t6.ContinueWith((task) =>
            {
                if (visitantes == null && new Visitante().recuperar())
                { task.Result.AddRange(visitantes); Modelos.AddRange(visitantes); }

                return task.Result;
            });

            Task<List<modelocrud>> t8 = t7.ContinueWith((task) =>
            {
                if (criancas == null && new Crianca().recuperar())
                { task.Result.AddRange(criancas); Modelos.AddRange(criancas); }

                return task.Result;
            });

            Task<List<modelocrud>> t9 = t8.ContinueWith((task) =>
            {
                if (membros_Aclamacao == null && new Membro_Aclamacao().recuperar())
                { task.Result.AddRange(membros_Aclamacao); Modelos.AddRange(membros_Aclamacao); }

                return task.Result;
            });

            Task<List<modelocrud>> t10 = t9.ContinueWith((task) =>
            {
                if (membros_Reconciliacao == null && new Membro_Reconciliacao().recuperar())
                { task.Result.AddRange(membros_Reconciliacao); Modelos.AddRange(membros_Reconciliacao); }

                return task.Result;
            });

            Task<List<modelocrud>> t11 = t10.ContinueWith((task) =>
            {
                if (membros_Batismo == null && new Membro_Batismo().recuperar())
                { task.Result.AddRange(membros_Batismo); Modelos.AddRange(membros_Batismo); }

                return task.Result;
            });

            Task<List<modelocrud>> t12 = t11.ContinueWith((task) =>
            {
                if (membros_Transferencia == null && new Membro_Transferencia().recuperar())
                { task.Result.AddRange(membros_Transferencia); Modelos.AddRange(membros_Transferencia); }

                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);

            return t12.Result;
        }

        public void MudarEstado(int id, modelocrud m)
        {
            MudancaEstado.MudarEstado(id, m);
        }

        public async Task<bool> EnviarFoto(PhotoRequest photoRequest)
        {
            var request = JsonConvert.SerializeObject(photoRequest);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var urlSetfoto = "SetFoto";
            var response = await client.PostAsync("http://www.igrejadeusbom.somee.com/" + urlSetfoto, body);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
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
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Pessoa", con);
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
            return this.Codigo + " - " + this.NomePessoa;
        }
    }
}
