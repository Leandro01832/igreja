using business.classes.Abstrato;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace database.banco
{
    public class BDcomum
    {
        static string path = Directory.GetCurrentDirectory();
      //  public static string conecta = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
        public static string conecta = $@"Data Source=database-igreja.mssql.somee.com;packet size=4096;user id=lls01833_SQLLogin_1;pwd=tsobwjtsix;data source=database-igreja.mssql.somee.com;persist security info=False;initial catalog=database-igreja";
      
        
        public static string addNaLista;

        public static bool BancoEnbarcado = false;

        public  SqlConnection obterconexao()
        {
            try
            {
                SqlConnection conn = new SqlConnection(conecta);
                
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Você não esta conectado. " + ex.Message);
                return null;
            }
        }

        public void SalvarModelo(modelocrud modelo)
        {
            ExecutarComandoSqlServer(modelo.Insert_padrao);
            addNaLista = "";

            if(modelo is Pessoa)
            {
                var p = (Pessoa)modelo;
                p.IdPessoa = Pessoa.recuperarTodos().OfType<Pessoa>().OrderBy(m => m.IdPessoa).Last().IdPessoa;
            }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                obterconexao().Close();
            }

        }

    }
}
