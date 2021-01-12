using database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace business.classes
{
    class BuscaLista : modelocrud, IBuscaLista
    {
        public List<int> buscarLista(string TipoDaLista, string Ligacao, string nomeDaChave, int id)
        {
            Select_padrao = $"select * from {TipoDaLista} as M inner join {Ligacao} as L on M.Id=L.Id " +
                $" where {nomeDaChave}='{id}' ";

            List<int> modelos = new List<int>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            try
            {
                while (dr.Read())
                {
                    if(TipoDaLista == "Pessoa")
                    {
                        var numero = int.Parse(dr["Codigo"].ToString());
                        modelos.Add(numero);
                    }
                    else
                    {
                        var numero = int.Parse(dr["Id"].ToString());
                        modelos.Add(numero);
                    }
                    
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
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }
    }
}
