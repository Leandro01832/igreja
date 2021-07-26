using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.Celula
{
    public class EnderecoCelula : modelocrud
    {

        [Key, ForeignKey("Celula")]
        public new int Id { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Celula Celula { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado { get; set; }


        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rua { get; set; }

        [Display(Name = "Numero da casa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Numero_casa { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public long Cep { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Complemento { get; set; }

        [NotMapped]
        public static List<EnderecoCelula> EnderecosCelula = new List<EnderecoCelula>();

        public EnderecoCelula() : base()
        {
        }

        public EnderecoCelula(int id) : base(id)
        {
        }

        public override string salvar()
        {
            GetProperties(GetType());
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update EnderecoCelula set Pais='{Pais}', Estado='{Estado}', Complemento='{Complemento}', " +
            $"Cidade='{Cidade}',Bairro='{Bairro}', Rua='{Rua}', Numero_casa='{Numero_casa}', Cep='{Cep}' " +
            $"  where Id='{id}' ";
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(GetType()))
            { T = GetType(); return true; }
            return false;
        }
        
    }

}