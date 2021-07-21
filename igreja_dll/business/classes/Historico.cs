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
using Newtonsoft.Json;

namespace business.classes
{
    [Table("Historico")]
    public class Historico : modelocrud
    {

        public DateTime Data_inicio { get; set; }

        public int pessoaid { get; set; }

        [ForeignKey("pessoaid")]
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        public int Falta { get; set; }

        [NotMapped]
        public static List<Historico> Historicos { get; set; }

        public Historico() : base()
        {
        }

        public Historico(int id) : base(id)
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Historico set Data_inicio={Data_inicio.ToString()}, " +
            $"pessoaid={pessoaid}, Falta={Falta} " +
            $"  where Id={id} ";

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Historico where Id='{id}' ";

            bd.Excluir(this);
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
                    this.Data_inicio = Convert.ToDateTime(dr["Data_inicio"].ToString());
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
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            return false;
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
