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
    [Table("Supervisor_Celula")]
    public class Supervisor_Celula : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Supervisor_Celula set Maximo_celula='{Maximo_celula}' where IdMinisterio='{id}' "
            + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Celula where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Celula as SC inner join Ministerio as MI on SC.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where SC.IdMinisterio='{id}'";
            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
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
                else
                {
                    try
                    {
                        Select_padrao = Select_padrao.Replace("*", "MI.IdMinisterio");
                        supervisoresCelula = new List<Supervisor_Celula>();
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
                            Supervisor_Celula m = new Supervisor_Celula();
                            m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                            modelos.Add(m);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Supervisor_Celula)m;
                            var c = new Supervisor_Celula();
                            if(c.recuperar(cel.IdMinisterio))
                                supervisoresCelula.Add(c); // não deu erro de conexão
                            else
                            {
                                supervisoresCelula = null;
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
                supervisoresCelula = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Supervisor_Celula (IdMinisterio, Maximo_celula) values " +
            $" (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }

    }
}
