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
using System.Windows.Forms;

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
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                try
                {
                    dr.Read();
                    this.MinisterioId = int.Parse(Convert.ToString(dr["MinisterioId"]));
                    this.CelulaId = int.Parse(Convert.ToString(dr["CelulaId"]));
                    dr.Close();
                    modelos.Add(this);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    bd.obterconexao().Close();
                }

                return modelos;
            }
            else
            {
                try
                {
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
                    foreach(var item in modelos.OfType<MinisterioCelula>().ToList())
                    {
                        item.Celula = celulas.First(i => i.IdCelula == item.CelulaId);
                        item.Ministerio = ministerios.First(i => i.IdMinisterio == item.MinisterioId);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
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
