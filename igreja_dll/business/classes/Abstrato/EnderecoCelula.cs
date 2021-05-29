using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.Celula
{
    public class EnderecoCelula : modelocrud
    {       

        [Key, ForeignKey("Celula")]
        public int IdEnderecoCelula { get; set; }
        public virtual Abstrato.Celula Celula { get; set; }

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

        public EnderecoCelula() : base()
        {
        }

        public override string salvar()
        {
            Insert_padrao =
        $"insert into EnderecoCelula (Pais, Estado, Cidade, Bairro, Rua, Numero_casa, Cep, Complemento, " +
        $" IdEnderecoCelula) values ('{this.Pais}', '{Estado}', '{Cidade}', '{Bairro}', '{Rua}', '{Numero_casa}', " +
        $" '{Cep}', '{Complemento}', IDENT_CURRENT('Celula'))";
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update EnderecoCelula set Pais='{Pais}', Estado='{Estado}', Complemento='{Complemento}', " +
            $"Cidade='{Cidade}',Bairro='{Bairro}', Rua='{Rua}', Numero_casa='{Numero_casa}', Cep='{Cep}' " +
            $"  where IdEnderecoCelula='{id}' ";
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from EnderecoCelula where IdEnderecoCelula={id} ";
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from EnderecoCelula as M";
            if (id != null)
                Select_padrao += $" where M.IdEnderecoCelula={id}";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                try
                {
                    dr.Read();
                    this.Pais = Convert.ToString(dr["Pais"]);
                    this.Estado = Convert.ToString(dr["Estado"]);
                    this.Cidade = Convert.ToString(dr["Cidade"]);
                    this.Bairro = Convert.ToString(dr["Bairro"]);
                    this.Complemento = Convert.ToString(dr["Complemento"]);
                    this.IdEnderecoCelula = int.Parse(Convert.ToString(dr["IdEnderecoCelula"]));
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

                modelos.Add(this);
                return modelos;
            }
            else
            {
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        EnderecoCelula end = new EnderecoCelula();
                        end.Pais = Convert.ToString(dr["Pais"]);
                        end.Estado = Convert.ToString(dr["Estado"]);
                        end.Cidade = Convert.ToString(dr["Cidade"]);
                        end.Bairro = Convert.ToString(dr["Bairro"]);
                        end.Complemento = Convert.ToString(dr["Complemento"]);
                        end.IdEnderecoCelula = int.Parse(Convert.ToString(dr["IdEnderecoCelula"]));
                        end.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                        end.Cep = long.Parse(Convert.ToString(dr["Cep"]));
                        modelos.Add(end);
                    }

                    dr.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }

                return modelos;
            }

        }

    }

}