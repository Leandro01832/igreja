using database.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using database;
using business.classes.Abstrato;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_AclamacaoLgpd")]
    public class Membro_AclamacaoLgpd : MembroLgpd
    {

        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Denominacao { get; set; }

        public Membro_AclamacaoLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_AclamacaoLgpd set Denominacao='{Denominacao}' " +
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
            Select_padrao = "select * from Membro_AclamacaoLgpd as MA "
            + " inner join MembroLgpd as M on MA.IdPessoa=M.IdPessoa "
            + " inner join PessoaLgpd as PL on M.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa";
            if (id != null) Select_padrao += $" where MA.IdPessoa='{id}'";

            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {
                        Select_padrao = "select * from Membro_AclamacaoLgpd as MA "
                   + " inner join MembroLgpd as M on MA.IdPessoa=M.IdPessoa "
                   + " inner join PessoaLgpd as PL on M.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa";
                        if (id != null) Select_padrao += $" where MA.IdPessoa='{id}'";
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
                        this.Denominacao = Convert.ToString(dr["Denominacao"]);
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
                        membros_AclamacaoLgpd = new List<Membro_AclamacaoLgpd>();
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
                            Membro_AclamacaoLgpd ma = new Membro_AclamacaoLgpd();
                            ma.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(ma);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        
                        foreach (var m in modelos)
                        {
                            var cel = (Membro_AclamacaoLgpd)m;
                            var c = new Membro_AclamacaoLgpd();
                            if(c.recuperar(cel.IdPessoa))
                                membros_AclamacaoLgpd.Add(c); // não deu erro de conexao
                            else
                            {
                                membros_AclamacaoLgpd = null;
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
                membros_AclamacaoLgpd = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_aclamacaoLgpd (Denominacao, IdPessoa) " +
                $" values ('{Denominacao}', IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}
