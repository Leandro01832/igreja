using business.classes.Pessoas;
using business.implementacao;
using database.banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("CriancaLgpd")]
    public class CriancaLgpd : PessoaLgpd
    {
        [Display(Name = "Nome do pai")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_pai { get; set; }

        [Display(Name = "Nome da mãe")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome_mae { get; set; }
        

        public CriancaLgpd() : base() { }
        public CriancaLgpd(int m) : base(m)    {  }

        public override string alterar(int id)
        {
            base.alterar(id);
            UpdateProperties(null, id);
            Update_padrao += BDcomum.addNaLista;
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
            if (SetProperties(GetType()))
            {
                base.recuperar(id); T = GetType(); return true;
            }
            return false;
        }

        public override string salvar()
        {
            base.salvar();
            GetProperties(null);
            Insert_padrao += BDcomum.addNaLista;
            bd.SalvarModelo(this);
            return Insert_padrao;
        }
    }
}
