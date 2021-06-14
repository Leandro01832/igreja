using database.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using database;
using business.classes.Abstrato;
using business.classes.Ministerio;
using business.classes.Pessoas;

namespace business.classes.PessoasLgpd
{
    [Table("CriancaLgpd")]
    public class CriancaLgpd : PessoaLgpd
    {

        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_pai { get; set; }

        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae { get; set; }

        public CriancaLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update CriancaLgpd set Nome_pai='{Nome_pai}', Nome_mae='{Nome_mae}' " +
                $" where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from CriancaLgpd as C "
             + " inner join PessoaLgpd as PL on C.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where C.IdPessoa='{id}'";

            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {


                        Select_padrao = "select * from CriancaLgpd as C "
                     + " inner join PessoaLgpd as PL on C.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where C.IdPessoa='{id}'";
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
                        this.Nome_mae = Convert.ToString(dr["Nome_mae"]);
                        this.Nome_pai = Convert.ToString(dr["Nome_pai"]);
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
                            CriancaLgpd crianca = new CriancaLgpd();
                            crianca.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(crianca);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        criancasLgpd = new List<CriancaLgpd>();
                        foreach (var m in modelos)
                        {
                            var cel = (CriancaLgpd)m;
                            var c = new CriancaLgpd();
                            if(c.recuperar(cel.IdPessoa))
                                criancasLgpd.Add(c); // não deu erro de conexao
                            else
                            {
                                criancasLgpd = null;
                                break;
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
                criancasLgpd = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into CriancaLgpd (Nome_pai, Nome_mae, IdPessoa) values" +
                $" ('{Nome_pai}', '{Nome_mae}', IDENT_CURRENT('Pessoa')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}
