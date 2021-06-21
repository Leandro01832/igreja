using System;
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
        public int IdTelefone { get; set; }
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

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Telefone as M";
            if (id != null)
                Select_padrao += Select_padrao + $" where M.IdTelefone={id}";

            
            var conexao = bd.obterconexao();

            if (id != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        return false;
                    }

                    dr.Read();
                    this.IdTelefone = int.Parse(Convert.ToString(dr["IdTelefone"]));
                    this.Fone = Convert.ToString(dr["Fone"]);
                    this.Celular = Convert.ToString(dr["Celular"]);
                    this.Whatsapp = Convert.ToString(dr["Whatsapp"]);
                    dr.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                
                return true;
            }
            else
            {
                try
                {
                    Telefones = new List<Telefone>();
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        return false;
                    }

                    List<modelocrud> modelos = new List<modelocrud>();
                    while (dr.Read())
                    {
                        Telefone tel = new Telefone();
                        tel.IdTelefone = int.Parse(Convert.ToString(dr["IdTelefone"]));
                        modelos.Add(tel);
                    }

                    dr.Close();

                    //Recursividade
                    bd.fecharconexao(conexao);

                    
                    foreach (var m in modelos)
                    {
                        var cel = (Telefone)m;
                        var c = new Telefone();
                        if(c.recuperar(cel.IdTelefone))
                        Telefones.Add(c); //não deu erro de conexao
                        else
                        {
                            Telefones = null;
                            return false;
                        }
                    }
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
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
