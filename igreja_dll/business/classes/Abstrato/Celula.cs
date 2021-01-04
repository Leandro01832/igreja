
using business.classes.Abstrato;
using business.classes.Celula;
using business.classes.Celulas;
using business.classes.Ministerio;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes.Abstrato
{
    [Table("Celula")]
    public abstract  class Celula : modelocrud, IAddNalista, IBuscaLista
    {

        [Display(Name = "Nome da celula")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Dia da semana")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Dia_semana { get; set; }

        [Display(Name = "Horário")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? Horario { get; set; }        

        public virtual List<Pessoa> Pessoas { get; set; }

        [Display(Name = "Máximo de pessoas")]
        public int Maximo_pessoa { get; set; }

        public virtual List<Abstrato.Ministerio> Ministerios { get; set; }

        public virtual EnderecoCelula EnderecoCelula { get; set; }

        AddNalista AddNalista;
        BuscaLista BuscaLista;
        public Celula() : base()
        {
            this.Maximo_pessoa = 50;
            EnderecoCelula = new EnderecoCelula();
            AddNalista = new AddNalista();
            BuscaLista = new BuscaLista();
        }

        public Celula(int? id, bool recuperaLista) : base(id, recuperaLista)
        {
            buscarCelula(id);
            this.Pessoas = new List<Pessoa>();
            this.Ministerios = new List<Ministerio>();
            BuscaLista = new BuscaLista();

            if(recuperaLista)
            {
                var ministerios = recuperarMinisterios(id);
                if (ministerios != null)
                {
                    foreach (var m in ministerios)
                    {
                        this.Ministerios.Add((Ministerio)m);
                    }
                }

                var pessoas = buscarPessoas(id);
                if (pessoas != null)
                {
                    foreach (var p in pessoas)
                    {
                        this.Pessoas.Add((Pessoa)p);
                    }
                }
            }
           
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Celula set Nome='{Nome}', Dia_semana='{Dia_semana}', " +
            $"Horario='{Horario.ToString()}', Maximo_pessoa='{Maximo_pessoa}' " +
            $"  where Id='{id}' " + this.EnderecoCelula.alterar(id);
            
            bd.Editar(null);
            return Update_padrao;
        }        

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Celula where Id='{id}'"
                + " delete EnderecoCelula from EnderecoCelula "
                + " as E inner join Celula as C on E.Id=C.Id"
                + $" where C.Id='{id}'";
            
            bd.Excluir(null);
            return Delete_padrao;
        }

        public abstract override List<modelocrud> recuperar(int? id);

        public override string salvar()
        {
            Insert_padrao = "insert into Celula (Nome, Dia_semana, Horario, Maximo_pessoa) " +
                $" values  ('{Nome}', '{Dia_semana}', '{Horario}', '{Maximo_pessoa}') " + this.EnderecoCelula.salvar() + " ";
            
            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public static List<modelocrud> recuperarTodasCelulas()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
               var c = new Celula_Adolescente().recuperar(null);
                if (c != null)
                lista.AddRange(c);
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                var c = new Celula_Adulto().recuperar(null);
                if (c != null)
                task.Result.AddRange(c);
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                var c = new Celula_Casado().recuperar(null);
                if (c != null)
                    task.Result.AddRange(c);
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                var c = new Celula_Crianca().recuperar(null);
                if (c != null)
                    task.Result.AddRange(c);
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                var c = new Celula_Jovem().recuperar(null);
                if (c != null)
                    task.Result.AddRange(c);
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5);

            return t5.Result;
        }
        
        public void buscarCelula(int? id)

        {
            Select_padrao = "select * from Celula as C "
            + " inner join EnderecoCelula as E on E.Id=C.Id ";
            if (id != null) Select_padrao += $" where C.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
            }

            if (id != null)
            {
                try
                {
                    dr.Read();
                    this.Id = int.Parse(dr["Id"].ToString());
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Dia_semana = Convert.ToString(dr["Dia_semana"]);
                    this.Horario = TimeSpan.Parse(dr["Horario"].ToString());
                    this.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
                    this.EnderecoCelula = new EnderecoCelula();
                    this.EnderecoCelula.Bairro = Convert.ToString(dr["Bairro"]);
                    this.EnderecoCelula.Cidade = Convert.ToString(dr["Cidade"]);
                    this.EnderecoCelula.Complemento = Convert.ToString(dr["Complemento"]);
                    this.EnderecoCelula.Estado = Convert.ToString(dr["Estado"]);
                    this.EnderecoCelula.Rua = Convert.ToString(dr["Rua"]);
                    this.EnderecoCelula.Pais = Convert.ToString(dr["Pais"]);
                    this.EnderecoCelula.Numero_casa = int.Parse(dr["Numero_casa"].ToString());
                    this.EnderecoCelula.Cep = long.Parse(dr["Cep"].ToString());
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
            }
        }

        public List<modelocrud> recuperarMinisterios(int? id)
        {
            var select = "select * from Ministerio as m inner join " +
                " MinisterioCelula as mice on m.Id=mice.Ministerio_Id  inner join Celula as c" +
                $" on mice.Celula_Id=c.Id where mice.Celula_Id='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            var lista = Ministerio.recuperarTodosMinisterios();

            while (dr.Read())
            {
                var m = lista.First(i => i.Id == int.Parse(Convert.ToString(dr["Ministerio_Id"])));
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join Celula as C on C.Id=P.celula_ "
                + $" where P.celula_='{id}' ";

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

            var lista = Pessoa.recuperarTodos();
            List<Pessoa> lista2 = new List<Pessoa>();
            foreach (var item in lista)
            lista2.Add((Pessoa)item);
            while (dr.Read())
            {
                var m = lista2.First(i => i.Id == int.Parse(Convert.ToString(dr["Id"])));
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public void AdicionarNaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros)
        {
            AddNalista.AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }

        public void RemoverDaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros, int id)
        {
            AddNalista.RemoverDaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros, id);
        }

        public List<int> buscarLista(string TipoDaLista, string Ligacao, string nomeDaChave, int id)
        {
           return  BuscaLista.buscarLista(TipoDaLista, Ligacao, nomeDaChave, id);
        }
    }
}
