using database.banco;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System;

using database;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio_Treinamento")]
    public class Supervisor_Ministerio_Treinamento : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisionar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Ministerio_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update  Supervisor_Ministerio_Treinamento set Maximo_celula='{Maximo_celula}' " +
                $" where IdMinisterio='{id}' " + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Ministerio_Treinamento where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            Select_padrao = $"select * from Supervisor_Ministerio_Treinamento as SMT where SMT.IdMinisterio='{id}' ";
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
                    dr.Read();
                    this.Maximo_celula = int.Parse(dr["Maximo_celula"].ToString());
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
            Select_padrao = "select * from Supervisor_Ministerio_Treinamento as SMT ";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    Select_padrao = Select_padrao.Replace("*", "SMT.IdMinisterio");
                    supervisoresMinisterioTreinamento = new List<Supervisor_Ministerio_Treinamento>();
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
                        Supervisor_Ministerio_Treinamento m = new Supervisor_Ministerio_Treinamento();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);

                    foreach (var m in modelos)
                    {
                        var cel = (Supervisor_Ministerio_Treinamento)m;
                        var c = new Supervisor_Ministerio_Treinamento();
                        if (c.recuperar(cel.IdMinisterio))
                            supervisoresMinisterioTreinamento.Add(c); // não deu erro de conexao
                        else
                        {
                            supervisoresMinisterioTreinamento = null;
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
            supervisoresMinisterioTreinamento = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Supervisor_Ministerio_Treinamento " +
           $" (IdMinisterio, Maximo_celula) values (IDENT_CURRENT('Ministerio'), {Maximo_celula})" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }
    }
}
