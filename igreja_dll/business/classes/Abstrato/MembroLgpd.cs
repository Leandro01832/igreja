using database.banco;
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
using business.classes.Pessoas;
using business.classes.PessoasLgpd;

namespace business.classes.Abstrato
{

    [Table("MembroLgpd")]
    public abstract class MembroLgpd : PessoaLgpd
    {        
        [Display(Name = "Ano de batismo")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        // Verificar se propriedade fica nesta classe abstrata. provavelmente não.
        public int Data_batismo { get; set; }

        public bool Desligamento { get; set; }

        public bool Save()
        {
            return true;
        }

        public string Motivo_desligamento { get; set; }

        public MembroLgpd() : base() 
        {
        }

        protected MembroLgpd(int m) : base(m) { }

        public override string alterar(int id)
        {
            base.alterar(id);
            UpdateProperties(T, id);
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

        public override string salvar()
        {
            base.salvar();
            GetProperties(T);            
            return Insert_padrao;
        }
    }
}
