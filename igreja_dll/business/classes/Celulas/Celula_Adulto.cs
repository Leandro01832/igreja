using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using database;
using database.banco;

namespace business.classes.Celulas
{
    [Table("Celula_Adulto")]
    public class Celula_Adulto : Abstrato.Celula
    {
        public Celula_Adulto() : base()
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
            Delete_padrao = $" delete from Celula_Adulto where IdCelula='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Celula_Adulto as CA "
                + " inner join Celula as C on CA.IdCelula=C.IdCelula ";
            if (id != null) Select_padrao += $" where CA.IdCelula='{id}'";

            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {
                        Select_padrao = "select * from Celula_Adulto as CA "
                        + " inner join Celula as C on CA.IdCelula=C.IdCelula ";
                        if (id != null) Select_padrao += $" where CA.IdCelula='{id}'";
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
                            Celula_Adulto c = new Celula_Adulto();
                            c.IdCelula = int.Parse(dr["IdCelula"].ToString());
                            c.Nome = Convert.ToString(dr["Nome"]);
                            modelos.Add(c);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        celulasAdulto = new List<Celula_Adulto>();
                        foreach (var m in modelos)
                        {
                            var cel = (Celula_Adulto)m;
                            var c = new Celula_Adulto();
                            if(c.recuperar(cel.IdCelula))
                                celulasAdulto.Add(c); //não deu erro de conexao
                            else
                            {
                                celulasAdulto = null;
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
                celulasAdulto = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Celula_Adulto (IdCelula) values (IDENT_CURRENT('Celula')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdCelula.ToString() + " - " + base.Nome;
        }
    }
}
