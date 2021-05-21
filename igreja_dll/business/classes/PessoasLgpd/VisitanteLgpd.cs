﻿using database.banco;
using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections.Generic;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes.PessoasLgpd
{
    [Table("VisitanteLgpd")]
    public class VisitanteLgpd : PessoaLgpd
    {

        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita { get; set; }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa { get; set; }

        public VisitanteLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update {this.GetType().Name} set Data_visita='{Data_visita.ToString("yyyy-MM-dd")}', " +
            $"Condicao_religiosa='{Condicao_religiosa}' " +
            $" where IdPessoa='{id}' " + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where IdPessoa='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from VisitanteLgpd as V "
            + " inner join PessoaLgpd as PL on V.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where V.IdPessoa='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                try
                {
                    bd.obterconexao().Close();
                    base.recuperar(id);
                    bd.obterconexao().Open();
                    Select_padrao = "select * from VisitanteLgpd as V "
                + " inner join PessoaLgpd as PL on V.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
                    if (id != null) Select_padrao += $" where V.IdPessoa='{id}' ";
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();


                    if (dr.HasRows == false)
                    {
                        bd.obterconexao().Close();
                        return modelos;
                    }
                    dr.Read();

                    this.Data_visita = Convert.ToDateTime(dr["Data_visita"]);
                    this.Condicao_religiosa = Convert.ToString(dr["Condicao_religiosa"]);

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
                    bd.obterconexao().Open();
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        VisitanteLgpd v = new VisitanteLgpd();
                        v.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
                        modelos.Add(v);
                    }
                    dr.Close();

                    //Recursividade
                    bd.obterconexao().Close();
                    List<modelocrud> lista = new List<modelocrud>();
                    foreach (var m in modelos)
                    {
                        var cel = (VisitanteLgpd)m;
                        var c = new VisitanteLgpd();
                        c = (VisitanteLgpd)m.recuperar(cel.IdPessoa)[0];
                        lista.Add(c);
                    }
                    modelos.Clear();
                    modelos.AddRange(lista);
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
            Insert_padrao += $" insert into {this.GetType().Name} (Data_visita, Condicao_religiosa, IdPessoa) " +
            $" values ('{this.Data_visita.ToString("yyyy-MM-dd")}', '{Condicao_religiosa}', IDENT_CURRENT('Pessoa')) "
            + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }

    }
}
