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
            Select_padrao = $"select * from MinisterioCelula as MC where MC.Id='{id}'";            
            var conexao = bd.obterconexao();

            if(conexao != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    dr.Read();
                    this.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                    this.CelulaId = int.Parse(Convert.ToString(dr["CelulaId"]));
                    dr.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    bd.fecharconexao(conexao);
                }
                return true;
            }
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
