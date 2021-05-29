using business.classes;
using business.classes.Abstrato;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


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

        private SqlConnection conn;

        public  SqlConnection obterconexao()
        {
            if(conn == null)
                conn = new SqlConnection(conecta2);

            if (conn.State == ConnectionState.Open && !podeAbrir || conn.State == ConnectionState.Closed && !podeAbrir)
            {
                conn.Dispose();
            }

            return conn;            
        }

        public void fecharconexao()
        {
            var conexao = obterconexao();
            if (conexao.State == ConnectionState.Open)
                conexao.Close();
        }

        public void abrirconexao()
        {
            var conexao = obterconexao();
            if (conexao.State == ConnectionState.Closed && podeAbrir)
                conexao.Open();
        }

        public void SalvarModelo(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Insert_padrao);
            addNaLista = "";

            if(modelo is Pessoa)
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
            try
            {
                con = obterconexao();
                
                cmd = new SqlCommand("SELECT TOP(1) IdPessoa FROM Pessoa order by IdPessoa desc", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Id = int.Parse(dr["IdPessoa"].ToString());
                dr.Close();
                con.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
            return Id;
        }

        public int GetUltimoRegistroCelula()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = obterconexao();
                
                cmd = new SqlCommand("SELECT TOP(1) IdCelula FROM Celula order by IdCelula desc", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Id = int.Parse(dr["IdCelula"].ToString());
                dr.Close();
                con.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
            return Id;
        }

        public int GetUltimoRegistroMinisterio()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = obterconexao();
                
                cmd = new SqlCommand("SELECT TOP(1) IdMinisterio FROM Celula order by IdMinisterio desc", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Id = int.Parse(dr["IdMinisterio"].ToString());
                dr.Close();
                con.Close();
                
            }
            catch (Exception)
            {
                throw;
            }
            return Id;
        }

        public int GetUltimoRegistroReuniao()
        {
            var Id = 0;
            SqlConnection con;
            SqlCommand cmd;
            try
            {
                con = obterconexao();
                
                cmd = new SqlCommand("SELECT TOP(1) IdReuniao FROM Celula order by IdReuniao desc", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Id = int.Parse(dr["IdReuniao"].ToString());
                dr.Close();
                con.Close();
                
            }
            catch (Exception)
            {
                throw;
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
            conecta.Open();
            SqlCommand comando = new SqlCommand(sql, conecta);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                obterconexao().Close();
            }

        }

    }
}
