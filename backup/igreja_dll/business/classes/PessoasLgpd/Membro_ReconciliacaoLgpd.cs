﻿using database.banco;
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

        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao { get; set; }

        public Membro_ReconciliacaoLgpd() : base()
        {
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_ReconciliacaoLgpd set Data_reconciliacao='{Data_reconciliacao}' " +
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
            Select_padrao = "select * from Membro_ReconciliacaoLgpd as MR "
            + " inner join MembroLgpd as M on MR.IdPessoa=M.IdPessoa "
            + " inner join PessoaLgpd as PL on M.IdPessoa=PL.IdPessoa inner join Pessoa as P on PL.IdPessoa=P.IdPessoa ";
            if (id != null) Select_padrao += $" where MR.IdPessoa='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
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
                        mr.IdPessoa = int.Parse(Convert.ToString(dr["IdPessoa"]));
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
            Insert_padrao += " insert into Membro_ReconciliacaoLgpd (Data_reconciliacao, IdPessoa) " +
                $" values ({Data_reconciliacao}, IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            
            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}