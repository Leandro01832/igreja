using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Collections;

using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes
{
    [Table("Historico")]
    public class Historico : modelocrud
    {

        [Key]
        public int IdHistorico { get; set; }

        public DateTime Data_inicio { get; set; }

        public int pessoaid { get; set; }

        [ForeignKey("pessoaid")]
        public virtual Pessoa Pessoa { get; set; }

        public int Falta { get; set; }

        public Historico() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Historico set Data_inicio={Data_inicio.ToString()}, " +
            $"pessoaid={pessoaid}, Falta={Falta} " +
            $"  where IdHistorico={id} ";

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Historico where IdHistorico='{id}' ";

            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Historico as M";
            if (id != null)
                Select_padrao += $" where M.IdHistorico='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();           

            if (id != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        return modelos;
                    }

                    dr.Read();
                    this.Data_inicio = Convert.ToDateTime(dr["Data_inicio"].ToString());
                    this.IdHistorico = int.Parse(Convert.ToString(dr["IdHistorico"]));
                    this.pessoaid = int.Parse(Convert.ToString(dr["pessoaid"]));
                    this.Falta = int.Parse(Convert.ToString(dr["Falta"]));
                    dr.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }

                modelos.Add(this);
                return modelos;
            }
            else
            {
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        Historico h = new Historico();
                        h.IdHistorico = int.Parse(Convert.ToString(dr["IdHistorico"]));
                        modelos.Add(h);
                    }
                    dr.Close();

                    //Recursividade
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Historico)m;
                        var c = new Historico();
                        c = (Historico)m.recuperar(cel.IdHistorico)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
                return modelos;
            }

        }

        public override string salvar()
        {
            Insert_padrao =
        $"insert into Historico (Data_inicio, pessoaid, Falta) " +
        $"values ({Data_inicio.ToString()}, {pessoaid}, {Falta})";

            bd.SalvarModelo(this);
            return Insert_padrao;
        }

    }
}
