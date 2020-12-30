using business.classes;
using business.classes.Abstrato;
using business.classes.Celula;
using business.classes.Ministerio;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositorioEFLgpd
{
   public class DBLgpd : DbContext
    {
        public DBLgpd() : base("DefaultConnection")
        {
            // Database.SetInitializer<DB>(null);
        }

        public DbSet<Chamada> Chamada { get; set; }
        public DbSet<ChamadaLgpd> ChamadaLgpd { get; set; }
        public DbSet<MudancaEstadoLgpd> MudancaEstado { get; set; }
        public DbSet<Reuniao> reuniao { get; set; }
        public DbSet<PessoaLgpd> PessoaLgpd { get; set; }
        public DbSet<EnderecoCelula> EnderecoCelula { get; set; }
        public DbSet<Celula> celula { get; set; }
        public DbSet<Membro_BatismoLgpd> Membro_BatismoLgpd { get; set; }
        public DbSet<Membro_ReconciliacaoLgpd> Membro_ReconciliacaoLgpd { get; set; }
        public DbSet<Membro_AclamacaoLgpd> Membro_AclamacaoLgpd { get; set; }
        public DbSet<Membro_TransferenciaLgpd> Membro_TransferenciaLgpd { get; set; }
        public DbSet<MembroLgpd> MembroLgpd { get; set; }
        public DbSet<VisitanteLgpd> VisitanteLgpd { get; set; }
        public DbSet<CriancaLgpd> CriancaLgpd { get; set; }
        public DbSet<Ministerio> ministerio { get; set; }
        public DbSet<Historico> historico { get; set; }
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
