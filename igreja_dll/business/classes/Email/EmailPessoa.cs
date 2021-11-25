using business.classes.Pessoas;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace business
{
    [Table("EmailPessoa")]
    public class EmailPessoa : Email
    {
        private static int UltimoRegistro;

        public string Remetente { get; set; }

        public string ConteudoTexto { get; set; }
        public string Body { get; set; }
        public int? AtendenteId { get; set; }
        public virtual Atendente Atendente { get; set; }
        

        public static int BuscarUltimoId()
        {
            SqlConnection con;
            SqlCommand cmd;
            // var stringConexao = "Data Source=database-advocacia.mssql.somee.com;packet size=4096;user id=leandro01835_SQLLogin_1;pwd=cuiom27is7;data source=database-advocacia.mssql.somee.com;persist security info=False;initial catalog=database-advocacia";
            var stringConexao = "Data Source=DESKTOP-5HMQJL9;Initial Catalog=Database-Email;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (con = new SqlConnection(stringConexao))
            {
                cmd = new SqlCommand("SELECT TOP(1) Id FROM Email where Discriminator='EmailCliente' order by Id desc", con);
                con.Open();
                UltimoRegistro = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
            }
            return UltimoRegistro; 
        }


    }
}
