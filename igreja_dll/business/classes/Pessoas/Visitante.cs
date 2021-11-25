using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace business.classes.Pessoas
{
    [Table("Visitante")]
    public class Visitante : PessoaDado
    {
        private DateTime data_visita = new DateTime(2001, 01, 01);
        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [OpcoesBase(Obrigatorio = true)]
        public DateTime Data_visita
        {
            get
            {
                if (data_visita.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data_visita");
                return data_visita;
            }
            set { data_visita = value; }
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
            set { condicao_religiosa = value; }
        }

        public Visitante() : base() { }        
    }
}
