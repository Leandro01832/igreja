using database.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;

namespace business.classes.Abstrato
{

    [Table("MembroLgpd")]
    public abstract class MembroLgpd : PessoaLgpd
    {        
        
        private int data_batismo;
        private bool desligamento;

        [Display(Name = "Ano de batismo")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_batismo
        {
            get
            {
                return data_batismo;
            }

            set
            {
                data_batismo = value;
            }
        }

        public bool Desligamento
        {
            get
            {
                return desligamento;
            }

            set
            {
                desligamento = value;
            }
        }

        public bool Save()
        {
            return true;
        }

        public string Motivo_desligamento { get; set; }

        public MembroLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update MembroLgpd set Data_batismo='{Data_batismo}', " +
            $" Desligamento='{Desligamento.ToString()}', Motivo_desligamento='{Motivo_desligamento}' where Id='{id}'";
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from MembroLgpd where Id='{id}' " + base.excluir(id);

            bd.Excluir(null);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from MembroLgpd as P ";
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
                base.recuperar(id);
                try
                {
                    dr.Read();
                    this.Data_batismo = int.Parse(dr["Data_nascimento"].ToString());
                    this.Desligamento = Convert.ToBoolean(dr["Desligamento"]);
                    this.Motivo_desligamento = Convert.ToString(dr["Motivo_desligamento"]);
                    dr.Close();
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
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into MembroLgpd (Data_batismo, Desligamento, Motivo_desligamento, Id) values" +
                $" ('{this.Data_batismo}', '{this.Desligamento}', '{this.Motivo_desligamento}', IDENT_CURRENT('PessoaLgpd'))";

            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public static List<modelocrud> recuperarTodosMembros()
        {
            List<modelocrud> lista = new List<modelocrud>();
            Task<List<modelocrud>> t = Task.Factory.StartNew(() =>
            {
                var m = new Membro_AclamacaoLgpd().recuperar(null);
                if (m != null)
                    lista.AddRange(m);
                return lista;
            });

            Task<List<modelocrud>> t2 = t.ContinueWith((task) =>
            {
                var m = new Membro_BatismoLgpd().recuperar(null);
                if (m != null)
                 task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t3 = t2.ContinueWith((task) =>
            {
                var m = new Membro_ReconciliacaoLgpd().recuperar(null);
                if (m != null)
                    task.Result.AddRange(m);
                return task.Result;
            });

            Task<List<modelocrud>> t4 = t3.ContinueWith((task) =>
            {
                var m = new Membro_TransferenciaLgpd().recuperar(null);
                if (m != null)
                    task.Result.AddRange(m);
                return task.Result;
            });

            Task.WaitAll(t, t2, t3, t4);

            return t4.Result;
        }        

        public modelocrud buscarMembro(int? id)
        {
            Select_padrao = "select * from PessoaLgpd as P "
            + " inner join MembroLgpd as M on P.Id=M.Id ";
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
                    this.Data_batismo = int.Parse(dr["Data_batismo"].ToString());
                    this.Desligamento = Convert.ToBoolean(dr["Desligamento"]);
                    this.Motivo_desligamento = Convert.ToString(dr["Estado_civil"]);                   

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
        
    }
}
