using business.classes;
using business.classes.Abstrato;
using System;
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
        
        public static bool podeAbrir = true;
        public static bool BancoEnbarcado = true;

        public bool TestarConexao()
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

        public SqlConnection obterconexao()
        {
            conecta1 = conecta1.Replace("Tests", "WindowsFormsApp1");

            SqlConnection conn = null;
            if (podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BancoEnbarcado) stringConexao = conecta1;
                    else stringConexao = conecta2;
                    conn = new SqlConnection(stringConexao);
                    conn.Open();
                    modelocrud.Erro_Conexao = false;
                    modelocrud.QuantErro = 0;
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
                    var stringConexao = "";
                    if (BancoEnbarcado) stringConexao = conecta1;
                    else stringConexao = conecta2;
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
            ExecutarComandoSqlServer(modelo.Insert_padrao);

            if (modelo is Pessoa)
                modelo.Id = GetUltimoRegistroPessoa();
            else
            if (modelo is Celula)
                modelo.Id = GetUltimoRegistroCelula();
            else
            if (modelo is Ministerio)
                modelo.Id = GetUltimoRegistroMinisterio();
            else
            if (modelo is Reuniao)
                modelo.Id = GetUltimoRegistroReuniao();
        }

        public int GetUltimoRegistroPessoa()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (podeAbrir)
            {
                try
                {
                    con = obterconexao();

                    cmd = new SqlCommand("SELECT TOP(1) Id FROM Pessoa order by Id desc", con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["Id"].ToString());
                    dr.Close();
                    fecharconexao(con);

                }
                catch (Exception)
                {
                    podeAbrir = false;
                } 
            }
            return Id;
        }

        public int GetUltimoRegistroCelula()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (podeAbrir)
            {
                try
                {
                    con = obterconexao();

                    cmd = new SqlCommand("SELECT TOP(1) Id FROM Celula order by Id desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["Id"].ToString());
                    dr.Close();
                    fecharconexao(con);

                }
                catch (Exception)
                {
                    podeAbrir = false;
                } 
            }
            return Id;
        }

        public int GetUltimoRegistroMinisterio()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (podeAbrir)
            {
                try
                {
                    con = obterconexao();

                    cmd = new SqlCommand("SELECT TOP(1) Id FROM Ministerio order by Id desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["Id"].ToString());
                    dr.Close();
                    fecharconexao(con);

                }
                catch (Exception)
                {
                    podeAbrir = false;
                } 
            }
            return Id;
        }

        public int GetUltimoRegistroReuniao()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (podeAbrir)
            {
                try
                {
                    con = obterconexao();

                    cmd = new SqlCommand("SELECT TOP(1) Id FROM Reuniao order by Id desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["Id"].ToString());
                    dr.Close();
                    fecharconexao(con);

                }
                catch (Exception)
                {
                    podeAbrir = false;
                } 
            }
            return Id;
        }

        public void Editar(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Update_padrao);
        }

        public void Excluir(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Delete_padrao);
        }

        private void ExecutarComandoSqlServer(string sql)
        {
            var conecta = obterconexao();
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
