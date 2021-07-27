using business.classes.Abstrato;
using business.implementacao;
using database.banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Membro_Transferencia")]
    public class Membro_Transferencia : Membro
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
        

        public Membro_Transferencia() : base(){ }

        public Membro_Transferencia(int m) : base(m) { }

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
