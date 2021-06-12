using business.classes.Abstrato;
using business.classes.Intermediario;
using business.classes.Pessoas;
using business.classes.PessoasLgpd;
using database;
using database.banco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;


namespace business.classes
{
    public class Reuniao : modelocrud, IAddNalista
    {

        #region Properties
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

        [NotMapped]
        public static int UltimoRegistro { get; set; } 
        #endregion

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
                Select_padrao += $" where M.IdReuniao='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conexao = bd.obterconexao();

            if (conexao != null)
            {
                if (id != null)
                {
                    try
                    {

                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return modelos;
                        }

                        dr.Read();
                        this.Data_reuniao = Convert.ToDateTime(dr["Data_reuniao"].ToString());
                        this.Horario_inicio = TimeSpan.Parse(dr["Horario_inicio"].ToString());
                        this.Horario_fim = TimeSpan.Parse(dr["Horario_fim"].ToString());
                        this.IdReuniao = int.Parse(Convert.ToString(dr["IdReuniao"]));
                        this.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                        modelos.Add(this);
                        dr.Close();

                        bd.fecharconexao(conexao);
                        Dados_Relacionados = true;
                        this.Pessoas = new List<ReuniaoPessoa>();
                        var listaPessoas = recuperarPessoas(id);
                        if (listaPessoas != null)
                            foreach (var item in listaPessoas)
                            {
                                this.Pessoas.Add((ReuniaoPessoa)item);
                            }
                        Dados_Relacionados = false;

                    }

                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }
                    return modelos;
                }
                else
                {
                    try
                    {

                        SqlCommand comando = new SqlCommand(Select_padrao, conexao);
                        SqlDataReader dr = comando.ExecuteReader();
                        if (dr.HasRows == false)
                        {
                            dr.Close();
                            bd.fecharconexao(conexao);
                            return modelos;
                        }

                        while (dr.Read())
                        {
                            Reuniao r = new Reuniao();
                            r.IdReuniao = int.Parse(Convert.ToString(dr["IdReuniao"]));
                            modelos.Add(r);
                        }

                        dr.Close();

                        //Recursividade
                        bd.fecharconexao(conexao);
                        List<modelocrud> lista = new List<modelocrud>();
                        foreach (var m in modelos)
                        {
                            var cel = (Reuniao)m;
                            var c = new Reuniao();
                            c = (Reuniao)m.recuperar(cel.IdReuniao)[0];
                            lista.Add(c);
                        }
                        modelos.Clear();
                        modelos.AddRange(lista);
                    }

                    catch (Exception ex)
                    {
                        TratarExcessao(ex);
                    }
                    finally
                    {
                        bd.fecharconexao(conexao);
                    }

                    return modelos;

                } 
            }

            return modelos;
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

        private List<modelocrud> recuperarPessoas(int? id)
        {
            var select = "select * from Pessoa as P inner join " +
                " ReuniaoPessoa as PERE on P.IdPessoa=PERE.PessoaId  inner join Reuniao as R" +
                $" on PERE.ReuniaoId=R.IdReuniao where PERE.ReuniaoId='{id}' ";

            List<modelocrud> modelos = new List<modelocrud>();
            List<ReuniaoPessoa> lista = new List<ReuniaoPessoa>();
            var conexao = bd.obterconexao();

            
            SqlCommand comando = new SqlCommand(select, conexao);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                bd.fecharconexao(conexao);
                return modelos;
            }
            
            while (dr.Read())
            {
                lista.Add(new ReuniaoPessoa { IdReuniaoPessoa = int.Parse(Convert.ToString(dr["IdReuniaoPessoa"])) });                
            }
            dr.Close();
            bd.fecharconexao(conexao);

            foreach(var item in lista)
            {
                    modelos.Add(new ReuniaoPessoa().recuperar(item.IdReuniaoPessoa)[0]);
            }

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
