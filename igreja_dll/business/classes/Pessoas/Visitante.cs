using database.banco;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections.Generic;
using database;
using business.classes.Abstrato;

namespace business.classes.Pessoas
{
    [Table("Visitante")]
    public class Visitante : PessoaDado
    {

        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita { get; set; }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa { get; set; }


        public Visitante() : base()
        {
        }

        public Visitante(int m) : base(m){ }

    public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Visitante set Data_visita='{Data_visita.ToString("yyyy-MM-dd")}', " +
            $"Condicao_religiosa='{Condicao_religiosa}' " +
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
                    this.Data_visita = Convert.ToDateTime(Convert.ToString(dr["Data_visita"]));
                    this.Condicao_religiosa = Convert.ToString(dr["Condicao_religiosa"]);
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
            Insert_padrao += $" insert into Visitante (Data_visita, Condicao_religiosa, Id) " +
            $" values ('{this.Data_visita.ToString("yyyy-MM-dd")}', '{Condicao_religiosa}', IDENT_CURRENT('Pessoa'))"
            + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
