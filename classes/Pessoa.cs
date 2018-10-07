using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using igreja2.banco;
using System.Data.SqlClient;
using igreja2.form.cadastro;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;

namespace igreja2.classes
{
   public class Pessoa : Endereco
    {
        private int      id_pessoa;
        private string   nome;
        private DateTime data_nascimento;
        private string   rg;
        private string   cpf;
        private string   estado_civil;
        private bool     sexo_masculino;
        private bool     sexo_feminino;
        private bool     falescimento;
        private string   status;        
        private string   email;
        private int      falta;
        private Celula   celula;
        Bitmap btp;
        private  string  img;

        public int Id_pessoa
        {
            get
            {
                return id_pessoa;
            }

            set
            {
                id_pessoa = value;
            }
        }

        public string Nome
        {
            
            get
            {           
                return nome;
                
              
            }

            set
            {
                if (value != "")
                { nome = value; }
                else
                {
                    MessageBox.Show("nome precisa ser preenchido corretamente!!!");
                    nome = null;
                }
                
            }
        }

        public DateTime Data_nascimento
        {
            get
            {
                return data_nascimento;
            }

            set
            {
                data_nascimento = value;
            }
        }

        public string Rg
        {
            get
            {
                return rg;
            }

            set
            { 
                if (value != "")
                {
                    rg = value;
                }
                else
                {
                    MessageBox.Show("RG precisa ser preenchido corretamente");
                    rg = null;
                }                
            }
        }

        public string Cpf
        {
            get
            {                
                return cpf ;
            }

            set
            {
                if (value != "")
                    cpf = value;
                else
                {
                    MessageBox.Show("CPF precisa ser preenchido corretamente");
                    cpf = null;
                }                                   
            }
        }

        public string Estado_civil
        {
            get
            {
                return estado_civil;
            }

            set
            {
                if(value != "")
                estado_civil = value;
                else
                {
                    MessageBox.Show("Estado civil precisa ser preenchido corretamente");
                    estado_civil = null;
                }
            }
        }

        public bool Sexo_masculino
        {
            get
            {
                return sexo_masculino;
            }

            set
            {
                sexo_masculino = value;
            }
        }

        public bool Sexo_feminino
        {
            get
            {
                return sexo_feminino;
            }

            set
            {
                sexo_feminino = value;
            }
        }

        public bool Falescimento
        {
            get
            {
                return falescimento;
            }

            set
            {
                falescimento = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                if (value != "")
                status = value;
                else
                {
                    MessageBox.Show("Estado civil precisa ser preenchido corretamente");
                    status = null;
                }
            }
        }      

        public string Email
        {
            get
            {
                return email;
            }

            set
            {                
                email = value;
            }
        }

        public int Falta
        {
            get
            {
                return falta;
            }

            set
            {
                falta = value;
            }
        }

        internal Celula Celula
        {
            get
            {
                return celula;
            }

            set
            {
                celula = value;
            }
        }   

        public string Img
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
            }
        }

        public Pessoa()
        {
            bd = new BDcomum();
            
        }     

       

        public override string salvar()
        {
            
                insert_padrao = "insert into pessoa (pes_nome, pes_data_nascimento, pes_estado_civil, pes_sexo_masculino, " +
         "pes_rg, pes_cpf, pes_sexo_feminino, pes_falescimento, " +
         "pes_email, pes_status, pes_falta)" +
         " values ('@nome', '@data_nascimento', '@estado_civil', '@sexo_masculino'," +
         " '@rg', '@cpf', '@sexo_feminino', '@falescimento', '@email', " +
         " '@status', '@faltas') " + 
         "insert into telefone (tel_telefone, tel_celular, tel_whatsapp, tel_pessoa) values ('@telefone', '@celular', '@whatsapp', IDENT_CURRENT('pessoa')) " +
         "insert into endereco (end_pais, end_estado, end_cidade, end_bairro, end_rua, end_numero, end_cep, end_complemento, end_pessoa) values " +
         " ('@pais', '@estado', '@cidade', '@bairro', '@rua', '@numero_casa', '@cep', '@complemento', IDENT_CURRENT('pessoa'))"; 
           
            Insert = insert_padrao.Replace("@nome", nome);
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = data_nascimento.ToString("yyyy-MM-dd 00.00.00.000");
            Insert = Insert.Replace("@data_nascimento", data_nascimento.ToString());
            Insert = Insert.Replace("@estado_civil", estado_civil);
            Insert = Insert.Replace("@sexo_masculino", sexo_masculino.ToString());
            Insert = Insert.Replace("@rg", rg);
            Insert = Insert.Replace("@cpf", cpf);
            Insert = Insert.Replace("@sexo_feminino", sexo_feminino.ToString());
            Insert = Insert.Replace("@email", email);
            Insert = Insert.Replace("@status", status);
            Insert = Insert.Replace("@faltas", falta.ToString());
            Insert = Insert.Replace("@falescimento", false.ToString());            
            Insert = Insert.Replace("@telefone", this.Fone);
            Insert = Insert.Replace("@celular", this.Celular);
            Insert = Insert.Replace("@whatsapp", this.Whatsapp);
            Insert = Insert.Replace("@pais", this.Pais);
            Insert = Insert.Replace("@estado", this.Estado);
            Insert = Insert.Replace("@cidade", this.Cidade);
            Insert = Insert.Replace("@bairro", this.Bairro);
            Insert = Insert.Replace("@rua", this.Rua);
            Insert = Insert.Replace("@numero_casa", this.Numero_casa.ToString());
            Insert = Insert.Replace("@cep", Cep.ToString());
            Insert = Insert.Replace("@complemento", this.Complemento);       
            
            return bd.montar_sql(Insert, null, null);            
        }

        public override string alterar()
        {
            update_padrao = "update pessoa set pes_nome='@nome_pessoa', pes_estado_civil='@estado_civil', " +
            "pes_rg='@rg', pes_cpf='@cpf', pes_falescimento='@falescimento', pes_email='@email', pes_status='@status' " +
            "  where pes_nome='@nome_pessoa' or pes_cpf='@cpf' " +
            " update endereco set end_pais ='@pais', end_estado = '@estado',  end_cep = '@cep', " +
            " end_cidade = '@cidade', end_bairro = '@bairro', end_rua = '@rua', " +
            " end_numero=@numero,  end_complemento='@complemento' from endereco as E inner join pessoa as P on P.pes_id=E.end_pessoa where " +
            "pes_nome='@nome_pessoa' or pes_cpf='@cpf' " +
            "update telefone set tel_telefone = '@telefone', tel_celular = '@celular', tel_whatsapp = '@whatsapp' " +
            " from telefone as T inner join pessoa as P on P.pes_id=T.tel_pessoa where pes_nome='@nome_pessoa' or pes_cpf='@cpf'";

            bd = new BDcomum();

            Update = update_padrao.Replace("@nome_pessoa", nome);            
            string sqlFormattedDate = data_nascimento.ToString("yyyy-MM-dd 00.00.00.000");
            Update = Update.Replace("@data_nascimento", data_nascimento.ToString());
            Update = Update.Replace("@estado_civil", estado_civil);
            Update = Update.Replace("@sexo_masculino", sexo_masculino.ToString());
            Update = Update.Replace("@rg", rg);
            Update = Update.Replace("@cpf", cpf);
            Update = Update.Replace("@sexo_feminino", sexo_feminino.ToString());
            Update = Update.Replace("@email", email);
            Update = Update.Replace("@status", status);
            Update = Update.Replace("@faltas", falta.ToString());
            Update = Update.Replace("@falescimento", false.ToString());

            Update = Update.Replace("@telefone", this.Fone);
            Update = Update.Replace("@celular", this.Celular);
            Update = Update.Replace("@whatsapp", this.Whatsapp);
            Update = Update.Replace("@pais", this.Pais);
            Update = Update.Replace("@estado", this.Estado);
            Update = Update.Replace("@cidade", this.Cidade);
            Update = Update.Replace("@bairro", this.Bairro);
            Update = Update.Replace("@rua", this.Rua);
            Update = Update.Replace("@numero", this.Numero_casa.ToString());
            Update = Update.Replace("@cep", this.Cep.ToString());
            Update = Update.Replace("@complemento", this.Complemento);

           return bd.montar_sql(Update, null, null);

        }

        public override string excluir()
        {
            delete_padrao = "delete from pessoa where pes_nome='@nome'";
            Delete = delete_padrao.Replace("@nome", nome);

            return Delete;
        }

        public override string recuperar()
        {
            bd = new BDcomum();
            select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa inner join telefone on pes_id=tel_pessoa @innerjoin where pes_nome='@nome' or pes_cpf='@cpf' or pes_id='@id'";

            Select = select_padrao.Replace("@nome", nome);
            Select = Select.Replace("@cpf", cpf);
            Select = Select.Replace("@innerjoin", "");
            Select = Select.Replace("@id", id_pessoa.ToString());


            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public virtual void foto(PictureBox foto)
        {
            
             try
             {

                 OpenFileDialog dlg = new OpenFileDialog();
                 dlg.InitialDirectory = @"C:\Release\imagens";
                 dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                 dlg.Title = "selecione uma imagem";
                 if (dlg.ShowDialog() == DialogResult.OK)
                 {
                    string imagem;
                     imagem = dlg.FileName;
                    foto.ImageLocation = imagem;
                    Img = imagem;
                    btp = new Bitmap(imagem);

                    foto.Image = btp;                  
                }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }    

    }
}
