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

        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from PessoaMinisterio as PM ";
            if (id != null) Select_padrao += $" where PM.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            
            if (id != null)
            {
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                try
                {
                    dr.Read();
                    this.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                    this.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
                    dr.Close();
                    modelos.Add(this);
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }

                return modelos;
            }
            else
            {
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    dr.Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        PessoaMinisterio pm = new PessoaMinisterio();
                        pm.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                        pm.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
                        modelos.Add(pm);
                    }
                    dr.Close();

                    var pessoas = Pessoa.recuperarTodos().OfType<Pessoa>().ToList();
                    var ministerios = Abstrato.Ministerio.recuperarTodosMinisterios().OfType<Abstrato.Ministerio>().ToList();
                    foreach (var item in modelos.OfType<PessoaMinisterio>().ToList())
                    {
                        item.Pessoa = pessoas.First(i => i.IdPessoa == item.PessoaId);
                        item.Ministerio = ministerios.First(i => i.IdMinisterio == item.MinisterioId);
                    }
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
                return modelos;
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
