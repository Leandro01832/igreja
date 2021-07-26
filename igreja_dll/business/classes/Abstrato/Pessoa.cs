using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace business.classes.Abstrato
{
    [Table("Pessoa")]
    public abstract class Pessoa : modelocrud, IAddNalista, IMudancaEstado
    {
        public Pessoa() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();            
        }

        protected Pessoa(int m) : base(m)
        {
        }


        #region Properties
        AddNalista AddNalista;

        [NotMapped]
        public HttpPostedFileBase FiguraFile { get; set; }

        [NotMapped]
        public static List<Visitante> visitantes { get; set; }
        [NotMapped]
        public static List<VisitanteLgpd> visitantesLgpd { get; set; }
        [NotMapped]
        public static List<Crianca> criancas { get; set; }
        [NotMapped]
        public static List<CriancaLgpd> criancasLgpd { get; set; }
        [NotMapped]
        public static List<Membro_Aclamacao> membros_Aclamacao { get; set; }
        [NotMapped]
        public static List<Membro_AclamacaoLgpd> membros_AclamacaoLgpd { get; set; }
        [NotMapped]
        public static List<Membro_Transferencia> membros_Transferencia { get; set; }
        [NotMapped]
        public static List<Membro_TransferenciaLgpd> membros_TransferenciaLgpd { get; set; }
        [NotMapped]
        public static List<Membro_Reconciliacao> membros_Reconciliacao { get; set; }
        [NotMapped]
        public static List<Membro_ReconciliacaoLgpd> membros_ReconciliacaoLgpd { get; set; }
        [NotMapped]
        public static List<Membro_Batismo> membros_Batismo { get; set; }
        [NotMapped]
        public static List<Membro_BatismoLgpd> membros_BatismoLgpd { get; set; }

        [Display(Name ="Nome completo")]
        public string NomePessoa { get; set; }
        
        [Index("CODIGO", 2, IsUnique = true)]
        public int Codigo { get; set; }

        [NotMapped]
        public static int UltimoRegistro;

        [NotMapped]
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
        public virtual List<Historico> Historico { get; set; }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        [NotMapped]
        public byte[] ImgArrayBytes { get; set; }

        [JsonIgnore]
        private MudancaEstado MudancaEstado;
        #endregion

        #region Methods
        public override string salvar()
        {
            GetProperties(T);
            Insert_padrao += this.Chamada.salvar();
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            UpdateProperties(T, id);
            Update_padrao += this.Chamada.alterar(id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            T = T.BaseType;
            var delete =
              new Chamada(id).excluir(id) +
              Delete_padrao.Replace(GetType().Name, T.Name);
            return delete;
        }

        public override bool recuperar(int id)
        {            
            this.Chamada = new Chamada(id);
            this.Chamada.recuperar(id);

            bd.fecharconexao(conexao);
            this.Ministerios = new List<PessoaMinisterio>();
            var listaMinisterios = recuperarMinisterios(id);
            if (listaMinisterios != null)
                foreach (var item in listaMinisterios)
                {
                    this.Ministerios.Add((PessoaMinisterio)item);
                }
            this.Reuniao = new List<ReuniaoPessoa>();
            var listaReunioes = recuperarReuniao(id);
            if (listaReunioes != null)
                foreach (var item in listaReunioes)
                {
                    this.Reuniao.Add((ReuniaoPessoa)item);
                }

            this.Historico = new List<Historico>();
            var listaHistoricos = recuperarHistorico(id);
            if (listaHistoricos != null)
                foreach (var item in listaHistoricos)
                {
                    this.Historico.Add((Historico)item);
                }
            
            if (SetProperties(T)) return true;
            return false;
        }
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

        private List<modelocrud> recuperarMinisterios(int id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t =  Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<PessoaMinisterio>().ToList().Count != GeTotalRegistrosPessoasEmMinisterios()) { }
                lista = Modelos.OfType<PessoaMinisterio>().Where(m => m.PessoaId == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
        }

        private List<modelocrud> recuperarReuniao(int? id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<ReuniaoPessoa>().ToList().Count != GeTotalRegistrosPessoasEmReunioes()) { }
                lista = Modelos.OfType<ReuniaoPessoa>().Where(m => m.PessoaId == id).Cast<modelocrud>().ToList();
                return lista;
            });
            Task.WaitAll(t);
            return t.Result;
        }

        private List<modelocrud> recuperarHistorico(int? id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<Historico>().ToList().Count != GeTotalRegistrosHistoricos()) { }
                lista = Modelos.OfType<Historico>().Where(m => m.pessoaid == id).Cast<modelocrud>().ToList();
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

        public override string ToString()
        {
            return this.Codigo + " - " + this.NomePessoa;
        }
    }
}
