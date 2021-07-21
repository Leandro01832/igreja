using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using database.banco;
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

    public class Endereco : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual PessoaDado Pessoa { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rua { get; set; }

        [Display(Name = "Numero da casa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Numero_casa { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public long Cep { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Complemento { get; set; }

        [NotMapped]
        public static List<Endereco> Enderecos { get; set; }

        public Endereco()
        {
        }

        public Endereco(int id) : base(id)
        {
        }

        public override string salvar()
        {
            Insert_padrao =
        $"insert into Endereco (Pais, Estado, Cidade, Bairro, Rua, Numero_casa, Cep, Complemento, " +
        $" Id) values ('{this.Pais}', '{Estado}', '{Cidade}', '{Bairro}', '{Rua}', '{Numero_casa}', " +
        $" '{Cep}', '{Complemento}', IDENT_CURRENT('Pessoa'))";
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Endereco set Pais='{Pais}', Estado='{Estado}', Complemento='{Complemento}', " +
            $"Cidade='{Cidade}',Bairro='{Bairro}', Rua='{Rua}', Numero_casa='{Numero_casa}', Cep='{Cep}' " +
            $"  where Id='{id}' ";
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Endereco where Id='{id}' ";
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
                        return false;
                    }

                    dr.Read();
                    this.Pais = Convert.ToString(dr["Pais"]);
                    this.Estado = Convert.ToString(dr["Estado"]);
                    this.Cidade = Convert.ToString(dr["Cidade"]);
                    this.Bairro = Convert.ToString(dr["Bairro"]);
                    this.Complemento = Convert.ToString(dr["Complemento"]);
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
                    this.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                    this.Cep = long.Parse(Convert.ToString(dr["Cep"]));

                    dr.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
                return true;
            }
            return false;
        }
        
    }
}
