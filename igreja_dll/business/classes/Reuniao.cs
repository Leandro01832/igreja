using business.classes.Abstrato;
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
using System.Linq;
using System.Threading.Tasks;

namespace business.classes
{
    public class Reuniao : modelocrud, IAddNalista
    {
        #region Properties

        [Display(Name = "Data da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_reuniao { get; set; }

        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_inicio { get; set; }

        [Display(Name = "Horário de termino")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_fim { get; set; }

        [Display(Name = "Local da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Local_reuniao { get; set; }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        [NotMapped]
        public static List<Reuniao> Reunioes = new List<Reuniao>();
        #endregion

        AddNalista AddNalista;

        public Reuniao() : base()
        {
            AddNalista = new AddNalista();
        }

        public Reuniao(int id) : base(id)
        {
        }

        public override string alterar(int id)
        {
            UpdateProperties(null, id);
            Update_padrao += BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(GetType()))
            { T = GetType(); return true; }
            return false;
        }        

        public override string salvar()
        {
            GetProperties(null);
            Insert_padrao += BDcomum.addNaLista;
            bd.SalvarModelo(this);
            return Insert_padrao;
        }

        private List<modelocrud> recuperarPessoas(int? id)
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                while (Modelos.OfType<ReuniaoPessoa>().ToList().Count != Pessoa.GeTotalRegistrosPessoas()) { }
                lista = Modelos.OfType<ReuniaoPessoa>().Where(m => m.ReuniaoId == id).Cast<modelocrud>().ToList();
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

        public override string ToString()
        {
            return this.Id.ToString() + " - Data da reunião: " + this.Data_reuniao.ToString();
        }

        public static int GeTotalRegistrosReunioes()
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
