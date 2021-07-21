﻿using database.banco;
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
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("Membro_Reconciliacao")]
    public class Membro_Reconciliacao : Membro
    {

        [Display(Name = "Ano da reconciliação")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Data_reconciliacao { get; set; }

        public Membro_Reconciliacao() : base()
        {
        }

        public Membro_Reconciliacao(int m) : base(m) { }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_Reconciliacao set Data_reconciliacao='{Data_reconciliacao}' " +
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
                    this.Data_reconciliacao = int.Parse(dr["Data_reconciliacao"].ToString());
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
            Insert_padrao += " insert into Membro_Reconciliacao (Data_reconciliacao, Id) " +
                $" values ({Data_reconciliacao}, IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.NomePessoa;
        }

    }
}
