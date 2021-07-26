using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace business.classes.Intermediario
{
    public class MinisterioCelula : modelocrud
    {
        public MinisterioCelula() : base()
        {
        }
        public MinisterioCelula(int id) : base(id)
        {
        }

        public int CelulaId { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Celula Celula { get; set; }
        public int MinisterioId { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Ministerio Ministerio { get; set; }

        [NotMapped]
        public static List<MinisterioCelula> MinisterioCelulas { get; set; }

        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(GetType()))
            { T = GetType(); return true; }
            return false;
        }
        
        public override string salvar()
        {
            throw new NotImplementedException();
        }
    }

    public class MinisterioCelulaMap : EntityTypeConfiguration<MinisterioCelula>
    {
        public MinisterioCelulaMap()
        {
            ToTable("MinisterioCelula");

            // HasKey(a => new { a.PessoaId, a.ReuniaoId });

            Property(a => a.CelulaId)
                .IsRequired();

            Property(a => a.MinisterioId)
                .IsRequired();

            HasRequired(c => c.Celula)
                .WithMany(c => c.Ministerios)
                .HasForeignKey(c => c.CelulaId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Ministerio)
                .WithMany(c => c.Celulas)
                .HasForeignKey(c => c.MinisterioId)
                .WillCascadeOnDelete(false);
        }
    }
}
