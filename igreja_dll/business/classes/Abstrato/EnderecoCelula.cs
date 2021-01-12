using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Celula
{
    public class EnderecoCelula    : modelocrud
    {
        private string pais;
        private string estado;
        private string cidade;
        private string bairro;
        private string rua;
        private int numero_casa;
        private long cep;
        private string complemento;

        [Key, ForeignKey("Celula")]
        public new int Id { get; set; }
        public virtual Abstrato.Celula Celula { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {

                pais = value;

            }
        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                if (value != "")
                    estado = value;
                else
                {
                    MessageBox.Show("Estado precisa ser preenchido corretamente!!!");
                    estado = null;
                }
            }
        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                if (value != "")
                    cidade = value;
                else
                {
                    MessageBox.Show("cidade precisa ser preenchido corretamente!!!");
                    cidade = null;
                }
            }

        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Bairro
        {
            get
            {
                return bairro;
            }

            set
            {
                if (value != "")
                    bairro = value;
                else
                {
                    MessageBox.Show("bairro precisa ser preenchido corretamente!!!");
                    bairro = null;
                }
            }
        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rua
        {
            get
            {
                return rua;
            }

            set
            {
                if (value != "")
                    rua = value;
                else
                {
                    MessageBox.Show("rua precisa ser preenchido corretamente!!!");
                    rua = null;
                }
            }
        }

        [Display(Name = "Numero da casa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Numero_casa
        {
            get
            {
                return numero_casa;
            }

            set
            {
                if (value != 0)
                    numero_casa = value;
                else
                {
                    MessageBox.Show("numero da casa precisa ser preenchido corretamente!!!");
                    numero_casa = 0;
                }
            }
        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public long Cep
        {
            get
            {
                return cep;
            }

            set
            {
                if (value != 0)
                    cep = value;
                else
                {
                    MessageBox.Show("Cep precisa ser preenchido corretamente!!!");
                    cep = 0;
                }
            }
        }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Complemento
        {
            get
            {
                return complemento;
            }

            set
            {
                complemento = value;
            }
        }

        public EnderecoCelula() : base()
        {
        }

        public override string salvar()
        {
            Insert_padrao =
        $"insert into EnderecoCelula (Pais, Estado, Cidade, Bairro, Rua, Numero_casa, Cep, Complemento, " +
        $" Id) values ('{this.Pais}', '{Estado}', '{Cidade}', '{Bairro}', '{Rua}', '{Numero_casa}', " +
        $" '{Cep}', '{Complemento}', IDENT_CURRENT('Celula'))";
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update EnderecoCelula set Pais='{Pais}', Estado='{Estado}', Complemento='{Complemento}', " +
            $"Cidade='{Cidade}',Bairro='{Bairro}', Rua='{Rua}', Numero_casa='{Numero_casa}', Cep='{Cep}' " +
            $"  where Id='{id}' ";
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from EnderecoCelula where Id={id} ";
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from EnderecoCelula as M";
            if (id != null)
                Select_padrao += $" where M.Id={id}";

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
                            this.Pais = Convert.ToString(dr["Pais"]);
                            this.Estado = Convert.ToString(dr["Estado"]);
                            this.Cidade = Convert.ToString(dr["Cidade"]);
                            this.Bairro = Convert.ToString(dr["Bairro"]);
                            this.Complemento = Convert.ToString(dr["Complemento"]);
                            this.Id = int.Parse(Convert.ToString(dr["Id"]));
                            this.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                            this.Cep = long.Parse(Convert.ToString(dr["Cep"]));
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

    }

}