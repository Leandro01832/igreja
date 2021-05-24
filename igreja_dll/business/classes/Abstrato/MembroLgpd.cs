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
using business.classes.Pessoas;
using business.classes.PessoasLgpd;

namespace business.classes.Abstrato
{

    [Table("MembroLgpd")]
    public abstract class MembroLgpd : PessoaLgpd
    {        
        
        private int data_batismo;
        private bool desligamento;

        [Display(Name = "Ano de batismo")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_batismo
        {
            get
            {
                return data_batismo;
            }

            set
            {
                data_batismo = value;
            }
        }

        public bool Desligamento
        {
            get
            {
                return desligamento;
            }

            set
            {
                desligamento = value;
            }
        }

        public bool Save()
        {
            return true;
        }

        public string Motivo_desligamento { get; set; }

        public MembroLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update MembroLgpd set Data_batismo='{Data_batismo}', " +
            $" Desligamento='{Desligamento.ToString()}', Motivo_desligamento='{Motivo_desligamento}' where IdPessoa='{id}'";
            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from MembroLgpd where IdPessoa='{id}' " + base.excluir(id);

            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from MembroLgpd as P ";
            if (id != null) Select_padrao += $" where P.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                bd.obterconexao().Close();
                base.recuperar(id);
                bd.obterconexao().Open();
                Select_padrao = "select * from MembroLgpd as P ";
                if (id != null) Select_padrao += $" where P.IdPessoa='{id}'";
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    dr.Read();
                    this.Data_batismo = int.Parse(dr["Data_batismo"].ToString());
                    this.Desligamento = Convert.ToBoolean(dr["Desligamento"]);
                    this.Motivo_desligamento = Convert.ToString(dr["Motivo_desligamento"]);
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
            bd.obterconexao().Close();
            return modelos;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into MembroLgpd (Data_batismo, Desligamento, Motivo_desligamento, IdPessoa) values" +
                $" ('{this.Data_batismo}', '{this.Desligamento}', '{this.Motivo_desligamento}', IDENT_CURRENT('Pessoa'))";
            
            return Insert_padrao;
        }
    }
}
