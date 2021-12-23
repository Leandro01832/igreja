using business.classes.Pessoas;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.PessoasLgpd
{
    [Table("VisitanteLgpd")]
    public class VisitanteLgpd : PessoaLgpd
    {
        private DateTime data_visita = new DateTime(2001, 01, 01);
        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [OpcoesBase(Obrigatorio =true)]
        public DateTime Data_visita
        {
            get
            {
                if (data_visita > DateTime.Now)
                {
                    ErroCadastro = "A data da visita deve ser menor que a data atual.";
                    throw new Exception("Data_visita");
                }

                if (data_visita.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_visita");
                return data_visita;
            }
            set
            {
                if (data_visita.Year <= DateTime.Now.Year && data_visita.Month <= DateTime.Now.Month &&
                     data_visita.Day <= DateTime.Now.Day || data_visita < DateTime.Now)
                    data_visita = value;
                else
                    data_visita = new DateTime(0001, 01, 01);
            }
        }

        private string condicao_religiosa = "condicao";
        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [OpcoesBase(Obrigatorio =true)]
        public string Condicao_religiosa
        {
            get
            {
                if (string.IsNullOrWhiteSpace(condicao_religiosa))
                    throw new Exception("Condicao_religiosa");
                return condicao_religiosa;
            }
            set
            {
                condicao_religiosa = value;
                if (string.IsNullOrWhiteSpace(condicao_religiosa))
                    throw new Exception("Condicao_religiosa");
            }
        }

        public VisitanteLgpd() : base(){ }
    }
}
