using business.classes;
using business.classes.Abstrato;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace database.banco
{
    public class BDcomum
    {
        static string path = Directory.GetCurrentDirectory();
        public static string conecta1 = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
        public static string conecta2 = $@"Data Source=database-igreja.mssql.somee.com;packet size=4096;user id=lls01833_SQLLogin_1;pwd=tsobwjtsix;data source=database-igreja.mssql.somee.com;persist security info=False;initial catalog=database-igreja";


        public static string addNaLista;
        public static bool podeAbrir = true;
        public static bool BancoEnbarcado = false;

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
            SqlConnection conn = null;
            if (podeAbrir)
            {
                try
                {
                 conn = new SqlConnection(conecta2);
                 conn.Open();
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
            if (!podeAbrir)
            {
                if (TestarConexao())
                {
                    podeAbrir = true;
                    conn = new SqlConnection(conecta2);
                    try { conn.Open(); }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("instância"))
                        {
                            MessageBox.Show("Você não esta conectado." + ex.Message);
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
            addNaLista = "";

            if (modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                p.IdPessoa = GetUltimoRegistroPessoa();
            }
            else
            if (modelo is Celula)
            {
                var p = (Celula)modelo;
                p.IdCelula = GetUltimoRegistroCelula();
            }
            else
            if (modelo is Ministerio)
            {
                var p = (Ministerio)modelo;
                p.IdMinisterio = GetUltimoRegistroMinisterio();
            }
            else
            if (modelo is Reuniao)
            {
                var p = (Reuniao)modelo;
                p.IdReuniao = GetUltimoRegistroReuniao();
            }
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

                    cmd = new SqlCommand("SELECT TOP(1) IdPessoa FROM Pessoa order by IdPessoa desc", con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["IdPessoa"].ToString());
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

                    cmd = new SqlCommand("SELECT TOP(1) IdCelula FROM Celula order by IdCelula desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["IdCelula"].ToString());
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

                    cmd = new SqlCommand("SELECT TOP(1) IdMinisterio FROM Ministerio order by IdMinisterio desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["IdMinisterio"].ToString());
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

                    cmd = new SqlCommand("SELECT TOP(1) IdReuniao FROM Reuniao order by IdReuniao desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Id = int.Parse(dr["IdReuniao"].ToString());
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
            addNaLista = "";
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
