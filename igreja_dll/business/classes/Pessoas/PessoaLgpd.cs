using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : Pessoa 
    {
        public PessoaLgpd() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();            
        }

        AddNalista AddNalista;

        private MudancaEstado MudancaEstado;

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into PessoaLgpd (IdPessoa) values (IDENT_CURRENT('Pessoa')) ";            
            
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete PessoaLgpd from PessoaLgpd as PL where PL.IdPessoa='{id}' " 
            + base.excluir(id);            
            
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from PessoaLgpd as PL ";
            if (id != null) Select_padrao += $" where PL.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();            

            if (id != null)
            {
                bd.obterconexao().Close();
                base.recuperar(id);
                bd.obterconexao().Open();
                Select_padrao = "select * from PessoaLgpd as PL ";
                if (id != null) Select_padrao += $" where PL.IdPessoa='{id}'";
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    modelos.Add(this);
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

            bd.obterconexao().Close();

            return modelos;
        }
    }
}
