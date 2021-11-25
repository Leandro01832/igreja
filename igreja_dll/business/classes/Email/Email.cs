using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace business
{
   public abstract class Email : modelocrud
    {
        public int? CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string MensagemId { get; set; }

        private string assunto = "assunto";
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage ="Este campo é necessário!!!")]
        public string Assunto
        {
            get
            {
                if (string.IsNullOrWhiteSpace(assunto))
                    throw new Exception("Assunto");
                return assunto;
            }
            set
            {
                assunto = value;
                if (string.IsNullOrWhiteSpace(assunto))
                    throw new Exception("Assunto");
            }
        }

        private DateTime data = new DateTime(2001, 1, 1);
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo é necessário!!!")]
        public DateTime Data
        {
            get
            {
                if (data.ToString("dd/MM/yyyy") == new DateTime(0001, 01, 01).ToString("dd/MM/yyyy"))
                    throw new Exception("Data");
                return data;
            }
            set { data = value; }
        }


        private static string path = Directory.GetCurrentDirectory();
        


        public override string ToString()
        {
            return this.Id + " - " + Data.ToString("dd/MM/yyyy");
        }
    }
}
