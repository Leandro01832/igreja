﻿using database.banco;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

using System;
using database;

namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula")]
    public class Supervisor_Celula : Abstrato.Ministerio
    {
        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula() : base()
        {
            this.Maximo_celula = 5;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Supervisor_Celula set Maximo_celula='{Maximo_celula}' where IdMinisterio='{id}' "
            + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Supervisor_Celula where IdMinisterio='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Supervisor_Celula as SC inner join Ministerio as MI on SC.IdMinisterio=MI.IdMinisterio ";
            if (id != null) Select_padrao += $" where SC.IdMinisterio='{id}'";
            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            if (id != null)
            {
                try
                {
                    Select_padrao = "select * from Supervisor_Celula as SC inner join Ministerio as MI on SC.IdMinisterio=MI.IdMinisterio ";
                    if (id != null) Select_padrao += $" where SC.IdMinisterio='{id}'";
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return modelos;
                    }
                    base.recuperar(id);
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
                    bd.fecharconexao(conexao);
                }                
                return modelos;
            }
            else
            {
                try
                {
                    
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return modelos;
                    }

                    while (dr.Read())
                    {
                        Supervisor_Celula m = new Supervisor_Celula();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Supervisor_Celula)m;
                        var c = new Supervisor_Celula();
                        c = (Supervisor_Celula)m.recuperar(cel.IdMinisterio)[0];
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
                    bd.fecharconexao(conexao);
                }
                return modelos;
            }
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Supervisor_Celula (IdMinisterio, Maximo_celula) values " +
            $" (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.IdMinisterio.ToString() + " - " + base.Nome;
        }

    }
}
