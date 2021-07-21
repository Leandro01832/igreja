using database.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using database;
using business.classes.Abstrato;
using business.classes.Ministerio;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("Crianca")]
    public class Crianca : PessoaDado
    {

        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_pai { get; set; }

        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae { get; set; }

        public Crianca() : base()
        {
        }

        public Crianca(int m) : base(m) { }

        public override string alterar(int id)
        {
            
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Crianca set Nome_pai='{Nome_pai}', Nome_mae='{Nome_mae}' " +
                $" where Id='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao += base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if (conexao != null)
            {
                try
                {
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }
                    dr.Read();
                    this.Nome_mae = Convert.ToString(dr["Nome_mae"]);
                    this.Nome_pai = Convert.ToString(dr["Nome_pai"]);
                    dr.Close();
                    base.recuperar(id);
                }

                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
            return false;
        }
        
        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into Crianca (Nome_pai, Nome_mae, Id) values" +
                $" ('{Nome_pai}', '{Nome_mae}', IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }
    }
}
