using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes.Intermediario
{
    [Table("PessoaMinisterio")]
   public class PessoaMinisterio : modelocrud
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int MinisterioId { get; set; }
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
            Select_padrao = "select * from PessoaMinsterio as PM ";
            if (id != null) Select_padrao += $" where PM.Id='{id}'";

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
                    this.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
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
                        item.Pessoa = pessoas.First(i => i.Id == item.PessoaId);
                        item.Ministerio = ministerios.First(i => i.Id == item.MinisterioId);
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

    public class PessoaMinisterioMap : EntityTypeConfiguration<PessoaMinisterio>
    {
        public PessoaMinisterioMap()
        {
            ToTable("PessoaMinisterio");

            HasKey(a => new { a.PessoaId, a.MinisterioId });

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
