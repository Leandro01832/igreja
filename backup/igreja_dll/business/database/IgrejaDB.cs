﻿using business.classes;
using business.classes.Abstrato;
using business.classes.Celula;
using business.classes.Intermediario;
using business.classes.Ministerio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.database
{
    class IgrejaDB : DbContext
    {
        public IgrejaDB() : base("Igreja")
        {
             Database.SetInitializer<IgrejaDB>(null);
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