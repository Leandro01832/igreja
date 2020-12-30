using business.classes.Abstrato;
using database;
using database.banco;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes
{

    public  class Chamada : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }

        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public  DateTime Data_inicio
        {
            get;

            set;
        }

        [Display(Name = "Numero da chamada")]
        public int Numero_chamada { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public Chamada()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Chamada set Data_inicio={Data_inicio.ToString()},"
               + $" Numero_chamada={Numero_chamada} where Id={id} ";
            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Chamada where Id={id} ";
            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Chamada as C";
            if (id != null)
                Select_padrao +=  $" where C.Id='{id}'";

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
                if (dr.HasRows == false)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        dr.Read();
                        this.Data_inicio = Convert.ToDateTime(Convert.ToString(dr["Data_inicio"]));
                        this.Id = int.Parse(Convert.ToString(dr["Id"]));
                        this.Numero_chamada = int.Parse(Convert.ToString(dr["Numero_chamada"]));

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

                    modelos.Add(this);
                    return modelos;

                }
            }
            else
            {


                if (dr.HasRows == false)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        while (dr.Read())
                        {
                            this.Data_inicio = Convert.ToDateTime(Convert.ToString(dr["Data_inicio"]));
                            this.Id = int.Parse(Convert.ToString(dr["Id"]));
                            this.Numero_chamada = int.Parse(Convert.ToString(dr["Numero_chamada"]));
                            modelos.Add(this);
                        }

                        dr.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                    return modelos;
                }

            }

        }

        public override string salvar()
        {            
            Insert_padrao = $"insert into Chamada "
            + " (Data_inicio, Numero_chamada, Id) values"
            + $" ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{Numero_chamada.ToString()}', IDENT_CURRENT('Pessoa'))";
            
            return Insert_padrao;
        }       

        
    }
}
