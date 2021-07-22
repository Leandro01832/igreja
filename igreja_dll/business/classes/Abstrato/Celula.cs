using business.classes.Celula;
using business.classes.Celulas;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
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

        protected Celula(int m) : base(m) { }

        #region Methods
        public override string alterar(int id)
        {
            Update_padrao = $"update Celula set Nome='{Nome}', Dia_semana='{Dia_semana}', " +
            $"Horario='{Horario.ToString()}', Maximo_pessoa='{Maximo_pessoa}' " +
            $"  where Id='{id}' " + this.EnderecoCelula.alterar(id);

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = Delete_padrao.Replace(GetType().Name, GetType().BaseType.Name)
                + new EnderecoCelula(id).excluir(id);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            Select_padrao = Select_padrao.Replace(GetType().Name, GetType().BaseType.Name);

            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                return false;
            }

            dr.Read();
            this.Id = int.Parse(dr["Id"].ToString());
            this.Nome = Convert.ToString(dr["Nome"]);
            this.Dia_semana = Convert.ToString(dr["Dia_semana"]);
            this.Horario = TimeSpan.Parse(dr["Horario"].ToString());
            this.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
            this.EnderecoCelula = new EnderecoCelula(id);
            this.EnderecoCelula.recuperar(id);

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
            return true;
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
                if (celulasAdolescente == null && new Celula_Adolescente().recuperar())
                { lista.AddRange(celulasAdolescente); Modelos.AddRange(celulasAdolescente); }

                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                if (celulasAdulto == null && new Celula_Adulto().recuperar())
                { task.Result.AddRange(celulasAdulto); Modelos.AddRange(celulasAdulto); }

                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                if (celulasCasado == null && new Celula_Casado().recuperar())
                { task.Result.AddRange(celulasCasado); Modelos.AddRange(celulasCasado); }

                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                if (celulasCrianca == null && new Celula_Crianca().recuperar())
                { task.Result.AddRange(celulasCasado); Modelos.AddRange(celulasCrianca); }

                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                if (celulasJovem == null && new Celula_Jovem().recuperar())
                { task.Result.AddRange(celulasJovem); Modelos.AddRange(celulasJovem); }

                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5);

            return t5.Result;
        }

        private List<modelocrud> recuperarMinisterios(int? id)
        {
            var select = "select * from Ministerio as m inner join " +
                " MinisterioCelula as mice on m.Id=mice.MinisterioId  inner join Celula as c" +
                $" on mice.CelulaId=c.Id where mice.CelulaId='{id}' ";

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
                var m = new MinisterioCelula { Id = int.Parse(Convert.ToString(dr["Id"])) };
                lista.Add(m);
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach (var item in lista)
            {
                var model = new MinisterioCelula();
                if(model.recuperar(item.Id))
                modelos.Add(model);
            }           

            return modelos;
        }

        private List<modelocrud> buscarPessoas(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                + " inner join Celula as C on C.Id=P.celula_ "
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
                lista.Add(int.Parse(Convert.ToString(dr["Id"])));                
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach(var item in lista)
            {
                var model1 = new Visitante();                var p1 = model1.recuperar(item);
                var model2  = new VisitanteLgpd()            ;  var p2 =   model2   .recuperar(item);
                var model3  = new Crianca()                  ;  var p3 =   model3   .recuperar(item);
                var model4  = new CriancaLgpd()              ;  var p4 =   model4   .recuperar(item);
                var model5  = new Membro_Aclamacao()         ;  var p5 =   model5   .recuperar(item);
                var model6  = new Membro_AclamacaoLgpd()     ;  var p6 =   model6   .recuperar(item);
                var model7  = new Membro_Batismo()           ;  var p7 =   model7   .recuperar(item);
                var model8  = new Membro_BatismoLgpd()       ;  var p8 =   model8   .recuperar(item);
                var model9  = new Membro_Reconciliacao()     ;  var p9 =   model9   .recuperar(item);
                var model10 = new Membro_ReconciliacaoLgpd() ;  var p10 =  model10  .recuperar(item);
                var model11 = new Membro_Transferencia()     ;  var p11 =  model11  .recuperar(item);
                var model12 = new Membro_TransferenciaLgpd();   var p12 =  model12.recuperar(item);
                Pessoa p = null;
                if (p1) p =  model1 ;
                if (p2) p =  model2 ;
                if (p3) p =  model3 ;
                if (p4) p =  model4 ;
                if (p5) p =  model5 ;
                if (p6) p =  model6 ;
                if (p7) p =  model7 ;
                if (p8) p =  model8 ;
                if (p9) p =  model9 ;
                if (p10) p = model10;
                if (p11) p = model11;
                if (p12) p = model12;
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
