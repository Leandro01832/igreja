using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace business.classes
{
    public class Reuniao : modelocrud
    {
        #region Properties
        private DateTime data_reuniao;
        [OpcoesBase(Obrigatorio =true)]
        [Display(Name = "Data da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_reuniao
        {
            get
            {
                if (data_reuniao.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_reuniao");
                return data_reuniao;
            }
            set { data_reuniao = value; }
        }

        private TimeSpan? horario_inicio;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_inicio
        {
            get
            {
                if (this.Operacao == "insert" && horario_inicio.Value.Hours == 0 &&
                    horario_inicio.Value.Minutes == 0 && horario_inicio.Value.Seconds == 0 ||
                    this.Operacao == "update" && horario_inicio.Value.Hours == 0 &&
                    horario_inicio.Value.Minutes == 0 && horario_inicio.Value.Seconds == 0)
                    throw new Exception("Horario_inicio");
                return horario_inicio;
            }
            set { horario_inicio = value; }
        }

        private TimeSpan? horario_fim;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Horário de termino")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_fim
        {
            get
            {
                if (this.Operacao == "insert" && horario_fim.Value.Hours == 0 &&
                    horario_fim.Value.Minutes == 0 && horario_fim.Value.Seconds == 0 ||
                    this.Operacao == "update" && horario_fim.Value.Hours == 0 &&
                    horario_fim.Value.Minutes == 0 && horario_fim.Value.Seconds == 0)
                    throw new Exception("Horario_fim");
                return horario_fim;
            }
            set { horario_fim = value; }
        }

        private string local_reuniao;
        [OpcoesBase(Obrigatorio = true)]
        [Display(Name = "Local da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Local_reuniao
        {
            get
            {
                if (this.Operacao == "insert" && string.IsNullOrWhiteSpace(local_reuniao) ||
                    this.Operacao == "update" && string.IsNullOrWhiteSpace(local_reuniao))
                    throw new Exception("Local_reuniao");
                return local_reuniao;
            }
            set { local_reuniao = value; }
        }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }
        
        public static int UltimoRegistro;
        
        public static List<Reuniao> Reunioes;
        #endregion        

        public Reuniao() : base(){ }

        public Reuniao(int id) : base(id){  }

        public override string ToString()
        {
            return this.Id.ToString() + " - Data da reunião: " + this.Data_reuniao.ToString();
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
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Reuniao", con);
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
    }
}
