using database.banco;
using System;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Collections.Generic;
using database;
using business.classes.Abstrato;

namespace business.classes.Pessoas
{
    [Table("Visitante")]
    public class Visitante : Pessoa
    {       
        private DateTime data_visita;
        
        private string condicao_religiosa;

        [Display(Name = "Data da visita")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_visita
        {
            get
            {
                string sqlTimeAsString = data_visita.ToString("yyyy-MM-dd HH:mm:ss.fff");
                return Convert.ToDateTime(sqlTimeAsString);
            }

            set
            {
                string sqlTimeAsString = value.ToString("yyyy-MM-dd HH:mm:ss.fff");
                data_visita = Convert.ToDateTime(sqlTimeAsString);
            }
        }

        [Display(Name = "Condição religiosa")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Condicao_religiosa
        {
            get
            {
                return condicao_religiosa;
            }

            set
            {
                if(value != "")
                condicao_religiosa = value;
                else
                {
                    MessageBox.Show("indique a condição religiiosa");
                    condicao_religiosa = null;
                }
            }
        }
        

        public Visitante() : base()
        {
        }

        public Visitante(int? id, bool recuperaLista) : base(id, recuperaLista)
        {

        }

        public DateTime freguentar()
        {

            DateTime frequencia = DateTime.Today.AddDays(30);

            return data_visita;
        }      

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $" update Visitante set Data_visita='{Data_visita.ToString("yyyy-MM-dd")}', " + 
            $"Condicao_religiosa='{Condicao_religiosa}' " +
            $" where Id='{id}' ";
            
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from Visitante where Id='{id}' " + base.excluir(id);
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Visitante as V "
            + " inner join Pessoa as P on V.Id=P.Id ";
            if (id != null) Select_padrao += $" where V.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
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
                        Visitante v = new Visitante();
                        v.Id = int.Parse(Convert.ToString(dr["Id"]));
                        v.Nome = Convert.ToString(dr["Nome"]);
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
            Insert_padrao += $" insert into Visitante (Data_visita, Condicao_religiosa, Id) " +
            $" values ('{this.Data_visita.ToString("yyyy-MM-dd")}', '{Condicao_religiosa}', IDENT_CURRENT('Pessoa'))"
            + BDcomum.addNaLista;

            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
           return Insert_padrao;
        }
        
    }
}
