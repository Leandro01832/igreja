using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using database.banco;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes
{
    
    public class Endereco : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public int IdEndereco { get; set; }
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

        public Endereco()
        {
        }

        public override string salvar()
        {
            Insert_padrao =
        $"insert into Endereco (Pais, Estado, Cidade, Bairro, Rua, Numero_casa, Cep, Complemento, " +
        $" IdEndereco) values ('{this.Pais}', '{Estado}', '{Cidade}', '{Bairro}', '{Rua}', '{Numero_casa}', " +
        $" '{Cep}', '{Complemento}', IDENT_CURRENT('Pessoa'))";            
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Endereco set Pais='{Pais}', Estado='{Estado}', Complemento='{Complemento}', " +
            $"Cidade='{Cidade}',Bairro='{Bairro}', Rua='{Rua}', Numero_casa='{Numero_casa}', Cep='{Cep}' " +
            $"  where IdEndereco='{id}' ";            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Endereco where IdEndereco='{id}' ";            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Endereco as M";
            if (id != null)
                Select_padrao += $" where M.IdEndereco='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                try
                {
                    dr.Read();
                    this.Pais = Convert.ToString(dr["Pais"]);
                    this.Estado = Convert.ToString(dr["Estado"]);
                    this.Cidade = Convert.ToString(dr["Cidade"]);
                    this.Bairro = Convert.ToString(dr["Bairro"]);
                    this.Complemento = Convert.ToString(dr["Complemento"]);
                    this.IdEndereco = int.Parse(Convert.ToString(dr["IdEndereco"]));
                    this.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                    this.Cep = long.Parse(Convert.ToString(dr["Cep"]));

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
                try
                {
                    while (dr.Read())
                    {
                        Endereco end = new Endereco();
                        end.Pais = Convert.ToString(dr["Pais"]);
                        end.Estado = Convert.ToString(dr["Estado"]);
                        end.Cidade = Convert.ToString(dr["Cidade"]);
                        end.Bairro = Convert.ToString(dr["Bairro"]);
                        end.Complemento = Convert.ToString(dr["Complemento"]);
                        end.IdEndereco = int.Parse(Convert.ToString(dr["IdEndereco"]));
                        end.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                        end.Cep = long.Parse(Convert.ToString(dr["Cep"]));
                        modelos.Add(end);
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







}
