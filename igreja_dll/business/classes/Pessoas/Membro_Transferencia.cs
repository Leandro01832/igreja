using business.classes.Abstrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("Membro_Transferencia")]
    public class Membro_Transferencia : Membro
    {
        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_cidade_transferencia { get; set; }

        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_transferencia { get; set; }

        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_igreja_transferencia { get; set; }

        public Membro_Transferencia() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_Transferencia set Nome_igreja_transferencia='{Nome_igreja_transferencia}', " +
            $" Estado_transferencia='{Estado_transferencia}', Nome_cidade_transferencia='{Nome_cidade_transferencia}', " +
            $"  where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Transferencia where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Transferencia as MT ";
            if (id != null) Select_padrao += $" where MT.IdPessoa='{id}'";
            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
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
                        base.recuperar(id);
                        dr.Read();
                        this.Nome_cidade_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
                        this.Estado_transferencia = Convert.ToString(dr["Estado_transferencia"]);
                        this.Nome_igreja_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
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
                else
                {
                    try
                    {
                        Select_padrao = Select_padrao.Replace("*", "MT.IdPessoa");
                        membros_Transferencia = new List<Membro_Transferencia>();
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
                            Membro_Transferencia mt = new Membro_Transferencia();
                            mt.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(mt);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Membro_Transferencia)m;
                            var c = new Membro_Transferencia();
                            if(c.recuperar(cel.IdPessoa))
                                membros_Transferencia.Add(c); // não deu erro de conexao
                            else
                            {
                                membros_Transferencia = null;
                                return false;
                            }
                        }
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
            }
            if (id == null)
                membros_Transferencia = null;
            return false;

        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_transferencia (Nome_cidade_transferencia, " +
              " Estado_transferencia, Nome_igreja_transferencia, IdPessoa) " +
              $" values ('{Nome_cidade_transferencia}', '{Estado_transferencia}', '{Nome_igreja_transferencia}', " +
              " IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
