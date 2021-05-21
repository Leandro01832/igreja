using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;
using database;
using business.classes.Abstrato;

namespace business.classes.Pessoas
{
    [Table("Membro_Batismo")]
    public class Membro_Batismo : Membro
    {
        public Membro_Batismo() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id) + BDcomum.addNaLista;
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Batismo where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }


        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Batismo as MB "
                + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();


            if (id != null)
            {
                bd.obterconexao().Close();
                base.recuperar(id);
                bd.obterconexao().Open();
                Select_padrao = "select * from Membro_Batismo as MB "
                + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                modelos.Add(this);

                bd.obterconexao().Close();
                return modelos;
            }
            else
            {
                try
                {
                    bd.obterconexao().Open();
                    Select_padrao = "select * from Membro_Batismo as MB "
                    + " inner join Membro as M on MB.IdPessoa=M.IdPessoa "
                    + " inner join PessoaDado as PD on M.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                    if (id != null) Select_padrao += $" where MB.IdPessoa='{id}'";
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        bd.obterconexao().Close();
                        return modelos;
                    }

                    while (dr.Read())
                    {
                        Membro_Batismo mb = new Membro_Batismo();
                        mb.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                        modelos.Add(mb);
                    }
                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (Membro_Batismo)m;
                        var c = new Membro_Batismo();
                        c = (Membro_Batismo)m.recuperar(cel.IdPessoa)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }

                return modelos;
            }
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_Batismo (IdPessoa) values (IDENT_CURRENT('Pessoa')) " + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
