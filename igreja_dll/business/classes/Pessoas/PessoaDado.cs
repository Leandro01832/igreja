using business.classes.Abstrato;
using database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace business.classes.Pessoas
{
    [Table("PessoaDado")]
    public abstract class PessoaDado : Pessoa, IAddNalista, IMudancaEstado  
    {
        public PessoaDado() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
            this.Endereco = new Endereco();
            this.Telefone = new Telefone();
           
        }

        //propriedades
        #region

        AddNalista AddNalista;

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
        
        public virtual Endereco Endereco { get; set; }
        
        public virtual Telefone Telefone { get; set; }

        private MudancaEstado MudancaEstado;

        #endregion

        public override string salvar()
        {
            Codigo = recuperarTodos().Count + 1;
            Telefone t = new Telefone(); t = this.Telefone;
            Endereco e = new Endereco(); e = this.Endereco;

                      Insert_padrao =
              "insert into Pessoa (Nome, Data_nascimento, Estado_civil, Sexo_masculino, " +
              "Rg, Cpf, Sexo_feminino, Falescimento, " +
              "Email, Status)" +
              $" values ('{this.Nome}', '{this.Data_nascimento.ToString("yyyy-MM-dd")}', '{this.Estado_civil}', " +
              $" '{this.Sexo_masculino.ToString()}', '{this.Rg}', '{this.Cpf}', " +
              $" '{this.Sexo_feminino.ToString()}', '{this.Falescimento.ToString()}',  " +
              $" '{this.Status}') " +
              e.salvar() + " " +
              t.salvar() + " ";
            
            bd.SalvarModelo(null);
            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            string celula = "";
            if (this.celula_ == null) celula = "null";
            else celula = this.celula_.ToString();

            Update_padrao = $"update Pessoa set Nome='{Nome}', Estado_civil='{Estado_civil}', " +
            $"Rg='{Rg}', Cpf='{Cpf}', Falescimento='{Falescimento.ToString()}', Email='{Email}', Status='{Status}', " +
            $"celula_={celula}, Data_nascimento='{this.Data_nascimento.ToString("yyyy-MM-dd")}', " +
            $" Sexo_masculino='{Sexo_masculino.ToString()}', Sexo_feminino='{Sexo_feminino.ToString()}', " +
            $" Falta='{Falta}', Img='{this.Img}' Codigo='{Codigo}' " +
            $"  where Id='{id}' " + this.Telefone.alterar(id) + this.Endereco.alterar(id);
            
            bd.Editar(null);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = 
                " delete Telefone from Telefone as T inner " +
                " join Pessoa as P on T.Id=P.Id" +
                $" where P.Id='{id}' " +
                "delete Endereco from Endereco as E inner " +
                "join Pessoa as P on E.Id=P.Id" +
                $" where P.Id='{id}' " +
                " delete Chamada from Chamada as CH inner " +
                "join Pessoa as P on CH.Id=P.Id" +
                $" where P.Id='{id}' " +
                $" delete Pessoa from Pessoa as P where P.Id='{id}' " ;
            
            bd.Excluir(null);
            return Delete_padrao;
        }        

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from PessoaDado as P "
        + " inner join ChamadaLgpd as CH on CH.Id=P.Id ";
            if (id != null) Select_padrao += $" where P.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            if (id != null)
            {
                base.recuperar(id);
                try
                {
                    dr.Read();
                    this.Data_nascimento = Convert.ToDateTime(dr["Data_nascimento"]);
                    this.Nome = Convert.ToString(dr["Nome"]);
                    this.Estado_civil = Convert.ToString(dr["Estado_civil"]);
                    this.Sexo_masculino = Convert.ToBoolean(dr["Sexo_masculino"]);
                    this.Sexo_feminino = Convert.ToBoolean(dr["Sexo_feminino"]);
                    this.Falescimento = Convert.ToBoolean(dr["Falescimento"]);
                    this.Rg = Convert.ToString(dr["Rg"]);
                    this.Cpf = Convert.ToString(dr["Cpf"]);
                    this.Status = Convert.ToString(dr["Status"]);

                    dr.Close();
                    modelos.Add(this);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    bd.obterconexao().Close();
                }
                return modelos;
            }
            return modelos;
        }
    }
}
