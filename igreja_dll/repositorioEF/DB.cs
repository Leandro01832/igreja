
using business.classes;
using business.classes.Celula;
using business.classes.Ministerio;
using business.classes.Abstrato;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using business.classes.Pessoas;

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
        public DbSet<MudancaEstadoLgpd> MudancaEstadoLgpd { get; set; }
        public DbSet<Reuniao> reuniao { get; set; }
        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<EnderecoCelula> EnderecoCelula { get; set; }
        public DbSet<Telefone> telefone { get; set; }
        public DbSet<Celula> celula { get; set; }
        public DbSet<Membro_Batismo> membro_batismo { get; set; }
        public DbSet<Membro_Reconciliacao> membro_reconciliacao { get; set; }
        public DbSet<Membro_Aclamacao> membro_aclamacao { get; set; }
        public DbSet<Membro_Transferencia> membro_transferencia { get; set; }
        public DbSet<Membro> membro { get; set; }
        public DbSet<Visitante> visitante { get; set; }
        public DbSet<Crianca> crianca { get; set; }        
        public DbSet<Ministerio> ministerio { get; set; }
        public DbSet<Historico> historico { get; set; }
        public DbSet<HistoricoLgpd> HistoricoLgpd { get; set; }
        public DbSet<Supervisor_Celula> Supervisor_Celula { get; set; }
        public DbSet<Supervisor_Celula_Treinamento> Supervisor_Celula_Treinamento { get; set; }
        public DbSet<Supervisor_Ministerio> Supervisor_Ministerio { get; set; }
        public DbSet<Supervisor_Ministerio_Treinamento> Supervisor_Ministerio_Treinamento { get; set; }
        public DbSet<Lider_Celula_Treinamento> lider_treinamento { get; set; }
        public DbSet<Lider_Celula> lider { get; set; }
        public DbSet<Lider_Ministerio> Lider_Ministerio { get; set; }
        public DbSet<Lider_Ministerio_Treinamento> Lider_Ministerio_Treinamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // modelBuilder.Conventions.Remove<PrimaryKeyNameForeignKeyDiscoveryConvention>();
            //  modelBuilder.Entity<Celula>().HasKey(c => c.Id).HasEntitySetName("Celulaid");

        }

      
    }
}