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

namespace business.classes.Pessoas
{
    [Table("Crianca")]
    public class Crianca : Pessoa
    {

        private string nome_pai;
        private string nome_mae;

        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_pai
        {
            get
            {
                return nome_pai;
            }

            set
            {
                if(value != "")
                nome_pai = value;
                else
                {
                    MessageBox.Show("informe o nome do pai");
                }
            }
        }

        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae
        {
            get
            {
                return nome_mae;
            }

            set
            {
                if(value != "")
                nome_mae = value;
                else
                {
                    MessageBox.Show("informe o nome da mãe");
                    nome_mae = null;
                }
            }
        }

        

        public Crianca() : base()
        {
        }

        public Crianca(int id, bool recuperaLista) : base(id, recuperaLista)
        {

        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Crianca set Nome_pai='{Nome_pai}', Nome_mae='{Nome_mae}' " +
                $" where Id='{id}' ";
            
            bd.Editar(this);
            return Update_padrao;
        }      

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Crianca where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Crianca as C "
             + " inner join Pessoa as P on C.Id=P.Id ";
            if (id != null) Select_padrao += $" where C.Id='{id}'";

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
                        Crianca crianca = new Crianca();
                        crianca.Id = int.Parse(Convert.ToString(dr["Id"]));
                        crianca.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        crianca.Nome = Convert.ToString(dr["Nome"]);                                                
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
            Insert_padrao += " insert into Crianca (Nome_pai, Nome_mae, Id) values" +
                $" ('{Nome_pai}', '{Nome_mae}', IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }
        
    }
}
