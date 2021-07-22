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
            if(conexao != null)
            {
                try
                {
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    dr.Read();
                    this.ReuniaoId = int.Parse(Convert.ToString(dr["ReuniaoId"]));
                    this.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
                    dr.Close();
                }

                catch (Exception ex)
                {
                    TratarExcessao(ex);
                    return false;
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
