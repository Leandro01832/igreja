using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Ministerio
{

    [Table("Lider_Celula")]
    public class Lider_Celula : Abstrato.Ministerio
    {
        public Lider_Celula() : base()
        {
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Lider_Celula (IdMinisterio) values (IDENT_CURRENT('Ministerio')) " + BDcomum.addNaLista;
            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Lider_Celula as LC inner join Ministerio as MI on LC.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where LC.IdMinisterio='{id}'";
            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                bd.obterconexao().Close();
                base.recuperar(id);
                modelos.Add(this);
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
                        Lider_Celula m = new Lider_Celula();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Lider_Celula)m;
                        var c = new Lider_Celula();
                        c = (Lider_Celula)m.recuperar(cel.IdMinisterio)[0];
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

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Lider_Celula where IdMinisterio='{id}' " + base.excluir(id);
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
