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
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("Membro_Reconciliacao")]
    public class Membro_Reconciliacao : Membro
    {

        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao { get; set; }

        public Membro_Reconciliacao() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_Reconciliacao set Data_reconciliacao='{Data_reconciliacao}' " +
            $" where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Reconciliacao where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Reconciliacao as MR "
            + " inner join Membro as M on MR.IdPessoa=M.IdPessoa "
            + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where MR.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {


                        Select_padrao = "select * from Membro_Reconciliacao as MR "
                    + " inner join Membro as M on MR.IdPessoa=M.IdPessoa "
                    + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where MR.IdPessoa='{id}'";
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
                        this.Data_reconciliacao = int.Parse(dr["Data_reconciliacao"].ToString());
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
                            Membro_Reconciliacao mr = new Membro_Reconciliacao();
                            mr.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(mr);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        List<modelocrud> lista = new List<modelocrud>();
                        foreach (var m in modelos)
                        {
                            var cel = (Membro_Reconciliacao)m;
                            var c = new Membro_Reconciliacao();
                            c = (Membro_Reconciliacao)m.recuperar(cel.IdPessoa)[0];
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
                Pessoa.membros_Reconciliacao = null;
            return modelos;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_Reconciliacao (Data_reconciliacao, IdPessoa) " +
                $" values ({Data_reconciliacao}, IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
