﻿using business;
using business.classes;
using business.classes.Abstrato;
using business.classes.Celulas;
using business.classes.Esboco;
using business.classes.Esboco.Abstrato;
using business.classes.financeiro;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.implementacao;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositorioEF
{
   public class DB : DbContext
    {
        public DB() : base("DefaultConnection")
        {

        }

        public DbSet<Mensagem> Mensagem { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Body> Body { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<PermissaoPessoa> PermissaoPessoa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Atendente> Atendente { get; set; }
        public DbSet<Fonte> Fonte { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }
        public DbSet<MudancaEstado> MudancaEstado { get; set; }
        public DbSet<Reuniao> reuniao { get; set; }

        public DbSet<Pessoa> pessoas { get; set; }
        public DbSet<Endereco> endereco { get; set; }
        public DbSet<EnderecoCelula> EnderecoCelula { get; set; }
        public DbSet<Telefone> telefone { get; set; }
        public DbSet<Celula> celula { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }

        public DbSet<Ministerio> ministerio { get; set; }
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
        }


    }
}
