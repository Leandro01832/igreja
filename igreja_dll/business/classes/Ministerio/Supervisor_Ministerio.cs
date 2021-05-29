using database.banco;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using business.classes.Abstrato;
using System;

using database;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Ministerio")]
    public class Supervisor_Ministerio : Abstrato.Ministerio
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
            Update_padrao += $" update  Supervisor_Ministerio set Maximo_celula='{Maximo_celula}' where IdMinisterio='{id}' "
            + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Ministerio where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Ministerio as SM inner join Ministerio as MI on SM.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where SM.IdMinisterio='{id}'";
            List<modelocrud> modelos = new List<modelocrud>();
            

            if (id != null)
            {
                try
                {
                    bd.abrirconexao();
                    base.recuperar(id);
                    Select_padrao = "select * from Supervisor_Ministerio as SM inner join Ministerio as MI on SM.IdMinisterio=MI.IdMinisterio ";
                    if (id != null) Select_padrao += $" where SM.IdMinisterio='{id}'";
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao();
                        return modelos;
                    }
                    dr.Read();
                    this.Maximo_celula = int.Parse(dr["Maximo_celula"].ToString());
                    dr.Close();
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
                        Supervisor_Ministerio m = new Supervisor_Ministerio();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Supervisor_Ministerio)m;
                        var c = new Supervisor_Ministerio();
                        c = (Supervisor_Ministerio)m.recuperar(cel.IdMinisterio)[0];
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
            Insert_padrao += $" insert into Supervisor_Ministerio " +
           $" (IdMinisterio, Maximo_celula) values (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }

    }
}
