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
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("Membro_Batismo")]
    public class Membro_Batismo : Membro
    {
        public Membro_Batismo() : base()
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
            Delete_padrao = $" delete from Membro_Batismo where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }


        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Batismo as MB "
                + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";
            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {
                        Select_padrao = "select * from Membro_Batismo as MB "
                        + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                        + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";
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
                else
                {
                    try
                    {
                        Select_padrao = "select * from Membro_Batismo as MB "
                        + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                        + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";
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
                            Membro_Batismo mb = new Membro_Batismo();
                            mb.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(mb);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        membros_Batismo = new List<Membro_Batismo>();
                        foreach (var m in modelos)
                        {
                            var cel = (Membro_Batismo)m;
                            var c = new Membro_Batismo();
                            if(c.recuperar(cel.IdPessoa))
                                membros_Batismo.Add(c); // não deu erro de conexao
                            else
                            {
                                membros_Batismo = null;
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
            }
            if (id == null)
               membros_Batismo = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_Batismo (IdPessoa) values (IDENT_CURRENT('Pessoa')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
