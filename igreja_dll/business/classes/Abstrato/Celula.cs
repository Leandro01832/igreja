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
    public abstract class Celula : modelocrud
    {
        #region properties        
        private string nome;
        [Display(Name = "Nome da celula")]
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

        private string dia_semana;
        [Display(Name = "Dia da semana")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Dia_semana
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(dia_semana) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(dia_semana))
                    throw new Exception("Dia_semana");
                return dia_semana;
            }
            set { dia_semana = value; }
        }

        private TimeSpan? horario;
        [Display(Name = "Horário")]
        [OpcoesBase(Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario
        {
            get
            {
                if (this.Operacao == "insert" && horario == null ||
                    this.Operacao == "update" && horario == null)
                    throw new Exception("Horario");
                return horario;
            }
            set { horario = value; }
        }

        [JsonIgnore]
        public virtual List<Pessoa> Pessoas { get; set; }

        [Display(Name = "Máximo de pessoas")]
        public int Maximo_pessoa { get; set; }

        private List<MinisterioCelula> ministerios;
        [JsonIgnore]
        public virtual List<MinisterioCelula> Ministerios
        {
            get
            {
                if (this.Operacao == "insert" && ministerios.Count <= 1 ||
                    this.Operacao == "update" && ministerios.Count <= 1)
                {
                    ErroCadastro = "Celula precisa de pelo menos um líder de celula e um líder de celula em treinamento." +
                    " Verifique a lista de ministérios";
                    throw new Exception("Ministerios");
                }
                else
                if (this.Operacao == "insert" ||
                    this.Operacao == "update")
                {
                    bool condicao1 = false;
                    bool condicao2 = false;
                    foreach (var item in ministerios)
                    {
                        var model1 = new Lider_Celula(); var p1 = model1.recuperar(item.MinisterioId);
                        var model2 = new Lider_Celula_Treinamento(); var p2 = model2.recuperar(item.MinisterioId);

                        if (p1) condicao1 = true;
                        if (p2) condicao2 = true;
                        if (condicao1 && condicao2)
                        {
                            ErroCadastro = "";
                            break;
                        }
                    }
                    if (!condicao1 || !condicao2)
                    {
                        ErroCadastro = "Celula precisa de pelo menos um líder de celula e um líder de celula em treinamento." +
                        " Verifique a lista de ministérios";
                        throw new Exception("Ministerios");
                    }
                }

                return ministerios;
            }
            set
            { ministerios = value; }
        }
        [JsonIgnore]
        public virtual EnderecoCelula EnderecoCelula { get; set; }

        public static int UltimoRegistro;
        #endregion

        public Celula() : base()
        {
            if (!EntityCrud)
            {
                this.Maximo_pessoa = 50;
                EnderecoCelula = new EnderecoCelula();
                Ministerios = new List<MinisterioCelula>();
                Pessoas = new List<Pessoa>();
            }

        }


        public async static void recuperarTodasCelulas()
        {
            List<Type> list = listTypes(typeof(Celula));
            foreach (var item in list)
            {
                var modelo = (modelocrud)Activator.CreateInstance(item);
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
