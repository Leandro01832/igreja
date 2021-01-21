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
    [Table("Lider_Ministerio_Treinamento")]
    public class Lider_Ministerio_Treinamento : Abstrato.Ministerio
    {
        public Lider_Ministerio_Treinamento() : base()
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
            Delete_padrao = $" delete from Lider_Ministerio_Treinamento where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Lider_Ministerio_Treinamento as LMT inner join Ministerio as MI on LMT.Id=MI.Id ";
            if (id != null) Select_padrao += $" where LMT.Id='{id}'";
            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {                
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                base.recuperar(id);
                modelos.Add(this);
                return modelos;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Lider_Ministerio_Treinamento m = new Lider_Ministerio_Treinamento();
                        m.Id = int.Parse(dr["Id"].ToString());
                        m.Nome = Convert.ToString(dr["Nome"]);
                        modelos.Add(m);
                    }
                    dr.Close();
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
            Insert_padrao += $" insert into Lider_Ministerio_Treinamento (Id) values " +
            $" (IDENT_CURRENT('Ministerio'))" + BDcomum.addNaLista;
            bd.SalvarModelo(this);
            
            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Id.ToString() + " - " + base.Nome;
        }
    }
}
