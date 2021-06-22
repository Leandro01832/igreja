using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace business.classes.Ministerio
{
    [Table("Lider_Celula_Treinamento")]
    public class Lider_Celula_Treinamento : Abstrato.Ministerio
    {
        public Lider_Celula_Treinamento() : base()
        {
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Lider_Celula_Treinamento (IdMinisterio) values " +
            $" (IDENT_CURRENT('Ministerio')) " + BDcomum.addNaLista;
            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Lider_Celula_Treinamento " +
                " as LCT inner join Ministerio as MI on LCT.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where LCT.IdMinisterio='{id}'";
            
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
                        dr.Close();
                        base.recuperar(id);
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
                        LideresCelulaTreinamento = new List<Lider_Celula_Treinamento>();
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
                            Lider_Celula_Treinamento m = new Lider_Celula_Treinamento();
                            m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                            modelos.Add(m);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Lider_Celula_Treinamento)m;
                            var c = new Lider_Celula_Treinamento();
                            if(c.recuperar(cel.IdMinisterio))
                                LideresCelulaTreinamento.Add(c); // não deu erro de conexao
                            else
                            {
                                LideresCelulaTreinamento = null;
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
               LideresCelulaTreinamento = null;
            return false;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Lider_Celula_Treinamento where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id) + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }

    }
}
