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

namespace business.classes.Pessoas
{
    [Table("Membro_Aclamacao")]
    public class Membro_Aclamacao : Membro
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
        

       public Membro_Aclamacao() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_Aclamacao set Denominacao='{Denominacao}' " +
            $" where Id='{id}' ";
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro_Aclamacao where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Membro_Aclamacao as MA "
            + " inner join Membro as M on MA.Id=M.Id "
            + " inner join PessoaDado as PD on M.Id=PD.Id inner join Pessoa as P on PD.Id=P.Id ";
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
                        Membro_Aclamacao ma = new Membro_Aclamacao();
                        ma.Id = int.Parse(Convert.ToString(dr["Id"]));
                        ma.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        ma.Nome = Convert.ToString(dr["Nome"]);
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
            Insert_padrao += " insert into Membro_aclamacao (Denominacao, Id) " +
                $" values ('{Denominacao}', IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }

        
    }
}
