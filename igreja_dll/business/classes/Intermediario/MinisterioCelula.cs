using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace business.classes.Intermediario
{
    public class MinisterioCelula : modelocrud
    {
        [Key]
        public int IdMinisterioCelula { get; set; }
        public int CelulaId { get; set; }
        [JsonIgnore]
        public virtual Abstrato.Celula Celula { get; set; }
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
            Select_padrao = "select * from MinisterioCelula as MC ";
            if (id != null) Select_padrao += $" where MC.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            
            if (id != null)
            {
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        return modelos;
                    }

                    dr.Read();
                    this.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                    this.CelulaId = int.Parse(Convert.ToString(dr["CelulaId"]));
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
                try
                {
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        return modelos;
                    }

                    while (dr.Read())
                    {
                        MinisterioCelula pm = new MinisterioCelula();
                        pm.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                        pm.CelulaId = int.Parse(Convert.ToString(dr["CelulaId"]));
                        modelos.Add(pm);
                    }
                    dr.Close();

                    var celulas = Abstrato.Celula.recuperarTodasCelulas().OfType<Abstrato.Celula>().ToList();
                    var ministerios = Abstrato.Ministerio.recuperarTodosMinisterios().OfType<Abstrato.Ministerio>().ToList();
                    foreach (var item in modelos.OfType<MinisterioCelula>().ToList())
                    {
                        item.Celula = celulas.First(i => i.IdCelula == item.CelulaId);
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
