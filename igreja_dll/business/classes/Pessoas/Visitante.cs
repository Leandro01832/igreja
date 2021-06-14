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

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Visitante set Data_visita='{Data_visita.ToString("yyyy-MM-dd")}', " +
            $"Condicao_religiosa='{Condicao_religiosa}' " +
            $" where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Visitante where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from Visitante as V "
            + " inner join PessoaDado as PD on V.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where V.IdPessoa='{id}' ";
            
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {
                        Select_padrao = "select * from Visitante as V "
                    + " inner join PessoaDado as PD on V.IdPessoa=PD.IdPessoa inner join Pessoa as P on PD.IdPessoa=P.IdPessoa ";
                        if (id != null) Select_padrao += $" where V.IdPessoa='{id}' ";
                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return false;
                        }
                        base.recuperar(id);
                        dr.Read();
                        this.Data_visita = Convert.ToDateTime(Convert.ToString(dr["Data_visita"]));
                        this.Condicao_religiosa = Convert.ToString(dr["Condicao_religiosa"]);

                        dr.Close();
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
                else
                {
                    try
                    {

                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return false;
                        }

                        List<modelocrud> modelos = new List<modelocrud>();
                        while (dr.Read())
                        {
                            Visitante v = new Visitante();
                            v.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                            modelos.Add(v);
                        }
                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        visitantes = new List<Visitante>();
                        foreach (var m in modelos)
                        {
                            var cel = (Visitante)m;
                            var c = new Visitante();
                            if(c.recuperar(cel.IdPessoa))
                                visitantes.Add(c); // não deu erro de conexao
                            else
                            {
                                visitantes = null;
                                break;
                            }
                        }
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
            }
            if (id == null)
                visitantes = null;
            return false;
        }

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into Visitante (Data_visita, Condicao_religiosa, IdPessoa) " +
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
