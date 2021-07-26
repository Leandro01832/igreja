using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Collections;

using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;
using Newtonsoft.Json;

namespace business.classes
{
    [Table("Historico")]
    public class Historico : modelocrud
    {

        public DateTime Data_inicio { get; set; }

        public int pessoaid { get; set; }

        [ForeignKey("pessoaid")]
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        public int Falta { get; set; }

        [NotMapped]
        public static List<Historico> Historicos { get; set; }

        public Historico() : base()
        {
        }

        public Historico(int id) : base(id)
        {
        }

        public override string alterar(int id)
        {
            UpdateProperties(GetType(), id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            bd.Excluir(this);
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
            bd.SalvarModelo(this);
            return Insert_padrao;
        }

    }
}
