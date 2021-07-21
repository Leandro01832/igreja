using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;


namespace business.classes.Ministerio
{
    [Table("Supervisor_Celula_Treinamento")]
    public class Supervisor_Celula_Treinamento : Abstrato.Ministerio
    {

        [Display(Name = "Máximo de celulas para supervisioar")]
        public int Maximo_celula { get; set; }

        public Supervisor_Celula_Treinamento() : base()
        {
            this.Maximo_celula = 5;
        }

        public Supervisor_Celula_Treinamento(int m) : base(m) { }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update  Supervisor_Celula_Treinamento " +
                $" set Maximo_celula='{Maximo_celula}' where Id='{id}' " + BDcomum.addNaLista;
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
                    this.Maximo_celula = int.Parse(dr["Maximo_celula"].ToString());
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
            Insert_padrao += $" insert into Supervisor_Celula_Treinamento " +
           $" (Id, Maximo_celula) values (IDENT_CURRENT('Ministerio'), '{Maximo_celula}')" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;

        }

        public override string ToString()
        {
            return base.Id.ToString() + " - " + base.Nome;
        }

    }
}
