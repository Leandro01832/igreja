using business.classes.Abstrato;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;

namespace business.classes.Intermediario
{
    public class ReuniaoPessoa : modelocrud
    {
        public ReuniaoPessoa() : base()
        {
        }
        public ReuniaoPessoa(int id) : base(id)
        {
        }

        public int PessoaId { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        public int ReuniaoId { get; set; }
        [JsonIgnore]
        public virtual Reuniao Reuniao { get; set; }

        [NotMapped]
        public static List<ReuniaoPessoa> ReuniaoPessoas { get; set; }

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

        public static int GeTotalRegistrosPessoasEmReunioes()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM ReuniaoPessoa", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }
    }

    public class ReuniaoPessoaMap : EntityTypeConfiguration<ReuniaoPessoa>
    {
        public ReuniaoPessoaMap()
        {
            ToTable("ReuniaoPessoa");

            // HasKey(a => new { a.PessoaId, a.ReuniaoId });

            Property(a => a.PessoaId)
                .IsRequired();

            Property(a => a.ReuniaoId)
                .IsRequired();

            HasRequired(c => c.Pessoa)
                .WithMany(c => c.Reuniao)
                .HasForeignKey(c => c.PessoaId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Reuniao)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(c => c.ReuniaoId)
                .WillCascadeOnDelete(false);
        }
    }
}
