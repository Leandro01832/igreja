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

namespace business.classes
{
       
    public class Telefone : modelocrud
    {
        
        private string fone;
        private string celular;
        private string whatsapp;
        private Pessoa pessoa;

        [Key, ForeignKey("Pessoa")]
        public new int Id {  get; set; }
        public virtual Pessoa Pessoa
        {
            get
            {
                return pessoa;
            }

            set
            {
                pessoa = value;
            }
        }

        public string Fone
        {
            get
            {
                return fone;
            }

            set
            {
                fone = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Whatsapp
        {
            get
            {
                return whatsapp;
            }

            set
            {
                whatsapp = value;
            }
        }

        public Telefone()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Telefone set Fone='{Fone}', Celular='{Celular}', " +
            $"Whatsapp='{Whatsapp}' where Id='{id}' ";            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Telefone where Id='{id}' ";            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Telefone as M";
            if (id != null)
                Select_padrao += Select_padrao + $" where M.Id={id}";

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
                        this.Id = int.Parse(Convert.ToString(dr["Id"]));
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
                            this.Id = int.Parse(Convert.ToString(dr["Id"]));
                            this.Fone = Convert.ToString(dr["Fone"]);
                            this.Celular = Convert.ToString(dr["Celular"]);
                            this.Whatsapp = Convert.ToString(dr["Whatsapp"]);
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
            Insert_padrao =
        $" insert into Telefone (Fone, Celular, Whatsapp, Id) " +
        $" values ('{Fone}', '{Celular}', '{Whatsapp}', IDENT_CURRENT('Pessoa')) ";            
            return Insert_padrao;
        }

    }
}