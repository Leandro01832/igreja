using System;
using System.Windows.Forms;
using System.Drawing;
using database.banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using business.classes.Ministerio;
using database;
using business.classes.Pessoas;
using System.Threading.Tasks;

namespace business.classes.Abstrato
{
    [Table("Pessoa")]
    public abstract class Pessoa : modelocrud, IAddNalista  
    {
        public Pessoa(int? id, bool recuperaLista) : base(id, recuperaLista)
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
                    this.Historico = new List<Historico>();
                    foreach (var m in historicos)
                    {
                        this.Historico.Add((Historico)m);
                    }
                }
            }           

        }

        public Pessoa() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
            this.Endereco = new Endereco();
            this.Telefone = new Telefone();
            this.Chamada = new Chamada
            {
                Data_inicio = DateTime.Now,
                Numero_chamada = 1

            };
        }

        AddNalista AddNalista;

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_nascimento { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rg { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11)]
        [Index("CPF", 2, IsUnique = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cpf { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_civil { get; set; }

        [Display(Name = "Sexo masculino")]
        public bool Sexo_masculino { get; set; }

        [Display(Name = "Sexo feminino")]
        public bool Sexo_feminino { get; set; }

        [ScaffoldColumn(false)]
        public bool Falescimento { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int Falta { get; set; }
        
        public int? celula_ { get; set; }
        [ForeignKey("celula_")]
        public virtual Abstrato.Celula Celula { get; set; }
        
        public virtual Endereco Endereco { get; set; }
        
        public virtual Telefone Telefone { get; set; }

        public virtual Chamada Chamada { get; set; }
       
        public virtual List<Abstrato.Ministerio> Ministerios { get; set; }

        public virtual List<Historico> Historico { get; set; }

        public virtual List<Reuniao> Reuniao { get; set; }

        public virtual List<MudancaEstado> Mudancas { get; set; }

        [Display(Name = "Foto do perfil")]
        public string Img { get; set; }

        private MudancaEstado MudancaEstado;

        public override string salvar()
        {
            Telefone t = new Telefone(); t = this.Telefone;
            Endereco e = new Endereco(); e = this.Endereco;
            Chamada c = new Chamada(); c = this.Chamada;
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

                      Insert_padrao =
              "insert into Pessoa (Nome, Data_nascimento, Estado_civil, Sexo_masculino, " +
              "Rg, Cpf, Sexo_feminino, Falescimento, " +
              "Email, Status, Falta, celula_, Img)" +
              $" values ('{this.Nome}', '{this.Data_nascimento.ToString("yyyy-MM-dd")}', '{this.Estado_civil}', " +
              $" '{this.Sexo_masculino.ToString()}', '{this.Rg}', '{this.Cpf}', " +
              $" '{this.Sexo_feminino.ToString()}', '{this.Falescimento.ToString()}',  " +
              $" '{this.Email}', '{this.Status}', '{this.Falta}', {celula}, '{this.Img}') " +
               c.salvar() + " " +
              e.salvar() + " " +
              t.salvar() + " ";
            
            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

            Update_padrao = $"update Pessoa set Nome='{Nome}', Estado_civil='{Estado_civil}', " +
            $"Rg='{Rg}', Cpf='{Cpf}', Falescimento='{Falescimento.ToString()}', Email='{Email}', Status='{Status}', " +
            $"celula_={celula}, Data_nascimento='{this.Data_nascimento.ToString("yyyy-MM-dd")}', " +
            $" Sexo_masculino='{Sexo_masculino.ToString()}', Sexo_feminino='{Sexo_feminino.ToString()}', " +
            $" Falta='{Falta}', Img='{this.Img}' " +
            $"  where Id='{id}' " + this.Telefone.alterar(id) + this.Endereco.alterar(id);
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Pessoa as P where P.Id='{id}' " +
                " delete Telefone from Telefone as T inner " +
                " join Pessoa as P on T.Id=P.Id" +
                $" where P.Id='{id}' " +
                "delete Endereco from Endereco as E inner " +
                "join Pessoa as P on E.Id=P.Id" +
                $" where P.Id='{id}' ";
            
            bd.Excluir(null);
            return Delete_padrao;
        }        

        public abstract override List<modelocrud> recuperar(int? id);        

        public static List<modelocrud> recuperarTodos()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                var p = new Visitante().recuperar(null);
                if (p != null)
                    lista.AddRange(p);
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                var p = new Crianca().recuperar(null);
                if (p != null)
                 task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                var p = new Membro_Aclamacao().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                var p = new Membro_Reconciliacao().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t5 = t4.ContinueWith((task) =>
            {
                var p = new Membro_Batismo().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task<List<modelocrud>> t6 = t5.ContinueWith((task) =>
            {
                var p = new Membro_Transferencia().recuperar(null);
                if (p != null)
                    task.Result.AddRange(p);
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4, t5, t6);

            return  t6.Result;
        }

        public modelocrud buscarPessoa(int? id)
        {
            Select_padrao = "select * from Pessoa as P "
            + " inner join Endereco as E on E.Id=P.Id "
         + " inner join Telefone as T on T.Id=P.Id "
        + " inner join Chamada as CH on CH.Id=P.Id ";
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
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Email = Convert.ToString(dr["Email"]);
                    this.Falta = int.Parse(dr["Falta"].ToString());
                    this.Estado_civil = Convert.ToString(dr["Estado_civil"]);
                    this.Falescimento = Convert.ToBoolean(Convert.ToString(dr["Falescimento"]));
                    this.Sexo_feminino = Convert.ToBoolean(Convert.ToString(dr["Sexo_feminino"]));
                    this.Sexo_masculino = Convert.ToBoolean(Convert.ToString(dr["Sexo_masculino"]));
                    this.Rg = Convert.ToString(dr["Rg"]);
                    this.Data_nascimento = Convert.ToDateTime(Convert.ToString(dr["Data_nascimento"]));
                    this.Cpf = Convert.ToString(dr["Cpf"]);
                    this.Status = Convert.ToString(dr["Status"]);
                    this.Telefone = new Telefone();
                    this.Telefone.Fone = Convert.ToString(dr["Fone"]);
                    this.Telefone.Celular = Convert.ToString(dr["Celular"]);
                    this.Telefone.Whatsapp = Convert.ToString(dr["Whatsapp"]);
                    this.Endereco = new Endereco();
                    this.Endereco.Cep = long.Parse(Convert.ToString(dr["Cep"]));
                    this.Endereco.Pais = Convert.ToString(dr["Pais"]);
                    this.Endereco.Estado = Convert.ToString(dr["Estado"]);
                    this.Endereco.Cidade = Convert.ToString(dr["Cidade"]);
                    this.Endereco.Bairro = Convert.ToString(dr["Bairro"]);
                    this.Endereco.Rua = Convert.ToString(dr["Rua"]);
                    this.Endereco.Complemento = Convert.ToString(dr["Complemento"]);
                    this.Endereco.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                    this.Chamada = new Chamada();
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
                r.Id = int.Parse(dr["Id"].ToString());
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
                h.Id = int.Parse(dr["Id"].ToString());
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
                var p = new Visitante(v, false).recuperar(v);
                if (p != null) return p[0];
                return null;
            });

            Task<modelocrud> t2 = t.ContinueWith((task) =>
            {
                if(task.Result == null)
                {
                    var p = new Crianca(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t3 = t2.ContinueWith((task) =>
            {
                if(task.Result == null)
                {
                    var p = new Membro_Aclamacao(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t4 = t3.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_Batismo(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t5 = t4.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_Reconciliacao(v, false).recuperar(v);
                    if (p != null) return p[0];
                }
                return task.Result;
            });

            Task<modelocrud> t6 = t5.ContinueWith((task) =>
            {
                if (task.Result == null)
                {
                    var p = new Membro_Transferencia(v, false).recuperar(v);
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
    }
}
