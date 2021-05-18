using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;
using database.banco;

namespace business.classes.Ministerio
{
    [Table("Lider_Ministerio")]
    public class Lider_Ministerio : Abstrato.Ministerio
    {
        public Lider_Ministerio() : base()
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
            Delete_padrao = $" delete from Lider_Ministerio where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Lider_Ministerio as LM inner join Ministerio as MI on LM.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where LM.IdMinisterio='{id}'";
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
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        Lider_Ministerio m = new Lider_Ministerio();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Lider_Ministerio)m;
                        var c = new Lider_Ministerio();
                        c = (Lider_Ministerio)m.recuperar(cel.IdMinisterio)[0];
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
            Insert_padrao += $" insert into Lider_Ministerio (IdMinisterio) values " +
            $" (IDENT_CURRENT('Ministerio'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            
            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }
    }
}
