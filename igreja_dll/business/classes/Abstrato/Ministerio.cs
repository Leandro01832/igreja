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

namespace business.classes.Abstrato
{
    [Table("Ministerio")]
    public abstract class Ministerio : modelocrud, IAddNalista
    {

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito { get; set; }

        public virtual List<Pessoa> Pessoas { get; set;}

        public virtual List<PessoaLgpd> PessoasLgpd { get; set; }

        public int? Ministro_ { get; set; }
        [ForeignKey("Ministro_")]
        public virtual Membro Ministro { get; set; }

        public virtual List<Abstrato.Celula> Celulas { get; set; }

        [Display(Name = "Maximo de pessoas")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Maximo_pessoa { get; set; }

        AddNalista AddNalista;
        public Ministerio() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
        }

        public Ministerio(int? id, bool recuperaLista) : base(id, recuperaLista)
        {
            buscarMinisterio(id);
            this.Pessoas = new List<Pessoa>();

            if(recuperaLista)
            {
                var pessoas = buscarPessoas(id);
                var celulas = buscarCelulas(id);
                if(pessoas != null)
                {
                    
                    foreach (var p in pessoas)
                    {
                        this.Pessoas.Add((Pessoa)p); 
                    }
                }

                if (celulas != null)
                {

                    foreach (var c in celulas)
                    {
                        this.Celulas.Add((Celula)c);
                    }
                }
            }

        }

        public override string alterar(int id)
        {
            string ministro = "";
            if (this.Ministro_ == null) ministro = "null";
            else ministro = this.Ministro_.ToString();

            Update_padrao = $" update Ministerio set Nome='{Nome}', " +
            $" Proposito='{Proposito}', Ministro_={ministro} " +
            $"  where Id='{id}' ";
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Ministerio where Id='{id}' ";
                
            bd.Excluir(null);
            return Delete_padrao;
        }

        public abstract override List<modelocrud> recuperar(int? id);

        public override string salvar()
        {
            string ministro = "";
            if (this.Ministro_ == null) ministro = "null";
            else ministro = this.Ministro_.ToString();

            Insert_padrao = "insert into Ministerio (Nome, Proposito, Maximo_pessoa, Ministro_)" +
                $" values ('{Nome}', '{Proposito}', '{Maximo_pessoa}', {ministro}) ";
            
            bd.SalvarModelo(null);
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
        
        public modelocrud buscarMinisterio(int? id)
        {
            Select_padrao = "select * from Ministerio as M  ";
            if (id != null) Select_padrao += $" where M.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
                try
                {
                    dr.Read();
                    this.Id = int.Parse(dr["Id"].ToString());
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Proposito = Convert.ToString(dr["Proposito"]);
                    this.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
                    dr.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }

                this.Celulas = new List<Celula>();
                var listaCelulas = buscarCelulas(id);

                return this;
            }
            return null;
        }

        public List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join PessoaMinisterio as PEMI on P.Id=PEMI.Pessoa_Id"
                + " inner join Ministerio as M on PEMI.Ministerio_Id=M.Id"
                + $" where PEMI.Ministerio_Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            while (dr.Read())
            {
                var m = Pessoa.recuperarPessoa(int.Parse(Convert.ToString(dr["Pessoa_Id"])));
                
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public List<modelocrud> buscarCelulas(int? id)
        {
            Select_padrao = "select * from Celula as C "
                + " inner join MinisterioCelula as MICE on C.Id=MICE.Celula_Id"
                + " inner join Ministerio as M on MICE.Ministerio_Id=M.Id"
                + $" where MICE.Ministerio_Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            while (dr.Read())
            {
                var m = Celula.recuperarCelula(int.Parse(Convert.ToString(dr["Celula_Id"])));

                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public static modelocrud recuperarMinisterio(int v)
        {
            Task<modelocrud> t = Task.Factory.StartNew(() =>
            {
                var m = new Lider_Celula(v, false).recuperar(v);
                if (m != null) return m[0];
                return null;
            });

            Task<modelocrud> t2 = t.ContinueWith((task) =>
            {
                if(task.Result == null)
                {
                    var m = new Lider_Celula_Treinamento(v, false).recuperar(v);
                    if (m != null) return m[0];
                }                
                return task.Result;
            });

            Task<modelocrud> t3 = t2.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Lider_Ministerio(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task<modelocrud> t4 = t3.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Lider_Ministerio_Treinamento(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task<modelocrud> t5 = t4.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Supervisor_Celula(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task<modelocrud> t6 = t5.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Supervisor_Celula_Treinamento(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task<modelocrud> t7 = t6.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Supervisor_Ministerio(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task<modelocrud> t8 = t7.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var m = new Supervisor_Ministerio_Treinamento(v, false).recuperar(v);
                    if (m != null) return m[0];
                }
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5,t6,t7,t8);

            return t8.Result;
        }

        public void AdicionarNaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros)
        {
            AddNalista.AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }
        
        public void RemoverDaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros, int id)
        {
            AddNalista.RemoverDaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros, id);
        }
    }
}
