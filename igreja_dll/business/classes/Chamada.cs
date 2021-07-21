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
        public new int Id { get; set; }
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

        public Chamada(int id) : base(id)
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
                    this.Data_inicio = Convert.ToDateTime(Convert.ToString(dr["Data_inicio"]));
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
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
        
        public override string salvar()
        {
            Insert_padrao = $"insert into Chamada "
            + " (Data_inicio, Numero_chamada, Id) values"
            + $" ('{DateTime.Now.ToString("yyyy-MM-dd")}', '{Numero_chamada.ToString()}', IDENT_CURRENT('Pessoa'))";
            return Insert_padrao;
        }
    }
}
