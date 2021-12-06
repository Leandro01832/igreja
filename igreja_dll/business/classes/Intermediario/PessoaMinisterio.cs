using business.classes.Abstrato;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;


namespace business.classes.Intermediario
{
    [Table("PessoaMinisterio")]
    public class PessoaMinisterio : modelocrud
    {
        public PessoaMinisterio() : base(){ }

        public int PessoaId { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        public int MinisterioId { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Ministerio Ministerio { get; set; }
                                
    }

    public class PessoaMinisterioMap : EntityTypeConfiguration<PessoaMinisterio>
    {
        public PessoaMinisterioMap()
        {
            ToTable("PessoaMinisterio");

            // HasKey(a => new { a.PessoaId, a.ReuniaoId });

            Property(a => a.PessoaId)
                .IsRequired();

            Property(a => a.MinisterioId)
                .IsRequired();

            HasRequired(c => c.Pessoa)
                .WithMany(c => c.Ministerio)
                .HasForeignKey(c => c.PessoaId)
                .WillCascadeOnDelete(true);

            HasRequired(c => c.Ministerio)
                .WithMany(c => c.Pessoa)
                .HasForeignKey(c => c.MinisterioId)
                .WillCascadeOnDelete(true);
        }
    }
}
