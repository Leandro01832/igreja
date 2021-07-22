using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using business.classes.Abstrato;
using database;
using database.banco;

namespace business.classes
{
   public class AddNalista : modelocrud, IAddNalista
    {
        public AddNalista() : base()
        {
        }

        private string recebe = "";
        private string preenche = "";
        private int IdModelo = 0;

        public void AdicionarNaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros)
        {
            verificaModelos(modeloQRecebe, modeloQPreenche);

            var arr = numeros.Replace(" ", "").Split(',');
            var v = "";
            //IDENT_CURRENT('
            foreach (var valor in arr)
            {
                try
                {
                    var valorId = "";
                    if (IdModelo == 0)
                        valorId = $"IDENT_CURRENT('{recebe}')";
                    else
                        valorId = IdModelo.ToString();

                    int numero = int.Parse(valor);
                    var insert = $" insert into {NomeTabela} " +
                    $" ({recebe}Id, {preenche}Id) " +
                    $" values ({valorId}, '{numero}') ";
                    v += insert;
                }
                catch { }
            }

            BDcomum.addNaLista += v;
        }

        private void verificaModelos(modelocrud modeloQRecebe, modelocrud modeloQPreenche)
        {
            if (modeloQRecebe is Pessoa) { recebe = "Pessoa"; var p = (Pessoa)modeloQRecebe; IdModelo = p.Id; }
            if (modeloQPreenche is Pessoa) preenche = "Pessoa";

            if (modeloQRecebe is Abstrato.Ministerio)
            { recebe = "Ministerio"; var p = (Abstrato.Ministerio)modeloQRecebe; IdModelo = p.Id; }
            if (modeloQPreenche is Abstrato.Ministerio) preenche = "Ministerio";

            if (modeloQRecebe is Abstrato.Celula)
            { recebe = "Celula"; var p = (Abstrato.Celula)modeloQRecebe; IdModelo = p.Id; }
            if (modeloQPreenche is Abstrato.Celula) preenche = "Celula";

            if (modeloQRecebe is Reuniao)
            { recebe = "Reuniao"; var p = (Reuniao)modeloQRecebe; IdModelo = p.Id; }
            if (modeloQPreenche is Reuniao) preenche = "Reuniao";
        }

        public void RemoverDaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros)
        {
            verificaModelos(modeloQRecebe, modeloQPreenche);

            var arr = VerificaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros).Replace(" ", "").Split(',');
            var v = "";

            foreach (var valor in arr)
            {
                Delete_padrao = $"delete from {NomeTabela} where {recebe}Id='{valor}' ";
                v += Delete_padrao;
            }

            BDcomum.addNaLista += v;
        }

        private string VerificaLista(string NomeTabela, modelocrud modeloQRecebe, modelocrud modeloQPreenche, string numeros)
        {
            verificaModelos(modeloQRecebe, modeloQPreenche);
            var conexao = bd.obterconexao();

            Select_padrao = $"select * from {NomeTabela} where {recebe}Id='{IdModelo}'";
            
            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();

            if (dr.HasRows == false)
            {
                dr.Close();
                AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
                bd.fecharconexao(conexao);
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
                       valor = Convert.ToString(dr[preenche +"Id"]);
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
                    TratarExcessao(ex);
                }
                finally
                {
                    bd.fecharconexao(conexao);
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

        public override bool recuperar(int id)
        {
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }        
    }
}
