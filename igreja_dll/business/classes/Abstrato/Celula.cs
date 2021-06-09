using business.classes.Celula;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
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
    public abstract  class Celula : modelocrud, IAddNalista, IBuscaLista
    {
        #region properties
        [Key]
        public int IdCelula { get; set; }

        [Display(Name = "Nome da celula")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Dia da semana")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Dia_semana { get; set; }

        [Display(Name = "Horário")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario { get; set; }
        [JsonIgnore]
        public virtual List<Pessoa> Pessoas { get; set; }

        [Display(Name = "Máximo de pessoas")]
        public int Maximo_pessoa { get; set; }
        [JsonIgnore]
        public virtual List<MinisterioCelula> Ministerios { get; set; }
        [JsonIgnore]
        public virtual EnderecoCelula EnderecoCelula { get; set; }

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        public static List<Celula_Adolescente> celulasAdolescente { get; set; }
        public static List<Celula_Jovem> celulasJovem { get; set; }
        public static List<Celula_Adulto> celulasAdulto { get; set; }
        public static List<Celula_Crianca> celulasCrianca { get; set; }
        public static List<Celula_Casado> celulasCasado { get; set; }
        #endregion

        AddNalista AddNalista;
        BuscaLista BuscaLista;

        public Celula() : base()
        {
            this.Maximo_pessoa = 50;
            AddNalista = new AddNalista();
            BuscaLista = new BuscaLista();
        }

        #region Methods
        public override string alterar(int id)
        {
            Update_padrao = $"update Celula set Nome='{Nome}', Dia_semana='{Dia_semana}', " +
            $"Horario='{Horario.ToString()}', Maximo_pessoa='{Maximo_pessoa}' " +
            $"  where IdCelula='{id}' " + this.EnderecoCelula.alterar(id);

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete Celula from Celula where IdCelula='{id}'"
                + " delete EnderecoCelula from EnderecoCelula "
                + " as E inner join Celula as C on E.IdEnderecoCelula=C.IdCelula"
                + $" where C.IdCelula='{id}'";

            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Celula as C "
            + " inner join EnderecoCelula as E on E.IdEnderecoCelula=C.IdCelula ";
            if (id != null) Select_padrao += $" where C.IdCelula='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            if (id != null)
            {
                SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                
                    dr.Read();
                    this.IdCelula = int.Parse(dr["IdCelula"].ToString());
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

                bd.fecharconexao(conexao);
                this.Ministerios = new List<MinisterioCelula>();
                    var listaMinisterios = recuperarMinisterios(id);
                    if (listaMinisterios != null)
                        foreach (var item in listaMinisterios)
                            this.Ministerios.Add((MinisterioCelula)item);

                    this.Pessoas = new List<Pessoa>();
                    var listaPessoas = buscarPessoas(id);
                    if (listaPessoas != null)
                        foreach (var item in listaPessoas)
                            this.Pessoas.Add((Pessoa)item);

                

                modelos.Add(this);
                return modelos;
            }
            return modelos;
        }

        public override string salvar()
        {
            Insert_padrao = "insert into Celula (Nome, Dia_semana, Horario, Maximo_pessoa) " +
                $" values  ('{Nome}', '{Dia_semana}', '{Horario}', '{Maximo_pessoa}') "
                + this.EnderecoCelula.salvar();

            return Insert_padrao;
        } 
        #endregion

        public static List<modelocrud> recuperarTodasCelulas()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                if (celulasAdolescente == null)
                {
                    celulasAdolescente = new List<Celula_Adolescente>();
                    var c = new Celula_Adolescente().recuperar(null);                    
                    if(c != null)
                    {
                        lista.AddRange(c);
                        if(celulasAdolescente != null)
                        celulasAdolescente.AddRange(c.OfType<Celula_Adolescente>());
                    }                    
                }                
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (celulasAdulto == null)
                {
                    celulasAdulto = new List<Celula_Adulto>();
                    var c = new Celula_Adulto().recuperar(null);
                    if(c != null)
                    {
                        task.Result.AddRange(c);
                        if (celulasAdulto != null)
                            celulasAdulto.AddRange(c.OfType<Celula_Adulto>());
                    }                    
                }                
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (celulasCasado == null)
                {
                    celulasCasado = new List<Celula_Casado>();
                    var c = new Celula_Casado().recuperar(null);
                    if(c != null)
                    {
                        task.Result.AddRange(c);
                        if (celulasCasado != null)
                            celulasCasado.AddRange(c.OfType<Celula_Casado>());
                    }                    
                }                    
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (celulasCrianca == null)
                {
                    celulasCrianca = new List<Celula_Crianca>();
                    var c = new Celula_Crianca().recuperar(null);
                    if(c != null)
                    {
                        task.Result.AddRange(c);
                        if (celulasCrianca != null)
                            celulasCrianca.AddRange(c.OfType<Celula_Crianca>());
                    }                    
                }                    
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (celulasJovem == null)
                {
                    celulasJovem = new List<Celula_Jovem>();
                    var c = new Celula_Jovem().recuperar(null);
                    if(c != null)
                    {
                        task.Result.AddRange(c);
                        if (celulasJovem != null)
                            celulasJovem.AddRange(c.OfType<Celula_Jovem>());
                    }                    
                }                    
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5);

            return t5.Result;
        }
        
        private List<modelocrud> recuperarMinisterios(int? id)
        {
            var select = "select * from Ministerio as m inner join " +
                " MinisterioCelula as mice on m.IdMinisterio=mice.MinisterioId  inner join Celula as c" +
                $" on mice.CelulaId=c.IdCelula where mice.CelulaId='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            List<MinisterioCelula> lista = new List<MinisterioCelula>();
            var conexao = bd.obterconexao();
            
            SqlCommand comando = new SqlCommand(select, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return modelos;
            }

            while (dr.Read())
            {
                var m = new MinisterioCelula { IdMinisterioCelula = int.Parse(Convert.ToString(dr["IdMinisterioCelula"])) };
                lista.Add(m);
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach (var item in lista)
                modelos.Add(new MinisterioCelula().recuperar(item.IdMinisterioCelula)[0]);
            

            return modelos;
        }

        private List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join Celula as C on C.IdCelula=P.celula_ "
                + $" where P.celula_='{id}' ";

            var conexao = bd.obterconexao();

            List<modelocrud> modelos = new List<modelocrud>();
            List<int> lista = new List<int>();

            
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
                lista.Add(int.Parse(Convert.ToString(dr["IdPessoa"])));                
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach(var item in lista)
            {
                var p1 = new Visitante().recuperar(item);
                var p2 = new VisitanteLgpd().recuperar(item);
                var p3 = new Crianca().recuperar(item);
                var p4 = new CriancaLgpd().recuperar(item);
                var p5 = new Membro_Aclamacao().recuperar(item);
                var p6 = new Membro_AclamacaoLgpd().recuperar(item);
                var p7 = new Membro_Batismo().recuperar(item);
                var p8 = new Membro_BatismoLgpd().recuperar(item);
                var p9 = new Membro_Reconciliacao().recuperar(item);
                var p10 = new Membro_ReconciliacaoLgpd().recuperar(item);
                var p11 = new Membro_Transferencia().recuperar(item);
                var p12 = new Membro_TransferenciaLgpd().recuperar(item);
                Pessoa p = null;
                if (p1.Count > 0) p = (Pessoa)p1[0];
                if (p2.Count > 0) p = (Pessoa)p2[0];
                if (p3.Count > 0) p = (Pessoa)p3[0];
                if (p4.Count > 0) p = (Pessoa)p4[0];
                if (p5.Count > 0) p = (Pessoa)p5[0];
                if (p6.Count > 0) p = (Pessoa)p6[0];
                if (p7.Count > 0) p = (Pessoa)p7[0];
                if (p8.Count > 0) p = (Pessoa)p8[0];
                if (p9.Count > 0) p = (Pessoa)p9[0];
                if (p10.Count > 0) p = (Pessoa)p10[0];
                if (p11.Count > 0) p = (Pessoa)p11[0];
                if (p12.Count > 0) p = (Pessoa)p12[0];
                if (p != null)
                    modelos.Add(p);
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

        public List<int> buscarLista(modelocrud TipoDaLista, modelocrud Ligacao, string nomeDaChave, int id)
        {
           return  BuscaLista.buscarLista(TipoDaLista, Ligacao, nomeDaChave, id);
        }
    }
}
