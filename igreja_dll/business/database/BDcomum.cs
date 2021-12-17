using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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

        public void SalvarModelo(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Insert_padrao, conecta1);                       
            ExecutarComandoSqlServer(modelo.Insert_padrao, conecta2);                       
        }

        public void Editar(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Update_padrao, conecta1);
            ExecutarComandoSqlServer(modelo.Update_padrao, conecta2);
        }

        public void Excluir(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Delete_padrao, conecta1);
            ExecutarComandoSqlServer(modelo.Delete_padrao, conecta2);
        }

        private void ExecutarComandoSqlServer(string sql, string stringConexao)
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

    }
}
