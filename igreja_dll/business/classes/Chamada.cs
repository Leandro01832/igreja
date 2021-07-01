using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes
{
    public class Chamada : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public int IdChamada { get; set; }

        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_inicio { get; set; }

        [Display(Name = "Numero da chamada")]
        public int Numero_chamada { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        [NotMapped]
        public static List<Chamada> Chamadas { get; set; }

        public Chamada()
        {
            Data_inicio = DateTime.Now;
            Numero_chamada = 0;

        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Chamada set Data_inicio={Data_inicio.ToString()},"
               + $" Numero_chamada={Numero_chamada} where IdChamada={id} ";
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Chamada where IdChamada={id} ";
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            Select_padrao = $"select * from Chamada as C where C.IdChamada='{id}'";
            var conexao = bd.obterconexao();

            if(conexao != null)
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

                    dr.Read();
                    this.Data_inicio = Convert.ToDateTime(Convert.ToString(dr["Data_inicio"]));
                    this.IdChamada = int.Parse(Convert.ToString(dr["IdChamada"]));
                    this.Numero_chamada = int.Parse(Convert.ToString(dr["Numero_chamada"]));
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
            return false;
        }

        public override bool recuperar()
        {
            Select_padrao = "select * from Chamada as C";
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                try
                {
                    Select_padrao = Select_padrao.Replace("*", "C.IdChamada");
                    Chamadas = new List<Chamada>();
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
                        Chamada ch = new Chamada();
                        ch.IdChamada = int.Parse(Convert.ToString(dr["IdChamada"]));
                        modelos.Add(ch);
                    }

                    dr.Close();

                    //Recursividade

                    foreach (var m in modelos)
                    {
                        var cel = (Chamada)m;
                        var c = new Chamada();
                        if (c.recuperar(cel.IdChamada))
                            Chamadas.Add(c); //não deu erro de conexao
                        else
                        {
                            Chamadas = null;
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

            Chamadas = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = $"insert into Chamada "
            + " (Data_inicio, Numero_chamada, IdChamada) values"
            + $" ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{Numero_chamada.ToString()}', IDENT_CURRENT('Pessoa'))";
            return Insert_padrao;
        }
    }
}
