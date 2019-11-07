﻿using System;
using System.Windows.Forms;
using System.Drawing;
using database.banco;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace business.classes
{
        
    public class Pessoa : modelocrud<Pessoa>  
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_nascimento { get; set; }


        [Display(Name = "RG")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Rg { get; set; }


        [Display(Name = "CPF")]
        [StringLength(11)]
        [Index("CPF", 2, IsUnique = true)]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Cpf { get; set; }

        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Estado_civil { get; set; }

        [Display(Name = "Sexo masculino")]
        public bool Sexo_masculino { get; set; }

        [Display(Name = "Sexo feminino")]
        public bool Sexo_feminino { get; set; }

        [ScaffoldColumn(false)]
        public bool Falescimento { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [ScaffoldColumn(false)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public int Falta { get; set; }

        
        public int? celula_ { get; set; }
        [ForeignKey("celula_")]
        public virtual Celula Celula { get; set; }
        
        public virtual Endereco Endereco { get; set; }
        
        public virtual Telefone Telefone { get; set; }

        public virtual Chamada Chamada { get; set; }
       
        public virtual List<Ministerio> Ministerios { get; set; }

        public virtual List<Historico> Historico { get; set; }

        public virtual List<Reuniao> Reuniao { get; set; }

        [Display(Name = "Foto do perfil")]
        public byte[] Img { get; set; }

        [ScaffoldColumn(false)]
        public string imgtipo { get; set; }

        [ScaffoldColumn(false)]
        public string classe { get; set; }

                       

        public Pessoa()
        {
            bd = new BDcomum();            
        }

        /// <summary>
        /// contrutor para buscar pessoa atraves do id
        /// </summary>
        /// <param name="id"></param>
        public Pessoa(int id)
        {
            bd = new BDcomum();
            recuperar(id);
        }

        public override string salvar()
        {           

            insert_padrao = 
     "insert into Pessoa (Nome, Data_nascimento, Estado_civil, Sexo_masculino, " +
     "Rg, Cpf, Sexo_feminino, Falescimento, " +
     "Email, Status, Falta, imgtipo, celula_, Img)" +
     " values ('@nome', '@data_nascimento', '@estado_civil', '@sexo_masculino'," +
     " '@rg', '@cpf', '@sexo_feminino', '@falescimento', '@email', " +
     " '@status', '@faltas', '@imgtipo', '@celula', '@foto') " +
     this.Telefone.salvar() + " " +
     this.Endereco.salvar() + " " +
     this.Chamada.salvar();        
           
            Insert = insert_padrao.Replace("@nome", Nome);
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = this.Data_nascimento.ToString("yyyy-MM-dd 00.00.00.000");
            Insert = Insert.Replace("@data_nascimento", this.Data_nascimento.ToString("yyyy-MM-dd"));
            Insert = Insert.Replace("@estado_civil", this.Estado_civil);
            Insert = Insert.Replace("@sexo_masculino", this.Sexo_masculino.ToString());
            Insert = Insert.Replace("@rg", this.Rg);
            Insert = Insert.Replace("@cpf", this.Cpf);
            Insert = Insert.Replace("@sexo_feminino", this.Sexo_feminino.ToString());
            Insert = Insert.Replace("@email", this.Email);
            Insert = Insert.Replace("@status", this.Status);
            Insert = Insert.Replace("@faltas", this.Falta.ToString());
            Insert = Insert.Replace("@falescimento", false.ToString());
            Insert = Insert.Replace("@imgtipo", "");
            if (this.celula_ == null)
            {
                Insert = Insert.Replace(", '@celula'", null);
                Insert = Insert.Replace(", celula_", null);
            }
            else
            {
                Insert = Insert.Replace("@celula", this.celula_.ToString()); 
            }
            
            SqlParameter imag = new SqlParameter("@foto", SqlDbType.Image);
            imag.Value = this.Img;

            return bd.montar_sql(Insert, null, null);            
        }

        public override string alterar( int id)
        {
       update_padrao = "update Pessoa set Nome='@nome_pessoa', Estado_civil='@estado_civil', " +
       "Rg='@rg', Cpf='@cpf', Falescimento='@falescimento', Email='@email', Status='@status' " +
       "  where Id='@id' " +
       "update Telefone set Fone = '@telefone', Celular = '@celular', Whatsapp = '@whatsapp' " +
       " from Telefone as T inner join Pessoa as P on T.telefoneid=P.Id where P.Id='@id'" +
       " update Endereco set Pais ='@pais', Estado = '@estado',  Cep = '@cep', " +
       " Cidade = '@cidade', Bairro = '@bairro', Rua = '@rua', " +
       " Numero_casa=@numero,  Complemento='@complemento' from Endereco as E inner join Pessoa as P on E.EnderecoId=P.Id where " +
       "P.Id='@id' ";

            bd = new BDcomum();

            Update = update_padrao.Replace("@nome_pessoa", Nome);
            Update = Update.Replace("@id", id.ToString());            
            string sqlFormattedDate = this.Data_nascimento.ToString("yyyy-MM-dd 00.00.00.000");
            Update = Update.Replace("@data_nascimento", this.Data_nascimento.ToString());
            Update = Update.Replace("@estado_civil", this.Estado_civil);
            Update = Update.Replace("@sexo_masculino", this.Sexo_masculino.ToString());
            Update = Update.Replace("@rg", this.Rg);
            Update = Update.Replace("@cpf", this.Cpf);
            Update = Update.Replace("@sexo_feminino", Sexo_feminino.ToString());
            Update = Update.Replace("@email", this.Email);
            Update = Update.Replace("@status", this.Status);
            Update = Update.Replace("@faltas", this.Falta.ToString());
            Update = Update.Replace("@falescimento", false.ToString());

            Update = Update.Replace("@telefone", this.Telefone.Fone);
            Update = Update.Replace("@celular", this.Telefone.Celular);
            Update = Update.Replace("@whatsapp", this.Telefone.Whatsapp);

            Update = Update.Replace("@pais", this.Endereco.Pais);            
            Update = Update.Replace("@estado", this.Endereco.Estado);
            Update = Update.Replace("@cidade", this.Endereco.Cidade);
            Update = Update.Replace("@bairro", this.Endereco.Bairro);
            Update = Update.Replace("@rua", this.Endereco.Rua);
            Update = Update.Replace("@numero", this.Endereco.Numero_casa.ToString());
            Update = Update.Replace("@cep", this.Endereco.Cep.ToString());
            Update = Update.Replace("@complemento", this.Endereco.Complemento);


            return bd.montar_sql(Update, null, null);

        }

        public override string excluir(int id)
        {
            delete_padrao = "delete from Pessoa as P where P.Id='@id'" +
                " delete Telefone from Telefone as T inner " +
                " join Pessoa as P on T.telefoneid=P.Id" +
                " where P.Id='@id' " +
                "delete Endereco from Endereco as E inner " +
                "join Pessoa as P on E.EnderecoId=P.Id" +
                " where P.Id='@id'";
            Delete = delete_padrao.Replace("@id", id.ToString());

            bd.montar_sql(Delete, null, null);
            
            return Delete;
        }

        public override Pessoa recuperar(int id)
        {       
           
            select_padrao = "select * from Pessoa as P "
           + " inner join Endereco as E on E.EnderecoId=P.Id " 
           + " inner join Telefone as T on T.telefoneid=P.Id "
           + " left join Celula as CEL on CEL.Celulaid=P.celula_ "
           + " left join Endereco_celula as ENCEL on ENCEL.enderecoid=CEL.Celulaid "
           + " left join Chamada as CH on CH.chamadaid=P.Id "
           + " left join ReuniaoPessoa as REPE on REPE.Pessoa_Id=P.Id "
           + " left join MinisterioPessoa as MIPE on MIPE.Pessoa_Id=P.Id "
           + " left join Historico as H on H.pessoaid=P.Id "
           + " left join Lider as L on L.Liderid=P.Id "
           + " left join Lider_treinamento as LT on LT.lidertreinamentoid=P.Id "
           + " left join Supervisor as S on S.Supervisorid=P.Id "
           + " left join Supervisor_treinamento as ST on ST.Supervisortreinamentoid=P.Id "
           + " where  P.Id='" + id+"'";

            Select = select_padrao.Replace("@id", Id.ToString());            
            Select = Select.Replace("@innerjoin", "inner join Chamada as CH on CH.chamadaid=P.ID");

            SqlCommand comando = new SqlCommand(Select, bd.obterconexao());

            SqlDataReader dr = comando.ExecuteReader();

            if (dr.HasRows == false)
            {
                return null;
            }
            else
            {
                try
                {
                    dr.Read();
                    this.Img = (byte[])(dr["Img"]);
                    this.Id = int.Parse(Convert.ToString(dr["Id"]));
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Email = Convert.ToString(dr["Email"]);
                    this.Falta = int.Parse(dr["Falta"].ToString());
                    this.Estado_civil = Convert.ToString(dr["Estado_civil"]);
                    this.Falescimento = Convert.ToBoolean(Convert.ToString(dr["Falescimento"]));
                    this.Sexo_feminino = Convert.ToBoolean(Convert.ToString(dr["Sexo_feminino"]));
                    this.Sexo_masculino = Convert.ToBoolean(Convert.ToString(dr["Sexo_masculino"]));
                    this.Rg = Convert.ToString(dr["Rg"]);
                    this.Data_nascimento = Convert.ToDateTime(Convert.ToString(dr["Data_nascimento"]));
                    this.Cpf = Convert.ToString(dr["Cpf"]);
                    this.Status = Convert.ToString(dr["Status"]);
                    this.Telefone = new Telefone();                   
                    this.Telefone.Fone = Convert.ToString(dr["Fone"]);
                    this.Telefone.Celular = Convert.ToString(dr["Celular"]);
                    this.Telefone.Whatsapp = Convert.ToString(dr["Whatsapp"]);
                    this.Endereco = new Endereco();
                    this.Endereco.Cep = long.Parse(Convert.ToString(dr["Cep"]));
                    this.Endereco.Pais = Convert.ToString(dr["Pais"]);
                    this.Endereco.Estado = Convert.ToString(dr["Estado"]);
                    this.Endereco.Cidade = Convert.ToString(dr["Cidade"]);
                    this.Endereco.Bairro = Convert.ToString(dr["Bairro"]);
                    this.Endereco.Rua = Convert.ToString(dr["Rua"]);
                    this.Endereco.Complemento = Convert.ToString(dr["Complemento"]);
                    this.Endereco.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
                    this.Chamada = new Chamada();
                    this.Chamada.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                    this.Chamada.Numero_chamada = int.Parse(dr["Numero_chamada"].ToString());
                    this.Celula = new Celula();
                    this.Celula.Celulaid = int.Parse(dr["Celulaid"].ToString());
                    this.Celula.Supervisor_ = int.Parse(dr["Supervisor_"].ToString());
                    this.Celula.Supervisortreinamento_ = int.Parse(dr["Supervisortreinamento_"].ToString());              
                    this.Celula.Pessoas = this.Celula.preenchercelula(this.Celula.Celulaid);
                    this.Celula.Maximo_pessoa = int.Parse(dr["Maximo_pessoa"].ToString());
                    this.Celula.Horario = TimeSpan.Parse(dr["Horario"].ToString());
                    this.Celula.Nome = dr["Nome"].ToString();
                    this.Celula.Dia_semana = dr["Dia_semana"].ToString();
                    this.Celula.Endereco_Celula = new Endereco_Celula();
                    this.Celula.Endereco_Celula.Cel_bairro = dr["Cel_bairro"].ToString();
                    this.Celula.Endereco_Celula.Cel_numero = int.Parse(dr["Cel_numero"].ToString());
                    this.Celula.Endereco_Celula.Cel_rua = dr["Cel_rua"].ToString();
                    


                    while (dr.Read())
                    {
                        Historico h = new Historico();
                        h.Data_inicio = Convert.ToDateTime(dr["Data_inicio"]);
                        h.Falta = int.Parse(dr["Falta"].ToString());
                        this.Historico.Add(h);

                        Ministerio m = new Ministerio();
                        m.Ministerioid = int.Parse(dr["ministerioid"].ToString());
                        m.Nome = dr["Nome"].ToString();
                       // m.lider_ministerio = int.Parse(dr["Lider_ministerio"].ToString());
                        m.Proposito = dr["proposito"].ToString();
                        m.Pessoas = m.preencherministerio(m.Ministerioid);
                        this.Ministerios.Add(m);

                        Reuniao r = new Reuniao();
                        r.Data_reuniao = Convert.ToDateTime(dr["Data_reuniao"]);
                        r.Horario_inicio = Convert.ToDateTime(dr["Horario_inicio"]);
                        r.Horario_fim = Convert.ToDateTime(dr["Horario_fim"]);
                        r.Local_reuniao = dr["Local_reuniao"].ToString();
                        this.Reuniao.Add(r);
                    }                    

                    dr.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                  
                }
                finally
                {
                    bd.obterconexao().Close();
                }

                return this;
            }
            
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
                   // Img = imagem;
                  //  btp = new Bitmap(imagem);

                  //  foto.Image = btp;                  
                }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        public override IEnumerable<Pessoa> recuperartodos()
        {
            select_padrao = "select * from Pessoa as P inner join Endereco as E on E.Id=Endereco_Id inner join Telefone as T on T.Id=Telefone_Id @innerjoin";

            Select = select_padrao.Replace("@id", Id.ToString());
            Select = Select.Replace("@innerjoin", "");

            SqlCommand comando = new SqlCommand(Select, bd.obterconexao());

            SqlDataReader dr = comando.ExecuteReader();

            List<Pessoa> pessoa = new List<Pessoa>();

            if (dr.HasRows == false)
            {
                return null;
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        this.Id = int.Parse(Convert.ToString(dr["Pessoa_id"]));
                        this.Nome = Convert.ToString(dr["Nome"]);
                        this.Sexo_feminino = Convert.ToBoolean(Convert.ToString(dr["Sexo_feminino"]));
                        this.Sexo_masculino = Convert.ToBoolean(Convert.ToString(dr["Sexo_masculino"]));
                        this.Rg = Convert.ToString(dr["Rg"]);
                        this.Data_nascimento = Convert.ToDateTime(Convert.ToString(dr["Data_nascimento"]));
                        this.Endereco.Cep = long.Parse(Convert.ToString(dr["Cep"]));
                        this.Telefone.Fone = Convert.ToString(dr["Fone"]);
                        this.Telefone.Celular = Convert.ToString(dr["Celular"]);
                        this.Telefone.Whatsapp = Convert.ToString(dr["Whatsapp"]);
                        this.Cpf = Convert.ToString(dr["Cpf"]);
                        this.Status = Convert.ToString(dr["Status"]);
                        this.Endereco.Pais = Convert.ToString(dr["Pais"]);
                        this.Endereco.Estado = Convert.ToString(dr["Estado"]);
                        this.Endereco.Cidade = Convert.ToString(dr["Cidade"]);
                        this.Endereco.Bairro = Convert.ToString(dr["Bairro"]);
                        this.Endereco.Rua = Convert.ToString(dr["Rua"]);
                        this.Endereco.Complemento = Convert.ToString(dr["Complemento"]);
                        this.Endereco.Numero_casa = int.Parse(Convert.ToString(dr["Numero"]));
                        this.Email = Convert.ToString(dr["Email"]);
                        this.Estado_civil = Convert.ToString(dr["Estado_civil"]);
                        this.Falescimento = Convert.ToBoolean(Convert.ToString(dr["Falescimento"]));
                        this.Img = (byte[])(dr["Img"]);
                        pessoa.Add(this);
                    }

                    

                    dr.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    bd.obterconexao().Close();
                }

                return pessoa;
            }
        }

         
    }
}
