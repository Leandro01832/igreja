using business.classes.Abstrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.PessoasLgpd
{
    [Table("Membro_TransferenciaLgpd")]
    public class Membro_TransferenciaLgpd : MembroLgpd
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

        public Membro_TransferenciaLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_TransferenciaLgpd set nome_igreja_transferencia='{Nome_igreja_transferencia}', " +
            $" Estado_transferencia='{Estado_transferencia}', Nome_cidade_transferencia='{Nome_cidade_transferencia}' " +
            $"  where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_TransferenciaLgpd as MT "
            + " inner join MembroLgpd as M on MT.IdPessoa=M.IdPessoa "
            + " inner join PessoaLgpd as PL on M.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where MT.IdPessoa='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {


                        Select_padrao = "select * from Membro_TransferenciaLgpd as MT "
                   + " inner join MembroLgpd as M on MT.IdPessoa=M.IdPessoa "
                   + " inner join PessoaLgpd as PL on M.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where MT.IdPessoa='{id}' ";
                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return modelos;
                        }
                        base.recuperar(id);
                        dr.Read();
                        this.Nome_cidade_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
                        this.Estado_transferencia = Convert.ToString(dr["Estado_transferencia"]);
                        this.Nome_igreja_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
                        dr.Close();
                        modelos.Add(this);
                    }
                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }
                    return modelos;
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
                            return modelos;
                        }

                        while (dr.Read())
                        {
                            Membro_TransferenciaLgpd mt = new Membro_TransferenciaLgpd();
                            mt.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(mt);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        List<modelocrud> lista = new List<modelocrud>();
                        foreach (var m in modelos)
                        {
                            var cel = (Membro_TransferenciaLgpd)m;
                            var c = new Membro_TransferenciaLgpd();
                            c = (Membro_TransferenciaLgpd)m.recuperar(cel.IdPessoa)[0];
                            lista.Add(c);
                        }
                        modelos.Clear();
                        modelos.AddRange(lista);
                    }
                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }
                    return modelos;
                } 
            }
            if (id == null)
                Pessoa.membros_TransferenciaLgpd = null;
            return modelos;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_transferenciaLgpd (Nome_cidade_transferencia, " +
              " Estado_transferencia, Nome_igreja_transferencia, IdPessoa) " +
              $" values ('{Nome_cidade_transferencia}', '{Estado_transferencia}', '{Nome_igreja_transferencia}', " +
              " IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}
