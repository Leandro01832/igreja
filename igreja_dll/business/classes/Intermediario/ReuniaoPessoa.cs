using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace business.classes.Intermediario
{
    public class ReuniaoPessoa : modelocrud
    {
        [Key]
        public int IdReuniaoPessoa { get; set; }
        public int PessoaId { get; set; }
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }
        public int ReuniaoId { get; set; }
        [JsonIgnore]
        public virtual Reuniao Reuniao { get; set; }

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
            Select_padrao = "select * from ReuniaoPessoa as RP ";
            if (id != null) Select_padrao += $" where RP.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();

            if (id != null)
            {
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    dr.Read();
                    this.ReuniaoId = int.Parse(Convert.ToString(dr["ReuniaoId"]));
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
                bd.obterconexao().Open();
                SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.HasRows == false)
                {
                    bd.obterconexao().Close();
                    return modelos;
                }
                try
                {
                    while (dr.Read())
                    {
                        ReuniaoPessoa pm = new ReuniaoPessoa();
                        pm.ReuniaoId = int.Parse(Convert.ToString(dr["ReuniaoId"]));
                        pm.PessoaId = int.Parse(Convert.ToString(dr["PessoaId"]));
                        modelos.Add(pm);
                    }
                    dr.Close();

                    var pessoas = Pessoa.recuperarTodos().OfType<Pessoa>().ToList();
                    var reunioes = new Reuniao().recuperar(null).OfType<Reuniao>().ToList();
                    foreach (var item in modelos.OfType<ReuniaoPessoa>().ToList())
                    {
                        item.Pessoa = pessoas.First(i => i.IdPessoa == item.PessoaId);
                        item.Reuniao = reunioes.First(i => i.IdReuniao == item.ReuniaoId);
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
