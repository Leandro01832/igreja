using business.classes;
using business.classes.Abstrato;
using business.classes.Celula;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.database
{
    class DBIgreja : DbContext
    {
        public DBIgreja() : base("Igreja")
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Ministerio> Ministerio { get; set; }
        public DbSet<Celula> Celula { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EnderecoCelula> EnderecoCelula { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Chamada> Chamada { get; set; }
        public DbSet<Reuniao> Reuniao { get; set; }
        public DbSet<MudancaEstado> MudancaEstado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
