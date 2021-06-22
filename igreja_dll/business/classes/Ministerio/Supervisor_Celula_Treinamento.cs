using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;


namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula_Treinamento")]
    public class Supervisor_Celula_Treinamento : Abstrato.Ministerio
    {

        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update  Supervisor_Celula_Treinamento " +
                $" set Maximo_celula='{Maximo_celula}' where IdMinisterio='{id}' " + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Celula_Treinamento where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Celula_Treinamento as SCT inner join Ministerio as MI on SCT.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where SCT.IdMinisterio='{id}'";
            
            var conexao = bd.obterconexao();

            if (conexao  != null)
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
                        supervisoresCelulaTreinamento = new List<Supervisor_Celula_Treinamento>();
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
                            Supervisor_Celula_Treinamento m = new Supervisor_Celula_Treinamento();
                            m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                            modelos.Add(m);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Supervisor_Celula_Treinamento)m;
                            var c = new Supervisor_Celula_Treinamento();
                            if(c.recuperar(cel.IdMinisterio))
                                supervisoresCelulaTreinamento.Add(c); // não deu erro de conexao
                            else
                            {
                                supervisoresCelulaTreinamento = null;
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
                supervisoresCelulaTreinamento = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Supervisor_Celula_Treinamento " +
           $" (IdMinisterio, Maximo_celula) values (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;

        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }

    }
}
