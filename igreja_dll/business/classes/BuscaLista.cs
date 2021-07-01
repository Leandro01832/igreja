using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace business.classes
{
    class BuscaLista : modelocrud, IBuscaLista
    {
        private string tipolista;
        private string ligacao;

        public List<int> buscarLista(modelocrud TipoDaLista, modelocrud Ligacao, string nomeDaChave, int id)
        {
            verificaModelos(TipoDaLista, Ligacao);

            Select_padrao = $"select * from {tipolista} as M inner join {ligacao} as L on L.Id{ligacao}={nomeDaChave}" +
                $" where {nomeDaChave}='{id}' ";

            List<int> modelos = new List<int>();
            var conexao = bd.obterconexao();
            
            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return modelos;
            }

            try
            {
                while (dr.Read())
                {
                    if(tipolista == "Pessoa")
                    {
                        var numero = int.Parse(dr["Codigo"].ToString());
                        modelos.Add(numero);
                    }
                    else
                    {
                        var numero = int.Parse(dr["Id" + tipolista].ToString());
                        modelos.Add(numero);
                    }
                    
                }                
                dr.Close();                
            }

            catch (Exception ex)
            {
                TratarExcessao(ex);
            }
            finally
            {
                bd.fecharconexao(conexao);
            }
            return modelos;
        }

        private void verificaModelos(modelocrud TipoDaLista, modelocrud Ligacao)
        {
            if (TipoDaLista is Pessoa) { tipolista = "Pessoa"; }
            if (Ligacao is Pessoa) ligacao = "Pessoa";

            if (TipoDaLista is Abstrato.Ministerio)
            { tipolista = "Ministerio";   }
            if (Ligacao is Abstrato.Ministerio) ligacao = "Ministerio";

            if (TipoDaLista is Abstrato.Celula)
            { tipolista = "Celula";  }
            if (Ligacao is Abstrato.Celula) ligacao = "Celula";

            if (TipoDaLista is Reuniao)
            { tipolista = "Reuniao";  }
            if (Ligacao is Reuniao) ligacao = "Reuniao";
        }

        public override string alterar(int id)
        {
            throw new NotImplementedException();
        }

        public override string excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool recuperar(int id)
        {
            throw new NotImplementedException();
        }

        public override bool recuperar()
        {
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }
    }
}
