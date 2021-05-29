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
    [Table("Celula_Casado")]
    public class Celula_Casado : Abstrato.Celula
    {
        public Celula_Casado() : base()
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
            Delete_padrao = $" delete from Celula_Casado where IdCelula='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Celula_Casado as CC "
                + " inner join Celula as C on CC.IdCelula=C.IdCelula ";
            if (id != null) Select_padrao += $" where CC.IdCelula='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            

            if (id != null)
            {
                try
                {
                    bd.abrirconexao();
                    base.recuperar(id);
                    Select_padrao = "select * from Celula_Casado as CC "
                    + " inner join Celula as C on CC.IdCelula=C.IdCelula ";
                    if (id != null) Select_padrao += $" where CC.IdCelula='{id}'";
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao();
                        return modelos;
                    }

                    modelos.Add(this);
                }

                catch (Exception ex)
                {
                    TratarExcessao(ex);
                }
                finally
                {
                    bd.fecharconexao();
                }
                return modelos;
            }
            else
            {
                try
                {
                    bd.abrirconexao();
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao();
                        return modelos;
                    }

                    while (dr.Read())
                    {
                        Celula_Casado c = new Celula_Casado();
                        c.IdCelula = int.Parse(dr["IdCelula"].ToString());
                        modelos.Add(c);
                    }

                    dr.Close();

                    //Recursividade
                    bd.fecharconexao();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Celula_Casado)m;
                        var c = new Celula_Casado();
                        c = (Celula_Casado)m.recuperar(cel.IdCelula)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
                }
                catch (Exception ex)
                {
                    TratarExcessao(ex);
                }
                finally
                {
                    bd.fecharconexao();
                }
                return modelos;
            }
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Celula_Casado (IdCelula) values (IDENT_CURRENT('Celula')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdCelula.ToString() + " - " + base.Nome;
        }
    }
}
