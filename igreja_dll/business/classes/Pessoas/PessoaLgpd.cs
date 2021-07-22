using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace business.classes.Pessoas
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : Pessoa
    {
        public PessoaLgpd() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
        }

        protected PessoaLgpd(int m) : base(m) { }

        AddNalista AddNalista;

        private MudancaEstado MudancaEstado;

        public override string salvar()
        {
            Insert_padrao = base.salvar();
            Insert_padrao += " insert into PessoaLgpd (Id) values (IDENT_CURRENT('Pessoa')) ";

            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            base.excluir(id);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if(this is MembroLgpd)
            Select_padrao = Select_padrao.Replace(GetType().BaseType.Name, GetType().BaseType.BaseType.Name);
            else
            Select_padrao = Select_padrao.Replace(GetType().Name, GetType().BaseType.Name);

            var conexao = bd.obterconexao();

            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return false;
            }
            dr.Close();
            base.recuperar(id);
            bd.fecharconexao(conexao);
            return true;
        }
    }
}
