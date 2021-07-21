﻿using business.classes.Abstrato;
using database;
using database.banco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.PessoasLgpd
{
    [Table("Membro_TransferenciaLgpd")]
    public class Membro_TransferenciaLgpd : MembroLgpd
    {

        [Display(Name = "Nome da cidade onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_cidade_transferencia { get; set; }

        [Display(Name = "Estado onde morava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_transferencia { get; set; }

        [Display(Name = "Igreja onde congregava")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_igreja_transferencia { get; set; }

        public Membro_TransferenciaLgpd() : base()
        {
        }

        public Membro_TransferenciaLgpd(int m) : base(m) { }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Membro_TransferenciaLgpd set nome_igreja_transferencia='{Nome_igreja_transferencia}', " +
            $" Estado_transferencia='{Estado_transferencia}', Nome_cidade_transferencia='{Nome_cidade_transferencia}' " +
            $"  where Id='{id}' " + BDcomum.addNaLista;

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
                    this.Nome_cidade_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
                    this.Estado_transferencia = Convert.ToString(dr["Estado_transferencia"]);
                    this.Nome_igreja_transferencia = Convert.ToString(dr["Nome_cidade_transferencia"]);
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
            Insert_padrao += " insert into Membro_transferenciaLgpd (Nome_cidade_transferencia, " +
              " Estado_transferencia, Nome_igreja_transferencia, Id) " +
              $" values ('{Nome_cidade_transferencia}', '{Estado_transferencia}', '{Nome_igreja_transferencia}', " +
              " IDENT_CURRENT('Pessoa'))" + BDcomum.addNaLista;

            bd.SalvarModelo(this);

            return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }
    }
}
