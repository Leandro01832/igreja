using business.classes.Intermediario;
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
                Ministerios = new List<PessoaMinisterio>();
                Reuniao = new List<ReuniaoPessoa>();
            }

        }

        #region Properties
        public HttpPostedFileBase FiguraFile;     

        [Display(Name ="Nome completo")]
        public string NomePessoa { get; set; }
        
        [OpcoesBase(ChavePrimaria =false, Index =true, Obrigatorio =true)]
        [Index("CODIGO", 2, IsUnique = true)]
        public int Codigo { get; set; }
        
        public static int UltimoRegistro;
        
        public string password;

        private string email = "email";
        [OpcoesBase(Obrigatorio =true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [Index("EMAIL", 2, IsUnique = true)]
        [MaxLength(80, ErrorMessage ="No maximo 80 caracteres!!!")]
        [ScaffoldColumn(false)]
        public string Email
        {
            get
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("Email");
                return email;
            }
            set
            {
                email = value;
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("Email");
            }
        }

        public int Falta { get; set; }        
        [OpcoesBase(ChaveEstrangeira =true, ChavePrimaria =false, Index =false, Obrigatorio =false  )]
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
        [JsonIgnore]
        public virtual List<EmailIgreja> EmailIgreja { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        [NotMapped]
        public byte[] ImgArrayBytes;

        [JsonIgnore]
        private MudancaEstado MudancaEstado;
        #endregion

        public async static void recuperarTodos()
        {
            List<Type> list = listTypesSon(typeof(Pessoa));
            foreach(var item in list)
            {
                var modelo = (modelocrud) Activator.CreateInstance(item);
                await Task.Run(() => modelo.recuperar());
            }
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


                
    }
}
