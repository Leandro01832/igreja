using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes.Abstrato
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : modelocrud, IAddNalista, IMudancaEstado  
    {
        public PessoaLgpd(int? id, bool recuperaLista) : base(id, recuperaLista)
        {
            buscarPessoa(id);

            if(recuperaLista)
            {
                var ministerios = recuperarMinisterios(id);
                if (ministerios != null)
                {
                    this.Ministerios = new List<Ministerio>();
                    foreach (var m in ministerios)
                    {
                        this.Ministerios.Add((Ministerio)m);
                    }
                }

                var reunioes = recuperarReuniao(id);
                if (reunioes != null)
                {
                    this.Reuniao = new List<Reuniao>();
                    foreach (var m in reunioes)
                    {
                        this.Reuniao.Add((Reuniao)m);
                    }
                }

                var historicos = recuperarHistorico(id);
                if (historicos != null)
                {
                    this.Historico = new List<HistoricoLgpd>();
                    foreach (var m in historicos)
                    {
                        this.Historico.Add((HistoricoLgpd)m);
                    }
                }
            }           

        }

        public PessoaLgpd() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
            this.Chamada = new ChamadaLgpd
            {
                Data_inicio = DateTime.Now,
                Numero_chamada = 1

            };
        }

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

        public virtual ChamadaLgpd Chamada { get; set; }
       
        public virtual List<Abstrato.Ministerio> Ministerios { get; set; }

        public virtual List<HistoricoLgpd> Historico { get; set; }

        public virtual List<Reuniao> Reuniao { get; set; }
        
        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        private MudancaEstado MudancaEstado;

        public override string salvar()
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

                      Insert_padrao =
              "insert into PessoaLgpd (Email,  Falta, celula_, Img) " +
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

            Update_padrao = $"update PessoaLgpd set  " +
            $" Email='{Email}',  " +
            $"celula_={celula}, " +
            $" Falta='{Falta}', Img='{this.Img}' " +
            $"  where Id='{id}' ";
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from PessoaLgpd as P where P.Id='{id}' ";
            
            bd.Excluir(null);
            return Delete_padrao;
        }        

        public abstract override List<modelocrud> recuperar(int? id);        

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

            Task.WaitAll(t, t2, t3, t4, t5, t6);

            return  t6.Result;
        }

        public modelocrud buscarPessoa(int? id)
        {
            Select_padrao = "select * from PessoaLgpd as P "
        + " inner join ChamadaLgpd as CH on CH.Id=P.Id ";
            if (id != null) Select_padrao += $" where P.Id='{id}'";

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
                    this.Img = Convert.ToString(dr["Img"]);
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
                    this.Email = Convert.ToString(dr["Email"]);
                    this.Falta = int.Parse(dr["Falta"].ToString());
                    this.Chamada = new ChamadaLgpd();
                    this.Chamada.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                    this.Chamada.Numero_chamada = int.Parse(dr["Numero_chamada"].ToString());

                    if (retornoDados(dr, "celula_"))
                    this.celula_ = int.Parse(dr["celula_"].ToString());

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
                return this;
            }
            return null;
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

            while (dr.Read())
            {
               var m = (Ministerio)
               Ministerio.recuperarMinisterio(int.Parse(Convert.ToString(dr["Ministerio_Id"])));
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
            var select = "select * from HistoricoLgpd as H " +
                " inner join PessoaLgpd as P" +
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
                HistoricoLgpd h = new HistoricoLgpd();
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

        public static modelocrud recuperarPessoa(int v)
        {
            Task<modelocrud> t = Task.Factory.StartNew(() =>
            {
                var p = new VisitanteLgpd(v, false).recuperar(v);
                if (p != null) return p[0];
                return null;
            });

            Task<modelocrud> t2 = t.ContinueWith((task) =>
            {
                if(task.Result == null)
                {
                    var p = new CriancaLgpd(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t3 = t2.ContinueWith((task) =>
            {
                if(task.Result == null)
                {
                    var p = new Membro_AclamacaoLgpd(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t4 = t3.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_BatismoLgpd(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t5 = t4.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_ReconciliacaoLgpd(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t6 = t5.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_TransferenciaLgpd(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5,t6);

            return t6.Result;
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
