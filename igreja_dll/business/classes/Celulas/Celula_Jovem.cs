﻿using System;
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
    [Table("Celula_Jovem")]
    public class Celula_Jovem : Abstrato.Celula
    {
        public Celula_Jovem() : base()
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
            Delete_padrao = $" delete from Celula_Jovem where IdCelula='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Celula_Jovem as CJ "
                + " inner join Celula as C on CJ.IdCelula=C.IdCelula ";
            if (id != null) Select_padrao += $" where CJ.IdCelula='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                bd.obterconexao().Close();
                base.recuperar(id);
                bd.obterconexao().Open();
                Select_padrao = "select * from Celula_Jovem as CJ "
                + " inner join Celula as C on CJ.IdCelula=C.IdCelula ";
                if (id != null) Select_padrao += $" where CJ.IdCelula='{id}'";
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
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
            else
            {
                try
                {
                    bd.obterconexao().Open();
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        bd.obterconexao().Close();
                        return modelos;
                    }

                    while (dr.Read())
                    {
                        Celula_Jovem c = new Celula_Jovem();
                        c.IdCelula = int.Parse(dr["IdCelula"].ToString());
                        modelos.Add(c);
                    }

                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Celula_Jovem)m;
                        var c = new Celula_Jovem();
                        c = (Celula_Jovem)m.recuperar(cel.IdCelula)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
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
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Celula_Jovem (IdCelula) values (IDENT_CURRENT('Celula')) " + BDcomum.addNaLista;
            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdCelula.ToString() + " - " + base.Nome;
        }
    }
}
