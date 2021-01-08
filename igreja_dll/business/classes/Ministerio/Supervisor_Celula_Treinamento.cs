using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula_Treinamento")]
    public class Supervisor_Celula_Treinamento : Abstrato.Ministerio
    {       
        private int maximo_celula;        

        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula
        {
            get
            {
                return maximo_celula;
            }

            set
            {
                maximo_celula = value;
            }
        }

        public Supervisor_Celula_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update  Supervisor_Celula_Treinamento " +
                $" set Maximo_celula='{Maximo_celula}' where Id='{id}' ";
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Celula_Treinamento where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Celula_Treinamento as SCT inner join Ministerio as MI on SCT.Id=MI.Id ";
            if (id != null) Select_padrao += $" where SCT.Id='{id}'";
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
                        Supervisor_Celula_Treinamento m = new Supervisor_Celula_Treinamento();
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
           Insert_padrao += $" insert into Supervisor_Celula_Treinamento " +
          $" (Id, Maximo_celula) values (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;
            
           bd.SalvarModelo(this);
           BDcomum.addNaLista = "";
           return Insert_padrao;
         
        }

        public override string ToString()
        {
            return base.Id.ToString() + " - " + base.Nome;
        }

    }
}
