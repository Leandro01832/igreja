using business.classes.Abstrato;
using business.classes.Pessoas;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes
{
    public class Chamada : modelocrud
    {
        [Key, ForeignKey("Pessoa")]
        public new int Id { get; set; }
        [Display(Name = "Data de inicio")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_inicio { get; set; }

        [Display(Name = "Numero da chamada")]
        public int Numero_chamada { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        [NotMapped]
        public static List<Chamada> Chamadas { get; set; }

        public Chamada()
        {
            Data_inicio = DateTime.Now;
            Numero_chamada = 0;

        }

        public Chamada(int id) : base(id)
        {
        }

        public override string alterar(int id)
        {
            UpdateProperties(GetType(), id);
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
        
        public override string salvar()
        {
            GetProperties(GetType());
            return Insert_padrao;
        }
    }
}
