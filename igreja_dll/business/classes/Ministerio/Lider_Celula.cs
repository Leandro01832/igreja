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

        public Lider_Celula(int? id, bool recuperaLista) : base(id, recuperaLista)
        {

        }
        
        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Lider_Celula (Id) values (IDENT_CURRENT('Ministerio')) " + BDcomum.addNaLista;
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Lider_Celula as LC inner join Ministerio as MI on LC.Id=MI.Id ";
            if (id != null) Select_padrao += $" where LC.Id='{id}'";
            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
                modelos.Add(this);                
                return modelos;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Lider_Celula m = new Lider_Celula();
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

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Lider_Celula where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            bd.Editar(this);
            return Update_padrao;
        }

    }
}
