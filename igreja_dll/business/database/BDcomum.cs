using business.classes;
using business.classes.Abstrato;
using business.classes.Celula;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace database.banco
{
    public class BDcomum
    {
        static string path = Directory.GetCurrentDirectory();
        public static string conecta = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Database.mdf;Integrated Security=True";
       // public static string conecta = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Igreja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public static string addNaLista;
        public int i;

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
        
        public DataTable montar_relatorio(string comand, bool lisbox, bool ministerio, ListBox list)
        {
            Regex regex = new Regex(@"where pes_nome='.?' or pes_cpf='.?'");
            string restricao = regex.Match(comand).ToString();
            
            comand = comand.Replace(restricao, " ");

            if (lisbox)
            {
                if (ministerio)
                {
                    i = 1;
                }else
                {
                    i = 0;
                    comand = comand.Replace("*", "pes_nome");
                    comand += " left join celula_pessoa on pes_id=cel_pessoa " +
                        " where cel_pessoa is null order by pes_nome asc";
                }
               
                
            }

            DataTable dtable = new DataTable();
            SqlCommand comando = new SqlCommand(comand, obterconexao());
            SqlDataAdapter objadp = new SqlDataAdapter(comando);
            objadp.Fill(dtable);


            if (lisbox)
            {
                foreach (DataRow dtrow in dtable.Rows)
                {
                    ArrayList lista = new ArrayList();
                    lista.Add(dtrow);
                    //exibe os registros no listbox
                    list.Items.Add(dtrow.ItemArray[i]);
                }
            }
            return dtable;
        }                   

        public DataTable listar(string comand, bool semsupervisor, bool semcelula, bool listarpessoas, string id)
        {
            if (semsupervisor)
            {
                comand = "select * from celula left join supervisor_celula on id_celula=super_celula " +
                    " where super_celula is null"; 
            }

            if (listarpessoas) 
            {
                comand = "select * from pessoa left join celula_pessoa on pes_id=cel_pessoa " +
                    " inner join celula on id_celula=pes_celula where cel_pessoa is not null and id_celula='@id'";
                comand = comand.Replace("@id", id);
            }

            if (semcelula)
            {
                comand = "select * from pessoa left join celula_pessoa on pes_id=cel_pessoa where cel_pessoa is  null";
            }

            DataTable dtable = new DataTable();
            SqlCommand comando = new SqlCommand(comand, obterconexao());            
            SqlDataAdapter objadp = new SqlDataAdapter(comando);
            objadp.Fill(dtable);

            foreach (DataRow dtrow in dtable.Rows)
            {
                ArrayList lista = new ArrayList();
                lista.Add(dtrow);
                //exibe os registros no listbox
              //  list.Items.Add(dtrow.ItemArray[0]);
            }

            return dtable;
        }

        public DataTable lista(string comand)
        {
            DataTable dtable = new DataTable();
            SqlCommand comando = new SqlCommand(comand, obterconexao());
            SqlDataAdapter objadp = new SqlDataAdapter(comando);
            objadp.Fill(dtable);

            foreach (DataRow dtrow in dtable.Rows)
            {
                ArrayList lista = new ArrayList();
                lista.Add(dtrow);
                //exibe os registros no listbox
                //  list.Items.Add(dtrow.ItemArray[0]);
            }

            return dtable;
        }

       

    }
}
