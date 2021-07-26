﻿using business.classes.Abstrato;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace business.classes
{
    [Table("Historico")]
    public class Historico : modelocrud
    {

        public DateTime Data_inicio { get; set; }

        public int pessoaid { get; set; }

        [ForeignKey("pessoaid")]
        [JsonIgnore]
        public virtual Pessoa Pessoa { get; set; }

        public int Falta { get; set; }

        [NotMapped]
        public static List<Historico> Historicos { get; set; }

        public Historico() : base()
        {
        }

        public Historico(int id) : base(id)
        {
        }

        public override string alterar(int id)
        {
            UpdateProperties(GetType(), id);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override bool recuperar(int id)
        {
            if (SetProperties(GetType()))
            { T = GetType(); return true; }
            return false;
        }
        
        public override string salvar()
        {
            GetProperties(GetType());
            bd.SalvarModelo(this);
            return Insert_padrao;
        }

        public static int GeTotalRegistrosHistoricos()
        {
            var _TotalRegistros = 0;
            SqlConnection con;
            SqlCommand cmd;
            if (BDcomum.podeAbrir)
            {
                try
                {
                    var stringConexao = "";
                    if (BDcomum.BancoEnbarcado) stringConexao = BDcomum.conecta1;
                    else stringConexao = BDcomum.conecta2;
                    using (con = new SqlConnection(stringConexao))
                    {
                        cmd = new SqlCommand("SELECT COUNT(*) FROM Historico", con);
                        con.Open();
                        _TotalRegistros = int.Parse(cmd.ExecuteScalar().ToString());
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    BDcomum.podeAbrir = false;
                }
            }
            return _TotalRegistros;
        }

    }
}
