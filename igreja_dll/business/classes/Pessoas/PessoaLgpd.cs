using business.classes.Abstrato;
using business.classes.PessoasLgpd;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("PessoaLgpd")]
    public abstract class PessoaLgpd : Pessoa, IAddNalista, IMudancaEstado  
    {
        public PessoaLgpd() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
            
        }

        AddNalista AddNalista;

        private MudancaEstado MudancaEstado;

        public override string salvar()
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

                      Insert_padrao =
              "insert into PessoaLgpd (Email,  Falta, celula_, Img) " +
              $" values ( '{this.Email}',  '{this.Falta}', {celula}, '{this.Img}') " +
               this.Chamada.salvar() + " ";
            
            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

            Update_padrao = $"update PessoaLgpd set  " +
            $" Email='{Email}',  " +
            $"celula_={celula}, " +
            $" Falta='{Falta}', Img='{this.Img}' " +
            $"  where Id='{id}' ";
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $" delete from PessoaLgpd as P where P.Id='{id}' ";
            
            bd.Excluir(null);
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from PessoaLgpd as P "
        + " inner join ChamadaLgpd as CH on CH.Id=P.Id ";
            if (id != null) Select_padrao += $" where P.Id='{id}'";

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
            return modelos;
        }
    }
}
