﻿using business.classes.Abstrato;
using business.classes.Intermediario;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace business.classes
{
    public class Reuniao : modelocrud, IAddNalista
    {

        [Key]
        public int IdReuniao { get; set; }

        [Display(Name = "Data da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_reuniao { get; set; }

        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_inicio { get; set; }

        [Display(Name = "Horário de termino")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan? Horario_fim { get; set; }

        [Display(Name = "Local da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Local_reuniao { get; set; }

        [JsonIgnore]
        public virtual List<ReuniaoPessoa> Pessoas { get; set; }

        AddNalista AddNalista;

        public Reuniao() : base()
        {
            AddNalista = new AddNalista();
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Reuniao set Data_reuniao='{Data_reuniao.ToString("yyyy-MM-dd")}', " +
            $" Horario_inicio='{Horario_inicio}', Horario_fim='{Horario_fim}' where IdReuniao='{id}'"
            + BDcomum.addNaLista;

            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Reuniao where IdReuniao='{id}' ";
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Reuniao as M";
            if (id != null)
                Select_padrao +=  $" where M.IdReuniao='{id}'";

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
                try
                {
                    dr.Read();
                    this.Data_reuniao = Convert.ToDateTime(dr["Data_reuniao"].ToString());
                    this.Horario_inicio = TimeSpan.Parse(dr["Horario_inicio"].ToString());
                    this.Horario_fim = TimeSpan.Parse(dr["Horario_fim"].ToString());
                    this.IdReuniao = int.Parse(Convert.ToString(dr["IdReuniao"]));
                    this.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                    modelos.Add(this);
                    dr.Close();

                    this.Pessoas = new List<ReuniaoPessoa>();
                    var listaPessoas = recuperarPessoas(id);
                    if (listaPessoas != null)
                        foreach (var item in listaPessoas)
                        {
                            this.Pessoas.Add((ReuniaoPessoa)item);
                        }
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
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Reuniao r = new Reuniao();
                        r.Data_reuniao = Convert.ToDateTime(dr["Data_reuniao"].ToString());
                        r.Horario_inicio = TimeSpan.Parse(dr["Horario_inicio"].ToString());
                        r.Horario_fim = TimeSpan.Parse(dr["Horario_fim"].ToString());
                        r.IdReuniao = int.Parse(Convert.ToString(dr["IdReuniao"]));
                        r.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                        modelos.Add(r);
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

                return modelos;

            }

        }

        public override string salvar()
        {
            Insert_padrao = $"insert into Reuniao (Data_reuniao," +
        " Horario_inicio, Horario_fim, Local_reuniao) values " +
        $" ('{Data_reuniao.ToString("yyyy-MM-dd")}', '{Horario_inicio.ToString()}', " +
        $" '{Horario_fim.ToString()}', '{Local_reuniao}')" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            
            return Insert_padrao;
        }

        public List<modelocrud> recuperarPessoas(int? id)
        {
            var select = "select * from Pessoa as P inner join " +
                " ReuniaoPessoa as PERE on P.IdPessoa=PERE.PessoaId  inner join Reuniao as R" +
                $" on PERE.ReuniaoId=R.IdReuniao where PERE.ReuniaoId='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return modelos;
            }

            var lista = Pessoa.recuperarTodos().OfType<Pessoa>().ToList();

            while (dr.Read())
            {
                var m = lista.First(i => i.IdPessoa == int.Parse(Convert.ToString(dr["PessoaId"])));
                modelos.Add(m);
            }
            dr.Close();

            bd.obterconexao().Close();
            return modelos;
        }

        public void AdicionarNaLista(string NomeTabela, modelocrud modeloQRecebe,
            modelocrud modeloQPreenche, string numeros)
        {
            AddNalista.AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }

        public void RemoverDaLista(string NomeTabela, modelocrud modeloQRecebe,
            modelocrud modeloQPreenche, string numeros)
        {
            AddNalista.RemoverDaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }

        public override string ToString()
        {
            return this.IdReuniao.ToString() + " - Data da reunião: " + this.Data_reuniao.ToString();
        }
    }
}
