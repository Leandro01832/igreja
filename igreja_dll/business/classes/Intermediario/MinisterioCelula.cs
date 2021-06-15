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
        [Key]
        public int IdMinisterioCelula { get; set; }
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

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from MinisterioCelula as MC ";
            if (id != null) Select_padrao += $" where MC.IdMinisterioCelula='{id}'";

            
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
            else
            {
                try
                {
                    MinisterioCelulas = new List<MinisterioCelula>();
                    SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao(conexao);
                        return false;
                    }

                    List<MinisterioCelula> lista = new List<MinisterioCelula>();
                    while (dr.Read())
                    {
                        MinisterioCelula pm = new MinisterioCelula();
                        pm.IdMinisterioCelula = int.Parse(Convert.ToString(dr["IdMinisterioCelula"]));
                        lista.Add(pm);
                    }
                    dr.Close();

                    bd.fecharconexao(conexao);
                    //recursividade
                    foreach (var item in lista.OfType<MinisterioCelula>().ToList())
                    {
                        var model = new MinisterioCelula();
                        if(model.recuperar(item.IdMinisterioCelula))
                        MinisterioCelulas.Add(model); //não deu erro de conexão
                        else
                        {
                            MinisterioCelulas = null;
                            return false;
                        }
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
