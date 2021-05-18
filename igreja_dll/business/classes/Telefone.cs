﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using database.banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes
{
       
    public class Telefone : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public int IdTelefone {  get; set; }
        public virtual PessoaDado Pessoa { get; set; }

        public string Fone { get; set; }

        public string Celular { get; set; }

        public string Whatsapp { get; set; }

        public Telefone()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Telefone set Fone='{Fone}', Celular='{Celular}', " +
            $"Whatsapp='{Whatsapp}' where IdTelefone='{id}' ";            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Telefone where IdTelefone='{id}' ";            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Telefone as M";
            if (id != null)
                Select_padrao += Select_padrao + $" where M.IdTelefone={id}";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
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
                    dr.Read();
                    this.IdTelefone = int.Parse(Convert.ToString(dr["IdTelefone"]));
                    this.Fone = Convert.ToString(dr["Fone"]);
                    this.Celular = Convert.ToString(dr["Celular"]);
                    this.Whatsapp = Convert.ToString(dr["Whatsapp"]);
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
                        Telefone tel = new Telefone();
                        tel.IdTelefone = int.Parse(Convert.ToString(dr["IdTelefone"]));
                        modelos.Add(tel);
                    }

                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Telefone)m;
                        var c = new Telefone();
                        c = (Telefone)m.recuperar(cel.IdTelefone)[0];
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
            Insert_padrao =
        $" insert into Telefone (Fone, Celular, Whatsapp, IdTelefone) " +
        $" values ('{Fone}', '{Celular}', '{Whatsapp}', IDENT_CURRENT('Pessoa')) ";            
            return Insert_padrao;
        }

    }
}
