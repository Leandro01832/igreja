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

        public static int GeTotalRegistrosMinisterioCelula()
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
                        cmd = new SqlCommand("SELECT COUNT(*) FROM MinisterioCelula", con);
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
