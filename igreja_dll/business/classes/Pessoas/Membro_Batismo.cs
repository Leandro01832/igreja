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

        public Membro_Batismo(int id, bool recuperaLista) : base(id, recuperaLista)
        {

        }
        
        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Batismo where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        
        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Batismo as MB "
                + " inner join Membro as M on MB.Id=M.Id "
                + " inner join Pessoa as P on M.Id=P.Id ";
            if (id != null) Select_padrao += $" where MB.Id='{id}'";

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
                modelos.Add(this);
                return modelos;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Membro_Batismo mb = new Membro_Batismo();
                        mb.Id = int.Parse(Convert.ToString(dr["Id"]));
                        mb.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        mb.Nome = Convert.ToString(dr["Nome"]);                        
                        modelos.Add(mb);
                    }
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

                return modelos;
            }
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro_Batismo (Id) values (IDENT_CURRENT('Pessoa')) " + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }

    }
}
