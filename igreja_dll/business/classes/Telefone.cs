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

using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;
using Newtonsoft.Json;

namespace business.classes
{

    public class Telefone : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual PessoaDado Pessoa { get; set; }

        public string Fone { get; set; }

        public string Celular { get; set; }

        public string Whatsapp { get; set; }

        [NotMapped]
        public static List<Telefone> Telefones { get; set; }

        public Telefone()
        {
        }

        public Telefone(int id) : base(id)
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
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if(conexao != null)
            {
                try
                {
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    dr.Read();
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
                    this.Fone = Convert.ToString(dr["Fone"]);
                    this.Celular = Convert.ToString(dr["Celular"]);
                    this.Whatsapp = Convert.ToString(dr["Whatsapp"]);
                    dr.Close();
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
        
        public override string salvar()
        {
            Insert_padrao =
            $" insert into Telefone (Fone, Celular, Whatsapp, Id) " +
            $" values ('{Fone}', '{Celular}', '{Whatsapp}', IDENT_CURRENT('Pessoa')) ";
            return Insert_padrao;
        }

    }
}
