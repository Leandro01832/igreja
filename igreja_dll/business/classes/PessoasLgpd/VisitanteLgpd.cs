using business.classes.Pessoas;
using business.implementacao;
using database.banco;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public VisitanteLgpd(int m) : base(m) { }

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
