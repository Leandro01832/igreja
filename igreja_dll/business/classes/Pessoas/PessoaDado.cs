﻿using business.classes.Abstrato;
using database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;


namespace business.classes.Pessoas
{
    [Table("PessoaDado")]
    public abstract class PessoaDado : Pessoa
    {
        public PessoaDado() : base()
        {
            MudancaEstado = new MudancaEstado();
            AddNalista = new AddNalista();
        }

        protected PessoaDado(int m) : base(m)
        {
        }

        //propriedades
        #region

        AddNalista AddNalista;


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

        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        [JsonIgnore]
        public virtual Telefone Telefone { get; set; }

        private MudancaEstado MudancaEstado;

        #endregion

        public override string salvar()
        {
            Telefone t = new Telefone(); t = this.Telefone;
            Endereco e = new Endereco(); e = this.Endereco;

            Insert_padrao = base.salvar();
            Insert_padrao +=
            "insert into PessoaDado ( Data_nascimento, Estado_civil, Sexo_masculino, " +
            "Rg, Cpf, Sexo_feminino, Falescimento, " +
            "Status, Id)" +
            $" values ('{this.Data_nascimento.ToString("yyyy-MM-dd")}', '{this.Estado_civil}', " +
            $" '{this.Sexo_masculino.ToString()}', '{this.Rg}', '{this.Cpf}', " +
            $" '{this.Sexo_feminino.ToString()}', '{this.Falescimento.ToString()}',  " +
            $" '{this.Status}', IDENT_CURRENT('Pessoa')) " +
            e.salvar() + " " +
            t.salvar() + " ";

            return Insert_padrao;
        }

        public override string alterar(int id)
        {
            Update_padrao = base.alterar(id);
            Update_padrao += $"update PessoaDado set Estado_civil='{Estado_civil}', " +
            $"Rg='{Rg}', Cpf='{Cpf}', Falescimento='{Falescimento.ToString()}', Status='{Status}', " +
            $" Data_nascimento='{this.Data_nascimento.ToString("yyyy-MM-dd")}', " +
            $" Sexo_masculino='{Sexo_masculino.ToString()}', Sexo_feminino='{Sexo_feminino.ToString()}', " +
            $"  where Id='{id}' " + this.Telefone.alterar(id) + this.Endereco.alterar(id);

            return Update_padrao;
        }

        public override string excluir(int id)
        {
            
            Delete_padrao =
            " delete Telefone from Telefone as T inner " +
            " join PessoaDado as PD on T.Id=PD.Id" +
            $" where PD.Id='{id}' " +
            "delete Endereco from Endereco as E inner " +
            "join PessoaDado as PD on E.Id=PD.Id" +
            $" where PD.Id='{id}' " +
            $" delete PessoaDado from PessoaDado as PD where PD.Id='{id}' ";
            Delete_padrao += base.excluir(id);

            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            Select_padrao = "select * from PessoaDado as PD "
        + " inner join Endereco as EN on EN.Id=PD.Id "
        + $" inner join Telefone as TE on TE.Id=PD.Id where PD.Id='{id}'";
            var conexao = bd.obterconexao();

            SqlCommand comando = new SqlCommand(Select_padrao, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return false;
            }
            base.recuperar(id);
            dr.Read();
            this.Data_nascimento = Convert.ToDateTime(dr["Data_nascimento"]);
            this.Estado_civil = Convert.ToString(dr["Estado_civil"]);
            this.Sexo_masculino = Convert.ToBoolean(dr["Sexo_masculino"]);
            this.Sexo_feminino = Convert.ToBoolean(dr["Sexo_feminino"]);
            this.Falescimento = Convert.ToBoolean(dr["Falescimento"]);
            this.Rg = Convert.ToString(dr["Rg"]);
            this.Cpf = Convert.ToString(dr["Cpf"]);
            this.Status = Convert.ToString(dr["Status"]);
            this.Endereco = new Endereco();
            this.Endereco.Bairro = Convert.ToString(dr["Bairro"]);
            this.Endereco.Cidade = Convert.ToString(dr["Cidade"]);
            this.Endereco.Numero_casa = int.Parse(Convert.ToString(dr["Numero_casa"]));
            this.Endereco.Estado = Convert.ToString(dr["Estado"]);
            this.Endereco.Rua = Convert.ToString(dr["Rua"]);
            this.Endereco.Cep = long.Parse(Convert.ToString(dr["Cep"]));
            this.Endereco.Id = int.Parse(Convert.ToString(dr["Id"]));
            this.Telefone = new Telefone();
            this.Telefone.Fone = Convert.ToString(dr["Fone"]);
            this.Telefone.Celular = Convert.ToString(dr["Celular"]);
            this.Telefone.Whatsapp = Convert.ToString(dr["Whatsapp"]);
            this.Telefone.Id = int.Parse(Convert.ToString(dr["Id"]));

            dr.Close();
            bd.fecharconexao(conexao);
            return true;
        }


    }
}
