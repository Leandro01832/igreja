using business.classes;
using database.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using business.classes.Ministerio;
using database;
using business.classes.Intermediario;
using Newtonsoft.Json;

namespace business.classes.Abstrato
{
    [Table("Ministerio")]
    public abstract class Ministerio : modelocrud, IAddNalista
    {
        #region Properties
        [Key]
        public int IdMinisterio { get; set; }

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

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        
        public static List<Ministerio> listaMinisterios = new List<Ministerio>();
        public static List<Lider_Celula> lideresCelula { get; set; }
        public static List<Lider_Celula_Treinamento> LideresCelulaTreinamento { get; set; }
        public static List<Lider_Ministerio> lideresMinisterio { get; set; }
        public static List<Lider_Ministerio_Treinamento> lideresMinisterioTreinamento { get; set; }
        public static List<Supervisor_Celula> supervisoresCelula { get; set; }
        public static List<Supervisor_Celula_Treinamento> supervisoresCelulaTreinamento { get; set; }
        public static List<Supervisor_Ministerio> supervisoresMinisterio { get; set; }
        public static List<Supervisor_Ministerio_Treinamento> supervisoresMinisterioTreinamento { get; set; }
        #endregion

        AddNalista AddNalista;
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
        }

        #region Methods
        public override string alterar(int id)
        {
            string ministro = "";
            if (this.Ministro_ == null) ministro = "null";
            else ministro = this.Ministro_.ToString();

            Update_padrao = $" update Ministerio set Nome='{Nome}', " +
            $" Proposito='{Proposito}', Ministro_={ministro} " +
            $"  where IdMinisterio='{id}' ";

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Ministerio where IdMinisterio='{id}' ";

            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Ministerio as M  ";
            if (id != null) Select_padrao += $" where M.IdMinisterio='{id}'";

            
            var conexao = bd.obterconexao();

            if (id != null)
            {
                SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return false;
                }
                    dr.Read();
                    this.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Proposito = Convert.ToString(dr["Proposito"]);
                    this.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
                    dr.Close();

                bd.fecharconexao(conexao);
                this.Pessoas = new List<PessoaMinisterio>();
                    var listaPessoas = buscarPessoas(id);
                    if (listaPessoas != null)
                        foreach (var item in listaPessoas)
                            this.Pessoas.Add((PessoaMinisterio)item);

                    this.Celulas = new List<MinisterioCelula>();
                    var listaCelulas = buscarCelulas(id);
                    if (listaCelulas != null)
                        foreach (var item in listaCelulas)
                            this.Celulas.Add((MinisterioCelula)item);
                    
                return true;
            }
            return false;
        }

        public override string salvar()
        {
            string ministro = "";
            if (this.Ministro_ == null) ministro = "null";
            else ministro = this.Ministro_.ToString();

            Insert_padrao = "insert into Ministerio (Nome, Proposito, Maximo_pessoa, Ministro_)" +
                $" values ('{Nome}', '{Proposito}', '{Maximo_pessoa}', {ministro}) ";


            return Insert_padrao;
        }

        #endregion

        public static List<modelocrud> recuperarTodosMinisterios()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                if (lideresCelula == null && new Lider_Celula().recuperar(null))
                { lista.AddRange(lideresCelula); listaMinisterios.AddRange(lideresCelula); }
                
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (LideresCelulaTreinamento == null && new Lider_Celula_Treinamento().recuperar(null))
                { task.Result.AddRange(LideresCelulaTreinamento); listaMinisterios.AddRange(LideresCelulaTreinamento); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (lideresMinisterio == null && new Lider_Ministerio().recuperar(null))
                { task.Result.AddRange(lideresMinisterio); listaMinisterios.AddRange(lideresMinisterio); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (lideresMinisterioTreinamento == null && new Lider_Ministerio_Treinamento().recuperar(null))
                { task.Result.AddRange(lideresMinisterioTreinamento); listaMinisterios.AddRange(lideresMinisterioTreinamento); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (supervisoresCelula == null && new Supervisor_Celula().recuperar(null))
                { task.Result.AddRange(supervisoresCelula); listaMinisterios.AddRange(supervisoresCelula); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                if (supervisoresCelulaTreinamento == null && new Supervisor_Celula_Treinamento().recuperar(null))
                { task.Result.AddRange(supervisoresCelulaTreinamento); listaMinisterios.AddRange(supervisoresCelulaTreinamento); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t7 = t6.ContinueWith((task) =>
            {

                if (supervisoresMinisterio == null && new Supervisor_Ministerio().recuperar(null))
                { task.Result.AddRange(supervisoresMinisterio); listaMinisterios.AddRange(supervisoresMinisterio); }
                
                return task.Result;
            });

            Task<List<modelocrud>> t8 = t7.ContinueWith((task) =>
            {
                if (supervisoresMinisterioTreinamento == null && new Supervisor_Ministerio_Treinamento().recuperar(null))
                { task.Result.AddRange(supervisoresMinisterioTreinamento); listaMinisterios.AddRange(supervisoresMinisterioTreinamento); }
                
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6, t7, t8);

            return t8.Result;
        }        

        private List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join PessoaMinisterio as PEMI on P.IdPessoa=PEMI.PessoaId"
                + " inner join Ministerio as M on PEMI.MinisterioId=M.IdMinisterio"
                + $" where PEMI.MinisterioId='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            List<PessoaMinisterio> lista = new List<PessoaMinisterio>();
            var conexao = bd.obterconexao();
                        
            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return modelos;
            }
            
            while (dr.Read())
            {
                var m = new PessoaMinisterio { IdPessoaMinisterio = int.Parse(Convert.ToString(dr["IdPessoaMinisterio"])) };                
                lista.Add(m);
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach (var item in lista)
            {
                var model = new PessoaMinisterio();
                if(model.recuperar(item.IdPessoaMinisterio))
                modelos.Add(model);
            }
                

            return modelos;
        }

        private List<modelocrud> buscarCelulas(int? id)
        {
            Select_padrao = "select * from Celula as C "
                + " inner join MinisterioCelula as MICE on C.IdCelula=MICE.CelulaId"
                + " inner join Ministerio as M on MICE.MinisterioId=M.IdMinisterio"
                + $" where MICE.MinisterioId='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            List<MinisterioCelula> lista = new List<MinisterioCelula>();
            var conexao = bd.obterconexao();
            
            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return modelos;
            }            

            while (dr.Read())
            {
                var m = new MinisterioCelula { IdMinisterioCelula = int.Parse(Convert.ToString(dr["CelulaId"])) };
                lista.Add(m);
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach (var item in lista)
            {
                var model = new MinisterioCelula();
                if (model.recuperar(item.IdMinisterioCelula))
                    modelos.Add(model);
            }

            return modelos;
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
    }
}
