using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;
using database.banco;

namespace business.classes.Celulas
{
    [Table("Celula_Adolescente")]
    public class Celula_Adolescente : Abstrato.Celula
    {
        public Celula_Adolescente() : base()
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
            Delete_padrao = $" delete from Celula_Adolescente where IdCelula='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Celula_Adolescente as CA "
                + " inner join Celula as C on CA.IdCelula=C.IdCelula ";
            if (id != null) Select_padrao += $" where CA.IdCelula='{id}'";

            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {
                        Select_padrao = "select * from Celula_Adolescente as CA "
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
                        celulasAdolescente = new List<Celula_Adolescente>();
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
                            Celula_Adolescente c = new Celula_Adolescente();
                            c.IdCelula = int.Parse(dr["IdCelula"].ToString());
                            c.Nome = Convert.ToString(dr["Nome"]);
                            modelos.Add(c);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Celula_Adolescente)m;
                            var c = new Celula_Adolescente();
                            if(c.recuperar(cel.IdCelula))
                            celulasAdolescente.Add(c); // não deu erro de conexao
                            else
                            {
                                celulasAdolescente = null;
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
                celulasAdolescente = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += "insert into Celula_Adolescente (IdCelula) values (IDENT_CURRENT('Celula')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdCelula.ToString() + " - " + base.Nome;
        }
    }
}
