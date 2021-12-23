using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace database.banco
{
    public class BDcomum
    {
        static string path = Directory.GetCurrentDirectory();
        //  public static string conecta1 = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
        public static string conecta1 = $@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Igreja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string conecta2 = $@"Data Source=database-igreja.mssql.somee.com;packet size=4096;user id=lls01833_SQLLogin_1;pwd=tsobwjtsix;data source=database-igreja.mssql.somee.com;persist security info=False;initial catalog=database-igreja";

        static List<string> stringsSqlConecta = new List<string>();
        static List<string> stringsConexao = new List<string>();

        public static bool podeAbrir = true;
        public static bool BancoEnbarcado = true;

        public static bool TestarConexao()
        {
            try
            {
                using (var client = new WebClient())
                {
                    WebProxy wp = new WebProxy();
                    client.Proxy = wp;
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public SqlConnection obterconexao(string stringConexao)
        {
            conecta1 = conecta1.Replace("Tests", "WindowsFormsApp1");

            SqlConnection conn = null;
            if (podeAbrir)
            {
                try
                {
                    conn = new SqlConnection(stringConexao);
                    conn.Open();
                    modelocrud.Erro_Conexao = false;
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("instância"))
                    {
                        conn = null;
                        podeAbrir = false;
                    }

                }
            }
            else
            {
                if (TestarConexao())
                {
                    podeAbrir = true;
                    conn = new SqlConnection(stringConexao);
                    try { conn.Open(); }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("instância"))
                        {
                            podeAbrir = false;
                        }

                    }
                }
            }

            return conn;
        }

        public void fecharconexao(SqlConnection conexao)
        {
            if (conexao != null)
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Dispose();
                }
        }

        public void SalvarModelo(modelocrud modelo, string stringConexao = "",
            bool executarAosPares = false, int quantidadeConexoes = 0)
        {
            if (stringConexao == "")
            {
                ExecutarComandoSqlServer(modelo.Insert_padrao, conecta1, executarAosPares, quantidadeConexoes);
                ExecutarComandoSqlServer(modelo.Insert_padrao, conecta2, executarAosPares, quantidadeConexoes);
            }
            else
                ExecutarComandoSqlServer(modelo.Insert_padrao, stringConexao, executarAosPares, quantidadeConexoes);
        }

        public void Editar(modelocrud modelo, string stringConexao = "",
            bool executarAosPares = false, int quantidadeConexoes = 0)
        {
            if (stringConexao == "")
            {
                ExecutarComandoSqlServer(modelo.Update_padrao, conecta1, executarAosPares, quantidadeConexoes);
                ExecutarComandoSqlServer(modelo.Update_padrao, conecta2, executarAosPares, quantidadeConexoes);
            }
            else
                ExecutarComandoSqlServer(modelo.Update_padrao, stringConexao, executarAosPares, quantidadeConexoes);
        }

        public void Excluir(modelocrud modelo, string stringConexao = "",
            bool executarAosPares = false, int quantidadeConexoes = 0)
        {
            if (stringConexao == "")
            {
                ExecutarComandoSqlServer(modelo.Delete_padrao, conecta1, executarAosPares, quantidadeConexoes);
                ExecutarComandoSqlServer(modelo.Delete_padrao, conecta2, executarAosPares, quantidadeConexoes);
            }
            else
                ExecutarComandoSqlServer(modelo.Delete_padrao, stringConexao, executarAosPares, quantidadeConexoes);

        }

        private void ExecutarComandoSqlServer(string sql, string stringConexao,
            bool executarAosPares = false, int quantidadeConexoes = 0)
        {
            if (!executarAosPares)
            {
                var conecta = obterconexao(stringConexao);
                SqlCommand comando = new SqlCommand(sql, conecta);

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
                finally
                {
                    fecharconexao(conecta);
                }
            }
            else
            {
                stringsSqlConecta.Add(sql);
                stringsConexao.Add(stringConexao);

                if (stringsSqlConecta.Count == 2 && quantidadeConexoes == 2)
                {

                    List<SqlCommand> lista = new List<SqlCommand>();
                    var conectar = obterconexao(conecta1);
                    var conectar2 = obterconexao(conecta2);
                    foreach (var item in stringsConexao)
                        if (item.Contains("localdb"))
                            lista.Add(new SqlCommand(item, conectar));
                        else
                            lista.Add(new SqlCommand(item, conectar2));


                    SqlTransaction tran = conectar.BeginTransaction();
                    SqlTransaction tran2 = conectar2.BeginTransaction();
                    try
                    {
                        foreach (var item in lista)
                            if (item.Connection.ConnectionString.Contains("localdb"))
                                item.Transaction = tran;
                            else
                                item.Transaction = tran2;

                        lista[0].ExecuteNonQuery();
                        lista[1].ExecuteNonQuery();

                        tran.Commit();
                        tran2.Commit();
                    }
                    catch (SqlException ex)
                    {
                        tran.Rollback();
                        tran2.Rollback();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        conectar.Close();
                        conectar2.Close();
                        stringsSqlConecta.Clear();
                    }

                }

                if (stringsSqlConecta.Count == 4 && quantidadeConexoes == 4)
                {
                    List<SqlCommand> lista = new List<SqlCommand>();
                    var conectar = obterconexao(conecta1);
                    var conectar2 = obterconexao(conecta2);
                    var i = 0;
                    foreach (var item in stringsConexao)
                    {
                        if (item.Contains("localdb"))
                            lista.Add(new SqlCommand(stringsSqlConecta[i], conectar));
                        else
                            lista.Add(new SqlCommand(stringsSqlConecta[i], conectar2));
                        i++;
                    }


                    SqlTransaction tran = conectar.BeginTransaction();
                    SqlTransaction tran2 = conectar2.BeginTransaction();
                    try
                    {
                        foreach (var item in lista)
                            if (item.Connection.ConnectionString.Contains("localdb"))
                                item.Transaction = tran;
                            else
                                item.Transaction = tran2;

                        lista[0].ExecuteNonQuery();
                        lista[1].ExecuteNonQuery();
                        lista[2].ExecuteNonQuery();
                        lista[3].ExecuteNonQuery();

                        tran.Commit();
                        tran2.Commit();
                    }
                    catch (SqlException)
                    {
                        tran.Rollback();
                        tran2.Rollback();
                    }
                    finally
                    {
                        conectar.Close();
                        conectar2.Close();
                        stringsSqlConecta.Clear();
                    }

                }

            }

        }

    }
}
