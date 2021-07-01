﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool recuperar(int id)
        {
            Select_padrao = $"select * from Lider_Ministerio as LM where LM.IdMinisterio='{id}'";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }
                    dr.Close();
                    base.recuperar(id);
                }
                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            return false;
        }

        public override bool recuperar()
        {
            Select_padrao = "select * from Lider_Ministerio as LM ";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    Select_padrao = Select_padrao.Replace("*", "LM.IdMinisterio");
                    lideresMinisterio = new List<Lider_Ministerio>();
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    List<modelocrud> modelos = new List<modelocrud>();
                    while (dr.Read())
                    {
                        Lider_Ministerio m = new Lider_Ministerio();
                        m.IdMinisterio = int.Parse(dr["IdMinisterio"].ToString());
                        modelos.Add(m);
                    }
                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);

                    foreach (var m in modelos)
                    {
                        var cel = (Lider_Ministerio)m;
                        var c = new Lider_Ministerio();
                        if (c.recuperar(cel.IdMinisterio))
                            lideresMinisterio.Add(c); // não deu erro de conexao
                        else
                        {
                            lideresMinisterio = null;
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            lideresMinisterio = null;
            return false;

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
