using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
            this.Chamada = new Chamada
            {
                Data_inicio = DateTime.Now
            };
        }

        //Propriedades
        #region

        AddNalista AddNalista;

        [Index("CODIGOLgpd", 2, IsUnique = true)]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }
        public int Falta { get; set; }        
        public int? celula_ { get; set; }
        [ForeignKey("celula_")]
        public virtual Abstrato.Celula Celula { get; set; }

        public virtual Chamada Chamada { get; set; }
       
        public virtual List<Abstrato.Ministerio> Ministerios { get; set; }

        public virtual List<Historico> Historico { get; set; }

        public virtual List<Reuniao> Reuniao { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        private MudancaEstado MudancaEstado;

        #endregion

        public override string salvar()
        {
            Codigo = recuperarTodos().Count + 1;
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

                      Insert_padrao =
              "insert into Pessoa (Email,  Falta, celula_, Img) " +
              $" values ( '{this.Email}',  '{this.Falta}', {celula}, '{this.Img}') " +
               this.Chamada.salvar() + " ";
            
            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

            Update_padrao = $"update Pessoa set  " +
            $" Email='{Email}',  " +
            $"celula_={celula}, " +
            $" Falta='{Falta}', Img='{this.Img}' " +
            $"  where Id='{id}' ";
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Pessoa as P where P.Id='{id}' ";
            
            bd.Excluir(null);
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Pessoa as P ";
            if (id != null) Select_padrao += $" where P.Id='{id}'";

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
                    this.Img = Convert.ToString(dr["Img"]);
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
                    this.Email = Convert.ToString(dr["Email"]);
                    this.Falta = int.Parse(dr["Falta"].ToString());
                    this.Chamada = new Chamada();
                    this.Chamada.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                    this.Chamada.Numero_chamada = int.Parse(dr["Numero_chamada"].ToString());

                    if (retornoDados(dr, "celula_"))
                        this.celula_ = int.Parse(dr["celula_"].ToString());

                    dr.Close();

                    this.Ministerios = new List<Ministerio>();
                    var listaMinisterios = recuperarMinisterios(id);
                    foreach(var item in listaMinisterios)
                    {
                        this.Ministerios.Add((Ministerio)item);
                    }
                    this.Reuniao = new List<Reuniao>();
                    var listaReunioes = recuperarReuniao(id);
                    foreach(var item in listaReunioes)
                    {
                        this.Reuniao.Add((Reuniao)item);
                    }
                    this.Historico = new List<Historico>();
                    var listaHistoricos = recuperarHistorico(id);
                    foreach(var item in listaHistoricos)
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
                " PessoaMinisterio as mipe on m.Id=mipe.Ministerio_Id  inner join Pessoa as p" + 
                $" on mipe.Pessoa_Id=p.Id where mipe.Pessoa_Id='{id}' ";

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

        public List<modelocrud> recuperarReuniao(int? id)
        {
            var select = "select * from Reuniao as R inner join " +
                " ReuniaoPessoa as PERE on R.Id=PERE.Reuniao_Id  inner join Pessoa as P" +
                $" on PERE.Pessoa_Id=P.Id where PERE.Pessoa_Id='{id}' ";

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

            while (dr.Read())
            {
                Reuniao r = new Reuniao();
                r.Data_reuniao = Convert.ToDateTime(dr["Data_reuniao"]);
                r.Horario_fim = Convert.ToDateTime(dr["Horario_fim"]);
                r.Horario_inicio = Convert.ToDateTime(dr["Horario_inicio"]);                
                r.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                r.Id = int.Parse(dr["Local_reuniao"].ToString());
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
                $" on P.Id=H.pessoaid where P.Id='{id}' ";

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

            while (dr.Read())
            {
                Historico h = new Historico();
                h.pessoaid = int.Parse(dr["pessoaid"].ToString());
                h.Id = int.Parse(dr["pessoaid"].ToString());
                h.Falta = int.Parse(dr["Falta"].ToString());
                h.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                modelos.Add(h);
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

        public void MudarEstado(int id, modelocrud m)
        {
            MudancaEstado.MudarEstado(id, m);
        }
    }
}
