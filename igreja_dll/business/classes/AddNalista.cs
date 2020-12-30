using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using database;
using database.banco;

namespace business.classes
{
   public class AddNalista : modelocrud, IAddNalista
    {
        public AddNalista() : base()
        {
        }
        public void AdicionarNaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros)
        {
            var arr = numeros.Replace(" ", "").Split(',');
            var v = "";

            foreach(var valor in arr)
            {
                try
                {
                    int numero = int.Parse(valor);
                    var insert = $" insert into {NomeTabela} " +
                    $" ({modeloQRecebe}_Id, {modeloQPreenche}_Id) " +
                    $" values (IDENT_CURRENT('{modeloQRecebe}'), '{numero}') ";
                    v += insert;
                }
                catch{}
            }

            BDcomum.addNaLista += v;
        }

        public void RemoverDaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros, int id)
        {
            var arr = VerificaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros, id).Replace(" ", "").Split(',');
            var v = "";

            foreach (var valor in arr)
            {
                Delete_padrao = $"delete from {NomeTabela} where {modeloQRecebe}_Id='{valor}' ";
                v += Delete_padrao;
            }

            BDcomum.addNaLista += v;
        }

        private string VerificaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros, int id)
        {
            Select_padrao = $"select * from {NomeTabela} where {modeloQRecebe}_Id='{id}'";
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();

            if (dr.HasRows == false)
            {
                return "";
            }
            else
            {
                var valores = "";
                var valor = "";
                var dadosBanco = "";
                try
                {
                    while (dr.Read())
                    {
                       valor = Convert.ToString(dr[modeloQPreenche +"_Id"]);
                        if (!numeros.Contains(valor))
                            valores += valor + ", ";
                        dadosBanco += valor + ", ";
                    }
                    dr.Close();

                    var arr = numeros.Replace(" ", "").Split(',');
                    var addNaLista = "";
                    foreach(var item in arr)
                    {
                        if (!dadosBanco.Contains(item))
                            addNaLista += item + ", ";
                    }

                    if (addNaLista != "")
                        AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, addNaLista);

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }
                return valores;
            }

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
