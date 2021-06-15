using business.classes.Abstrato;
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
    [Table("PessoaMinisterio")]
    public class PessoaMinisterio : modelocrud
    {
        [Key]
        public int IdPessoaMinisterio { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        public int MinisterioId { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Ministerio Ministerio { get; set; }

        [NotMapped]
        public static List<PessoaMinisterio> PessoaMinisterios { get; set; }

        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from PessoaMinisterio as PM ";
            if (id != null) Select_padrao += $" where PM.IdPessoaMinisterio='{id}'";

            
            var conexao = bd.obterconexao();

            if (id != null)
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
                    this.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
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
            else
            {
                PessoaMinisterios = new List<PessoaMinisterio>();
                SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    bd.fecharconexao(conexao);
                    return false;
                }
                try
                {
                    List<modelocrud> lista = new List<modelocrud>();
                    while (dr.Read())
                    {
                        PessoaMinisterio pm = new PessoaMinisterio();
                        pm.IdPessoaMinisterio = int.Parse(Convert.ToString(dr["IdPessoaMinisterio"]));
                        lista.Add(pm);
                    }
                    dr.Close();

                    bd.fecharconexao(conexao);
                    // recursividade          
                    
                    foreach (var item in lista.OfType<PessoaMinisterio>())
                    {
                        var model = new PessoaMinisterio();
                        if(model.recuperar(item.IdPessoaMinisterio))
                            PessoaMinisterios.Add(model);
                    }
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
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }
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
                .WithMany(c => c.Ministerios)
                .HasForeignKey(c => c.PessoaId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Ministerio)
                .WithMany(c => c.Pessoas)
                .HasForeignKey(c => c.MinisterioId)
                .WillCascadeOnDelete(false);
        }
    }
}
