using database.banco;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using business.classes.Abstrato;
using System;
using System.Windows.Forms;
using database;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio")]
    public  class Supervisor_Ministerio : Abstrato.Ministerio
    {
        
        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Ministerio() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update  Supervisor_Ministerio set Maximo_celula='{Maximo_celula}' where Id='{id}' " 
            + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Ministerio where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Ministerio as SM inner join Ministerio as MI on SM.Id=MI.Id ";
            if (id != null) Select_padrao += $" where SM.Id='{id}'";
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
                dr.Read();
                this.Maximo_celula = int.Parse(dr["Maximo_celula"].ToString());
                dr.Close();
                modelos.Add(this);
                return modelos;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Supervisor_Ministerio m = new Supervisor_Ministerio();
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
            Insert_padrao += $" insert into Supervisor_Ministerio " +
           $" (Id, Maximo_celula) values (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;            

            bd.SalvarModelo(this);
            
            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Id.ToString() + " - " + base.Nome;
        }

    }
}
