using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

using database;
using business.classes.Abstrato;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_BatismoLgpd")]
    public class Membro_BatismoLgpd : MembroLgpd
    {
        public Membro_BatismoLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id) + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            Select_padrao = $"select * from Membro_BatismoLgpd as MB where MB.IdPessoa='{id}'";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }
                    base.recuperar(id);
                    dr.Close();

                }
                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            return false;
        }

        public override bool recuperar()
        {
            Select_padrao = "select * from Membro_BatismoLgpd as MB ";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    Select_padrao = Select_padrao.Replace("*", "MB.IdPessoa");
                    membros_BatismoLgpd = new List<Membro_BatismoLgpd>();
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    List<modelocrud> modelos = new List<modelocrud>();
                    while (dr.Read())
                    {
                        Membro_BatismoLgpd mb = new Membro_BatismoLgpd();
                        mb.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                        modelos.Add(mb);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);

                    foreach (var m in modelos)
                    {
                        var cel = (Membro_BatismoLgpd)m;
                        var c = new Membro_BatismoLgpd();
                        if (c.recuperar(cel.IdPessoa))
                            membros_BatismoLgpd.Add(c); // não deu erro de conexao
                        else
                        {
                            membros_BatismoLgpd = null;
                            return false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            membros_BatismoLgpd = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_BatismoLgpd (IdPessoa) values (IDENT_CURRENT('Pessoa')) "
            + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }

    }
}
