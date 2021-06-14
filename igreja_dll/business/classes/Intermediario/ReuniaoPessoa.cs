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
        [Key]
        public int IdReuniaoPessoa { get; set; }
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

        public override bool recuperar(int? id)
        {
            Select_padrao = "select * from ReuniaoPessoa as RP ";
            if (id != null) Select_padrao += $" where RP.IdReuniaoPessoa='{id}'";

            
            var conexao = bd.obterconexao();

            if (id != null)
            {
                
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
                    dr.Read();
                    this.ReuniaoId = int.Parse(Convert.ToString(dr["ReuniaoId"]));
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
                    List<ReuniaoPessoa> lista = new List<ReuniaoPessoa>();
                    
                    while (dr.Read())
                    {
                        ReuniaoPessoa pm = new ReuniaoPessoa();
                        pm.IdReuniaoPessoa = int.Parse(Convert.ToString(dr["IdReuniaoPessoa"]));
                        lista.Add(pm);
                    }
                    dr.Close();

                    bd.fecharconexao(conexao);
                    //recursividade
                    ReuniaoPessoas = new List<ReuniaoPessoa>();
                    foreach (var item in lista.OfType<ReuniaoPessoa>().ToList())
                    {
                        var modelo = new ReuniaoPessoa();
                        if (recuperar(item.IdReuniaoPessoa))
                            ReuniaoPessoas.Add(modelo); // não deu erro de conexao
                        else
                        {
                            ReuniaoPessoas = null;
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
