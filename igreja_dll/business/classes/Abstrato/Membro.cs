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
using business.classes.Pessoas;

namespace business.classes.Abstrato
{

    [Table("Membro")]
    public abstract class Membro : PessoaDado
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

        public Membro() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro set Data_batismo='{Data_batismo}', " +
            $" Desligamento='{Desligamento.ToString()}', Motivo_desligamento='{Motivo_desligamento}' where Id='{id}'";
            
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Membro where Id='{id}' " + base.excluir(id);

            
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)

        {
            Select_padrao = "select * from Membro as P ";
            if (id != null) Select_padrao += $" where P.IdPessoa='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            
            if (id != null)
            {
                base.recuperar(id);
                Select_padrao = "select * from Membro as P ";
                if (id != null) Select_padrao += $" where P.IdPessoa='{id}'";
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                    dr.Read();
                    this.Data_batismo = int.Parse(dr["Data_batismo"].ToString());
                    this.Desligamento = Convert.ToBoolean(dr["Desligamento"]);
                    this.Motivo_desligamento = Convert.ToString(dr["Motivo_desligamento"]);
                    dr.Close();
                modelos.Add(this);
                
            }
            return modelos;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Membro (Data_batismo, Desligamento, Motivo_desligamento, IdPessoa) values" +
            $" ('{this.Data_batismo}', '{this.Desligamento}', '{this.Motivo_desligamento}', IDENT_CURRENT('Pessoa'))";
            
            return Insert_padrao;
        }    
        
    }
}
