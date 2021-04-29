using business.classes;
using database.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        [Key]
        public int IdMinisterio { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito { get; set; }
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Pessoas { get; set;}

        public int? Ministro_ { get; set; }
        [JsonIgnore]
        public virtual List<MinisterioCelula> Celulas { get; set; }

        [Display(Name = "Maximo de pessoas")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Maximo_pessoa { get; set; }

        AddNalista AddNalista;
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
        }

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

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Ministerio as M  ";
            if (id != null) Select_padrao += $" where M.IdMinisterio='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                try
                {
                    dr.Read();
                    this.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Proposito = Convert.ToString(dr["Proposito"]);
                    this.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
                    dr.Close();

                    this.Pessoas = new List<PessoaMinisterio>();
                    var listaPessoas = buscarPessoas(id);
                    if(listaPessoas != null)
                    foreach (var item in listaPessoas)
                    this.Pessoas.Add((PessoaMinisterio)item);

                    this.Celulas = new List<MinisterioCelula>();
                    var listaCelulas = buscarCelulas(id);
                    if (listaCelulas != null)
                    foreach (var item in listaCelulas)
                    this.Celulas.Add((MinisterioCelula)item);

                    modelos.Add(this);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }
                return modelos;
            }
            return modelos;
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

        public static List<modelocrud> recuperarTodosMinisterios()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                var m = new Lider_Celula().recuperar(null);
                if (m != null)
                lista.AddRange(m);
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                var m = new Lider_Celula_Treinamento().recuperar(null);
                if (m != null)
                task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                var m = new Lider_Ministerio().recuperar(null);
                if (m != null)
                task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                var m = new Lider_Ministerio_Treinamento().recuperar(null);
                if (m != null)
                task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                var m = new Supervisor_Celula().recuperar(null);
                if (m != null)
                task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                var m = new Supervisor_Celula_Treinamento().recuperar(null);
                if (m != null)
                    task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t7 = t6.ContinueWith((task) =>
            {
                var m = new Supervisor_Ministerio().recuperar(null);
                if (m != null)
                    task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t8 = t7.ContinueWith((task) =>
            {
                var m = new Supervisor_Ministerio_Treinamento().recuperar(null);
                if (m != null)
                    task.Result.AddRange(m);
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6, t7, t8);

            return t8.Result;
        }        

        public List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join PessoaMinisterio as PEMI on P.IdPessoa=PEMI.PessoaId"
                + " inner join Ministerio as M on PEMI.MinisterioId=M.IdMinisterio"
                + $" where PEMI.MinisterioId='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            var lista = new PessoaMinisterio().recuperar(null).OfType<PessoaMinisterio>().ToList();

            while (dr.Read())
            {
                var m = lista.First(i => i.PessoaId == int.Parse(Convert.ToString(dr["PessoaId"])));                
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public List<modelocrud> buscarCelulas(int? id)
        {
            Select_padrao = "select * from Celula as C "
                + " inner join MinisterioCelula as MICE on C.IdCelula=MICE.CelulaId"
                + " inner join Ministerio as M on MICE.MinisterioId=M.IdMinisterio"
                + $" where MICE.MinisterioId='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            var lista = new MinisterioCelula().recuperar(null).OfType<MinisterioCelula>().ToList();

            while (dr.Read())
            {
                var m = lista.First(i => i.CelulaId == int.Parse(Convert.ToString(dr["CelulaId"])));
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
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
