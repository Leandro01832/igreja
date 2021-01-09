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
    [Table("Membro_ReconciliacaoLgpd")]
    public class Membro_ReconciliacaoLgpd : MembroLgpd
    {        
        private int data_reconciliacao;

        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao
        {
            get
            {
                return data_reconciliacao;
            }

            set
            {
                if(value != 0)
                data_reconciliacao = value;
                else
                {
                    MessageBox.Show("O ano de reconciliação deve ser preenchido corretamente");
                    data_reconciliacao = 0;
                }
            }
        }
        
        public Membro_ReconciliacaoLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_ReconciliacaoLgpd set Data_reconciliacao='{Data_reconciliacao}' " +
            $" where Id='{id}' ";
            
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
            Select_padrao = "select * from Membro_ReconciliacaoLgpd as MR "
            + " inner join MembroLgpd as M on MR.Id=M.Id "
            + " inner join PessoaLgpd as PL on M.Id=PL.Id inner join Pessoa as P on PL.Id=P.Id ";
            if (id != null) Select_padrao += $" where MR.Id='{id}' ";

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
                    this.Data_reconciliacao = int.Parse(dr["Data_reconciliacao"].ToString());                    
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
                        Membro_ReconciliacaoLgpd mr = new Membro_ReconciliacaoLgpd();
                        mr.Id = int.Parse(Convert.ToString(dr["Id"]));
                        mr.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        mr.Email = Convert.ToString(dr["Email"]);                        
                        modelos.Add(mr);
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
            Insert_padrao += " insert into Membro_ReconciliacaoLgpd (Data_reconciliacao, Id) " +
                $" values ({Data_reconciliacao}, IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}
