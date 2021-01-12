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
using database;
using business.classes.Abstrato;

namespace business.classes.PessoasLgpd
{
    [Table("Membro_AclamacaoLgpd")]
    public class Membro_AclamacaoLgpd : MembroLgpd
    {

        private string denominacao;

        [Display(Name = "Denominação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Denominacao
        {
            get
            {
                return denominacao;
            }

            set
            {
                if(value != "")
                denominacao = value;
                else
                {
                    MessageBox.Show("denominação precisa ser preenchido corretamente");
                    denominacao = null;
                }
            }
        }
        
       public Membro_AclamacaoLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_AclamacaoLgpd set Denominacao='{Denominacao}' " +
            $" where Id='{id}' " + BDcomum.addNaLista;
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_AclamacaoLgpd as MA "
            + " inner join MembroLgpd as M on MA.Id=M.Id "
            + " inner join PessoaLgpd as PL on M.Id=PL.Id inner join Pessoa as P on PL.Id=P.Id";
            if (id != null) Select_padrao += $" where MA.Id='{id}'";

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
                base.recuperar(id);
                try
                {
                    dr.Read();
                    this.Denominacao = Convert.ToString(dr["Denominacao"]);
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
                        Membro_AclamacaoLgpd ma = new Membro_AclamacaoLgpd();
                        ma.Id = int.Parse(Convert.ToString(dr["Id"]));
                        ma.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        ma.Email = Convert.ToString(dr["Email"]);
                        modelos.Add(ma);
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
            Insert_padrao += " insert into Membro_aclamacaoLgpd (Denominacao, Id) " +
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
