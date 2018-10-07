using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using igreja2.form.cadastro;
using igreja2.form;
using igreja2.classes;
using igreja2.banco;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Collections;
using System.Drawing.Imaging;

namespace igreja2.banco
{
   public class BDcomum
    {
        public static string conecta1 = @"Data Source=LAPTOP-9LQ8LUGC\SQLEXPRESS;Initial Catalog=igreja2;Integrated Security=True;";
        public string sql;
        public int i;
        SqlParameter imag;
        byte[] imagem;

        public  SqlConnection obterconexao()
        {
            SqlConnection conn = new SqlConnection(conecta1);
            conn.Open();
            return conn;
        }

        public string buscar_dados(string comand, TextBox nome, TextBox cpf, TextBox rg, ListBox estado_civil, TextBox pais, TextBox cep,
            TextBox estado, TextBox cidade, TextBox bairro, TextBox rua, TextBox numero_casa, TextBox complemento, TextBox email, TextBox tel1,
            TextBox tel2, TextBox tel3, ListBox status, TextBox data_nascimento, RadioButton falescimento, PictureBox foto,
            TextBox nome_mae, TextBox nome_pai, TextBox data_visita, ListBox condicao, TextBox trans_cidade, TextBox trans_estado,
            TextBox trans_nome_igreja, TextBox denominacao, TextBox ano_reconciliacao, TextBox ano_batismo, RadioButton desligamento, Label id,
            ListBox data_reuniao_celula, MaskedTextBox horario_celula, TextBox lider, TextBox lider_treinamento, TextBox bairro_celula,
            TextBox rua_celula, TextBox numero_celula, Button botao)
        {
            SqlCommand comando = new SqlCommand(comand, obterconexao());
            Pessoa pes = new Pessoa();

            SqlDataReader dr = comando.ExecuteReader();
           
            if (dr.HasRows == false)
            {
              if(botao != null)
                {
                    botao.DialogResult = DialogResult.Ignore;
                }              
            }
            else
            {
                try
                {                    
                    dr.Read();
                                                          
                    if (id != null)  id.Text = Convert.ToString(dr["pes_id"]); 
                    if (nome!= null) nome.Text = Convert.ToString(dr["pes_nome"]);
                    if (rg != null) rg.Text = Convert.ToString(dr["pes_rg"]);
                    if (rg != null) data_nascimento.Text = Convert.ToString(dr["pes_data_nascimento"]);
                    if (cep != null) cep.Text = Convert.ToString(dr["end_cep"]);
                    if (tel1 != null) tel1.Text = Convert.ToString(dr["tel_telefone"]);
                    if (tel2 != null) tel2.Text = Convert.ToString(dr["tel_celular"]);
                    if (tel3 != null) tel3.Text = Convert.ToString(dr["tel_whatsapp"]);
                    if (cpf != null) cpf.Text = Convert.ToString(dr["pes_cpf"]);
                    if (status != null) status.Text = Convert.ToString(dr["pes_status"]);
                    if (pais != null) pais.Text = Convert.ToString(dr["end_pais"]);
                    if (estado != null) estado.Text = Convert.ToString(dr["end_estado"]);
                    if (cidade != null) cidade.Text = Convert.ToString(dr["end_cidade"]);
                    if (bairro != null) bairro.Text = Convert.ToString(dr["end_bairro"]);
                    if (rua != null) rua.Text = Convert.ToString(dr["end_rua"]);
                    if (complemento != null) complemento.Text = Convert.ToString(dr["end_complemento"]);
                    if (numero_casa != null) numero_casa.Text = Convert.ToString(dr["end_numero"]);
                    if (email != null) email.Text = Convert.ToString(dr["pes_email"]);
                    if (estado_civil != null) estado_civil.Text = Convert.ToString(dr["pes_estado_civil"]);
                    if (falescimento != null) falescimento.Text = Convert.ToString(dr["pes_falescimento"]);
                    if (foto != null) imagem = (byte[])(dr["pes_foto"]);

                    if (imagem == null)
                    {
                        if(foto != null) { foto.Image = null; }                        
                    }
                    else
                    {
                        MemoryStream memory = new MemoryStream(imagem);
                        if (foto != null) { foto.Image = Image.FromStream(memory); }                        
                    }
                   
                    Regex reg6 = new Regex(@"inner join membro on pes_id=memb_pessoa");

                    string membro = reg6.Match(comand).ToString();
                    
                    if (membro != "" && ano_batismo != null && desligamento != null)
                    {                        
                        ano_batismo.Text = Convert.ToString(dr["ano_batismo"]);
                        desligamento.Checked = Convert.ToBoolean(dr["desligamento"]);                      
                    }

                    Regex reg = new Regex(@"inner join visitante on pes_id=visi_pessoa");

                    string visitante = reg.Match(comand).ToString();
                    if (visitante != "" &&  data_visita != null && condicao != null)
                    {
                        data_visita.Text = Convert.ToString(dr["visita"]);
                        condicao.Text = Convert.ToString(dr["condicao_religiosa"]);                     
                    }

                    Regex reg2 = new Regex(@"inner join crianca on pes_id=cri_pessoa");

                    string crianca = reg2.Match(comand).ToString();
                    if (crianca != "" && nome_mae!= null && nome_pai != null)
                    {
                        nome_mae.Text = Convert.ToString(dr["mae"]);
                        nome_pai.Text = Convert.ToString(dr["pai"]);                    
                    }

                    Regex reg3 = new Regex(@"inner join membro on pes_id=memb_pessoa inner join membro_transferencia on id_membro=trans_membro");

                    string membro_transferencia = reg3.Match(comand).ToString();
                    if (membro_transferencia != "" && trans_cidade != null && trans_estado != null && trans_nome_igreja != null)
                    {
                        trans_cidade.Text = Convert.ToString(dr["trans_cidade"]);
                        trans_estado.Text = Convert.ToString(dr["trans_estado"]);
                        trans_nome_igreja.Text = Convert.ToString(dr["trans_nome_igreja"]);                     
                    }

                    Regex reg4 = new Regex(@"inner join membro on pes_id=memb_pessoa inner join membro_aclamacao on id_membro=acla_membro");

                    string membro_aclamacao = reg4.Match(comand).ToString();
                    if (membro_aclamacao != "" && denominacao != null)
                    {
                        denominacao.Text = Convert.ToString(dr["acla_denominacao"]);                    
                    }

                    Regex reg5 = new Regex(@"inner join membro on pes_id=memb_pessoa inner join membro_reconciliacao on id_membro=reco_membro");

                    string membro_reconciliacao = reg5.Match(comand).ToString();
                    if (membro_reconciliacao != "" && ano_reconciliacao != null)
                    {
                        ano_reconciliacao.Text = Convert.ToString(dr["acla_denominacao"]);                    
                    }

                    Regex reg7 = new Regex(@"where id_celula='(\d+)' order by id_celula asc");
                    string celula = reg7.Match(comand).ToString();
                    
                    if (celula != "")
                    { 
                        if(nome != null) nome.Text = Convert.ToString(dr["cel_nome"]);                       
                        if(data_reuniao_celula != null) { data_reuniao_celula.Text = Convert.ToString(dr["cel_dia_semana"]); }
                        if(horario_celula != null)
                        {
                            DateTime hora = Convert.ToDateTime(dr["cel_horario"]);
                            horario_celula.Text = hora.ToString("HH:mm:ss");
                        }
                        if(lider != null) { lider.Text = Convert.ToString(dr["cel_lider"]); }
                        if(lider_treinamento != null) { lider_treinamento.Text = Convert.ToString(dr["cel_lider_treinamento"]); }
                        if(bairro_celula != null) { bairro_celula.Text = Convert.ToString(dr["cel_bairro"]); }
                        if (rua_celula != null){ rua_celula.Text = Convert.ToString(dr["cel_rua"]); }
                        if (numero_celula != null) { numero_celula.Text = Convert.ToString(dr["cel_numero"]); }                        
                    }

                    Regex reg8 = new Regex(@"inner join chamada on pes_id=hist_pessoa where data_inicio>'(\d+)\/(\d+)\/(\d+) (\d+)\:(\d+)\:(\d+)'");
                    string chamada = reg8.Match(comand).ToString();

                    if (chamada != "")
                    {                        
                        while (dr.Read())
                        {
                            Historico historico = new Historico();
                          historico.Id  = int.Parse(Convert.ToString(dr["hist_pessoa"]));
                            historico.Data_inicio = Convert.ToDateTime(dr["data_inicio"]);
                            historico.Data_fim = DateTime.Now;
                            historico.Falta = int.Parse(Convert.ToString(dr["pes_falta"]));
                            comand = "insert into historico (data_inicio, data_fim, falta, pessoa_historico)" +
                            " values ('@data_inicio', '@data_fim', '@falta', '@id_pessoa')";
                            comand = comand.Replace("@data_inicio", historico.Data_inicio.ToString());
                            comand = comand.Replace("@data_fim", historico.Data_fim.ToString());
                            comand = comand.Replace("@falta", historico.Falta.ToString());
                            comand = comand.Replace("@id_pessoa", historico.Id.ToString());
                            montar_sql(comand, null, null);
                        }
                    }

                    Regex reg9 = new Regex(@"inner join supervisor on pes_id=super_pessoa where pes_id='(\d+)'");
                    string supervisor = reg9.Match(comand).ToString();
                    if(supervisor != "")
                    {
                      if (nome != null)  nome.Text = Convert.ToString(dr["pes_nome"]); 
                    }

                    dr.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    if (botao != null)
                    {
                        botao.DialogResult = DialogResult.Ignore;
                    }
                }
                finally
                {
                    obterconexao().Close();
                }

                
            }
           return comand;
        }

        public string montar_sql(string comand, PictureBox imagem, Label id)
        {            
            if (imagem != null)
            {
                comand = "update pessoa set pes_foto=@foto where pes_id=@id";
                MemoryStream memory = new MemoryStream();
                Bitmap btp = new Bitmap(imagem.ImageLocation);
                btp.Save(memory, ImageFormat.Bmp);
                byte[] foto = memory.ToArray();
                imag = new SqlParameter("@foto", SqlDbType.Image);
                imag.Value = foto;

                if (id != null)
                {
                    comand = comand.Replace("@id", id.Text);                    
                }
                else
                {
                    comand = comand.Replace("@id", "IDENT_CURRENT('pessoa')");                  
                }
            }
            SqlCommand comando = new SqlCommand(comand, obterconexao());
            if (imagem != null)
            {
                comando.Parameters.Add(imag);
            }
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
           
            return comand;
        }

        public string visualizar(string comand, DataGridView data, CheckBox documento, CheckBox telefone, CheckBox endereco, CheckBox falta,
            NumericUpDown idade_maior, NumericUpDown idade_menor, RadioButton sexo_masculino, RadioButton sexo_feminino, ListBox estado_civil,
            ListBox status, CheckBox desligamento, CheckBox falescimento)
        {
            Regex regex = new Regex(@"where pes_nome='.?' or pes_cpf='.?'");
            string restricao = regex.Match(comand).ToString();

            comand = comand.Replace(restricao, "");

            if (documento.Checked)
            {              
                comand = comand.Replace("*", "pes_nome, pes_rg, pes_cpf, pes_data_nascimento");
            }

            if (telefone.Checked)
            {
                comand = comand.Replace("*", "pes_nome, tel_telefone, tel_celular, tel_whatsapp");
            }

            if (endereco.Checked)
            {
                comand = comand.Replace("*", "pes_nome, end_cep, end_pais, end_estado, end_cidade, end_bairro, end_rua, end_numero, end_complemento");
            }

            if (falta.Checked)
            {
                comand = comand.Replace("*", "pes_nome, pes_falta");
            }

           

            DateTime atual = DateTime.Now;
            comand += "where pes_data_nascimento<='@data_nascimento' and pes_data_nascimento>='@data2' ";
                
            comand = comand.Replace("@data_nascimento", atual.AddDays((-365) * int.Parse(idade_maior.Text) + 1).ToString());
            comand = comand.Replace("@data2", atual.AddDays((-365) * int.Parse(idade_menor.Text)).ToString());

            if (sexo_feminino.Checked || sexo_masculino.Checked)
            {
                comand += "and pes_sexo_masculino='@sexo_masculino' ";
                comand = comand.Replace("@sexo_masculino", sexo_masculino.Checked.ToString());
            }

            if(estado_civil.Text != "")
            {
                comand += "and pes_estado_civil='@estado_civil' ";
                comand = comand.Replace("@estado_civil", estado_civil.Text);
            }

            if (status.Text != "")
            {
                comand += "and pes_status='@status' ";
                comand = comand.Replace("@status", status.Text);
            }

            if (falescimento.Checked)
            {
                comand += "and pes_falescimento='@falescimento' ";
                comand = comand.Replace("@falescimento", falescimento.Checked.ToString());
            }

            if (desligamento.Checked)
            {
                comand += "and desligamento='@desligamento' ";
                comand = comand.Replace("@desligamento", desligamento.Checked.ToString());
            }



            MessageBox.Show(comand);

            SqlCommand comando = new SqlCommand(comand, obterconexao());

            SqlDataAdapter objadp = new SqlDataAdapter(comando);
            DataTable dtlista = new DataTable();

            objadp.Fill(dtlista);
            data.DataSource = dtlista;

            return "";
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

    }
}
