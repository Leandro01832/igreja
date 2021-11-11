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
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage ="Este campo é necessário!!!")]
        public string Assunto { get; set; }
        
        [OpcoesBase(ChaveEstrangeira = false, ChavePrimaria = false, Index = false, Obrigatorio = true)]
        [Required(ErrorMessage = "Este campo é necessário!!!")]
        public DateTime Data { get; set; }


        private static string path = Directory.GetCurrentDirectory();

        public string Caminho
        {
            get
            {
                return path + @"\Email\" + this.Id.ToString() + ".html";
            }
        } 


        public override string ToString()
        {
            return this.Id + " - " + Data.ToString("dd/MM/yyyy");
        }
    }
}
