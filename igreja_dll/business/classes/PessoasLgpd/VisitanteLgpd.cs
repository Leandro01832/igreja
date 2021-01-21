using database.banco;
using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections.Generic;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes.PessoasLgpd
{
    [Table("VisitanteLgpd")]
    public class VisitanteLgpd : PessoaLgpd
    {       

        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita { get; set; }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa { get; set; }

        public VisitanteLgpd() : base()
        {
        }   

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update {this.GetType().Name} set Data_visita='{Data_visita.ToString("yyyy-MM-dd")}', " + 
            $"Condicao_religiosa='{Condicao_religiosa}' " +
            $" where Id='{id}' " + BDcomum.addNaLista;
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from {this.GetType().Name} where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from VisitanteLgpd as V "
            + " inner join PessoaLgpd as PL on V.Id=PL.Id inner join Pessoa as P on PL.Id=P.Id ";
            if (id != null) Select_padrao += $" where V.Id='{id}' ";

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
                base.recuperar(id);
                try
                {
                    dr.Read();

                    this.Data_visita = Convert.ToDateTime(Convert.ToString(dr["Data_visita"]));
                    this.Condicao_religiosa = Convert.ToString(dr["Condicao_religiosa"]);

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
                        VisitanteLgpd v = new VisitanteLgpd();
                        v.Id = int.Parse(Convert.ToString(dr["Id"]));
                        v.Codigo = int.Parse(Convert.ToString(dr["Codigo"]));
                        v.Email = Convert.ToString(dr["Email"]);
                        modelos.Add(v);
                    }
                    dr.Close();
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
            Insert_padrao = base.salvar();
            Insert_padrao += $" insert into {this.GetType().Name} (Data_visita, Condicao_religiosa, Id) " +
            $" values ('{this.Data_visita.ToString("yyyy-MM-dd")}', '{Condicao_religiosa}', IDENT_CURRENT('Pessoa')) "
            + BDcomum.addNaLista;

            bd.SalvarModelo(this);
            
           return Insert_padrao;
        }

        public override string ToString()
        {
            return base.Codigo + " - " + base.Email;
        }

    }
}
