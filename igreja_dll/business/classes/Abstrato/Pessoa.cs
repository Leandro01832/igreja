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
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace business.classes.Abstrato
{
    [Table("Pessoa")]
    public abstract class Pessoa : modelocrud, IAddNalista, IMudancaEstado
    {
        public Pessoa() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();            
        }


        #region Properties

        AddNalista AddNalista;

        [NotMapped]
        public HttpPostedFileBase FiguraFile { get; set; }

        [Key]
        public int IdPessoa { get; set; }


        public string NomePessoa { get; set; }
        
        [Index("CODIGO", 2, IsUnique = true)]
        public int Codigo { get; set; }

        [NotMapped]
        public static int UltimoRegistro { get; set; }

        [NotMapped]
        public string password { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [Index("EMAIL", 2, IsUnique = true)]
        [MaxLength(80, ErrorMessage ="No maximo 80 caracteres!!!")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }
        public int Falta { get; set; }        
        public int? celula_ { get; set; }
        [ForeignKey("celula_")]
        [JsonIgnore]
        public virtual Celula Celula { get; set; }
        [JsonIgnore]
        public virtual Chamada Chamada { get; set; }
        [JsonIgnore]
        public virtual List<PessoaMinisterio> Ministerios { get; set; }
        [JsonIgnore]
        public virtual List<Historico> Historico { get; set; }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Reuniao { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        [NotMapped]
        public byte[] ImgArrayBytes { get; set; }

        [JsonIgnore]
        private MudancaEstado MudancaEstado;

        #endregion

        public override string salvar()
        {
            try
            {
                var ultimoRegistro = 0;
                if (Pessoa.UltimoRegistro == 0)
                ultimoRegistro = recuperarTodos().OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().IdPessoa;
                else ultimoRegistro = Pessoa.UltimoRegistro;
                this.Codigo = ultimoRegistro + 1;
            }
            catch { Codigo = 1; }
            
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

                      Insert_padrao =
              "insert into Pessoa (NomePessoa, Email, Falta, celula_, Img, Codigo) " +
              $" values ( '{this.NomePessoa}', '{this.Email}',  '{this.Falta}', {celula}, '{this.Img}', '{Codigo}') " +
              new Chamada().salvar() + " ";
            
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

            Update_padrao = $"update Pessoa set NomePessoa='{NomePessoa}',  " +
            $" Email='{Email}',  " +
            $" celula_={celula}, " +
            $" Falta='{Falta}', Img='{this.Img}' " +
            $"  where IdPessoa='{id}' ";
            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = " delete Chamada from Chamada as CH inner " +
                "join Pessoa as P on CH.IdChamada=P.IdPessoa " +
                $" where P.IdPessoa='{id}' " +
                $" delete Pessoa from Pessoa as P where P.IdPessoa='{id}' ";
            
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
                 + " inner join Chamada as CH on CH.IdChamada=P.IdPessoa ";
            if (id != null) Select_padrao += $" where P.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();                      

            if (id != null)
            {
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    dr.Read();
                    this.Img = Convert.ToString(dr["Img"]);
                    this.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                    this.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                    this.Email = Convert.ToString(dr["Email"]);
                    this.NomePessoa = Convert.ToString(dr["NomePessoa"]);
                    this.Falta = int.Parse(dr["Falta"].ToString());
                    this.Chamada = new Chamada();
                    this.Chamada.Data_inicio = Convert.ToDateTime(dr["Data_inicio"].ToString());
                    this.Chamada.Numero_chamada = int.Parse(dr["Numero_chamada"].ToString());

                    if (retornoDados(dr, "celula_"))
                        this.celula_ = int.Parse(dr["celula_"].ToString());

                    dr.Close();

                    this.Ministerios = new List<PessoaMinisterio>();
                    bd.obterconexao().Close();
                    var listaMinisterios = recuperarMinisterios(id);                    
                    if (listaMinisterios != null)
                    foreach(var item in listaMinisterios)
                    {
                        this.Ministerios.Add((PessoaMinisterio)item);
                    }
                    this.Reuniao = new List<ReuniaoPessoa>();
                    var listaReunioes = recuperarReuniao(id);
                    if (listaReunioes != null)
                    foreach (var item in listaReunioes)
                    {
                        this.Reuniao.Add((ReuniaoPessoa)item);
                    }
                    this.Historico = new List<Historico>();
                    var listaHistoricos = recuperarHistorico(id);
                    if (listaHistoricos != null)
                    foreach (var item in listaHistoricos)
                    {
                        this.Historico.Add((Historico)item);
                    }

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

            bd.obterconexao().Close();
            return modelos;
        }

        public static List<modelocrud> recuperarTodos()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                var p = new VisitanteLgpd().recuperar(null);
                if (p != null)
                    lista.AddRange(p);
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                var p = new CriancaLgpd().recuperar(null);
                if (p != null)
                 task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                var p = new Membro_AclamacaoLgpd().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                var p = new Membro_ReconciliacaoLgpd().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                var p = new Membro_BatismoLgpd().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                var p = new Membro_TransferenciaLgpd().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t7 = t6.ContinueWith((task) =>
            {
                var p = new Visitante().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t8 = t7.ContinueWith((task) =>
            {
                var p = new Crianca().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t9 = t8.ContinueWith((task) =>
            {
                var p = new Membro_Aclamacao().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t10 = t9.ContinueWith((task) =>
            {
                var p = new Membro_Reconciliacao().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t11 = t10.ContinueWith((task) =>
            {
                var p = new Membro_Batismo().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t12 = t11.ContinueWith((task) =>
            {
                var p = new Membro_Transferencia().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);            

            return  t12.Result;
        }       

        public List<modelocrud> recuperarMinisterios(int? id)
        {
            var select = "select * from Ministerio as m inner join " +
                " PessoaMinisterio as mipe on m.IdMinisterio=mipe.MinisterioId  inner join Pessoa as p" + 
                $" on mipe.PessoaId=p.IdPessoa where mipe.PessoaId='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            var lista = new PessoaMinisterio().recuperar(null).OfType<PessoaMinisterio>().ToList();

            while (dr.Read())
            {
               var m = lista.First(i =>  i.MinisterioId == int.Parse(Convert.ToString(dr["MinisterioId"])));
                modelos.Add(m);
            }
            dr.Close();
            bd.obterconexao().Close();
            return modelos;
        }

        public List<modelocrud> recuperarReuniao(int? id)
        {
            var select = "select * from Reuniao as R inner join " +
                " ReuniaoPessoa as PERE on R.IdReuniao=PERE.ReuniaoId  inner join Pessoa as P" +
                $" on PERE.PessoaId=P.IdPessoa where PERE.PessoaId='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            var lista = new ReuniaoPessoa().recuperar(null).OfType<ReuniaoPessoa>().ToList();

            while (dr.Read())
            {
                var r = lista.First(i => i.ReuniaoId == int.Parse(Convert.ToString(dr["ReuniaoId"])));
                modelos.Add(r);
            }
            dr.Close();

            bd.obterconexao().Close();
            return modelos;
        }

        public List<modelocrud> recuperarHistorico(int? id)
        {
            var select = "select * from Historico as H " +
                " inner join Pessoa as P" +
                $" on P.IdPessoa=H.pessoaid where P.IdPessoa='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            while (dr.Read())
            {
                Historico h = new Historico();
                h.pessoaid = int.Parse(dr["pessoaid"].ToString());
                h.IdHistorico = int.Parse(dr["IdHistorico"].ToString());
                h.Falta = int.Parse(dr["Falta"].ToString());
                h.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                modelos.Add(h);
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
