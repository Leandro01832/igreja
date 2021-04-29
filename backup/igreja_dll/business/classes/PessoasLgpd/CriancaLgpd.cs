using database.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from CriancaLgpd as C "
             + " inner join PessoaLgpd as PL on C.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where C.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                base.recuperar(id);
                try
                {
                    dr.Read();                    
                    this.Nome_mae = Convert.ToString(dr["Nome_mae"]);
                    this.Nome_pai = Convert.ToString(dr["Nome_pai"]);                    
                    dr.Close();
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
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        CriancaLgpd crianca = new CriancaLgpd();
                        crianca.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                        crianca.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        crianca.Email = Convert.ToString(dr["Email"]);                                                
                        modelos.Add(crianca);
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
