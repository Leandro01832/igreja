using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using business.implementacao;
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
            base.salvar();
            GetProperties(T);
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            base.alterar(id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            T = T.BaseType;
            var delete =
                 Delete_padrao.Replace(GetType().Name, T.Name)
                + base.excluir(id);
            return delete;
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(T))
            {
                base.recuperar(id); return true;
            }
            return false;
        }
    }
}
