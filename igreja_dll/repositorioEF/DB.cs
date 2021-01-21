
using business.classes;
using business.classes.Celula;
using business.classes.Ministerio;
using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using business.classes.Pessoas;
using business.classes.Intermediario;

namespace repositorioEF
{
    public class DB : DbContext
    {
        public DB() : base("DefaultConnection")
        {
           // Database.SetInitializer<DB>(null);
        }

        public DbSet<Chamada> Chamadas { get; set; }
        public DbSet<MudancaEstado> MudancaEstado { get; set; }
        public DbSet<Reuniao> reuniao { get; set; }
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<EnderecoCelula> EnderecoCelula { get; set; }
        public DbSet<Telefone> telefone { get; set; }
        public DbSet<Celula> celula { get; set; }     
        public DbSet<Ministerio> ministerio { get; set; }
        public DbSet<Lider_Celula> Lider_Celula { get; set; }
        public DbSet<Historico> historico { get; set; }
        public DbSet<PessoaMinisterio> PessoaMinisterio { get; set; }
        public DbSet<ReuniaoPessoa> ReuniaoPessoa { get; set; }
        public DbSet<MinisterioCelula> MinisterioCelula { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PessoaMinisterioMap());
            modelBuilder.Configurations.Add(new ReuniaoPessoaMap());
            modelBuilder.Configurations.Add(new MinisterioCelulaMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // modelBuilder.Conventions.Remove<PrimaryKeyNameForeignKeyDiscoveryConvention>();
            //  modelBuilder.Entity<Celula>().HasKey(c => c.Id).HasEntitySetName("Celulaid");

        }

      
    }
}