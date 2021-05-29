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
            

            if (id != null)
            {
                try
                {
                    bd.abrirconexao();
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao();
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
                    TratarExcessao(ex);
                }
                finally
                {
                    bd.fecharconexao();
                }
                return modelos;
            }
            else
            {
                try
                {
                    bd.abrirconexao();
                    SqlCommand comando = new SqlCommand(Select_padrao, bd.obterconexao());
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.HasRows == false)
                    {
                        dr.Close();
                        bd.fecharconexao();
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
                    bd.fecharconexao();
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
                    bd.fecharconexao();
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
            
            SqlCommand comando = new SqlCommand(select, bd.obterconexao());
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                dr.Close();
                return modelos;
            }

            while (dr.Read())
            {
                var p1 = new Visitante().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p2 = new VisitanteLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p3 = new Crianca().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p4 = new CriancaLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p5 = new Membro_Aclamacao().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p6 = new Membro_AclamacaoLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p7 = new Membro_Batismo().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p8 = new Membro_BatismoLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p9 = new Membro_Reconciliacao().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p10 = new Membro_ReconciliacaoLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p11 = new Membro_Transferencia().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                var p12 = new Membro_TransferenciaLgpd().recuperar(int.Parse(Convert.ToString(dr["IdPessoa"])));
                Pessoa p = null;
                if (p1.Count > 0) p = (Pessoa)p1[0];
                if (p2.Count > 0) p = (Pessoa)p2[0];
                if (p3.Count > 0) p = (Pessoa)p3[0];
                if (p4.Count > 0) p = (Pessoa)p4[0];
                if (p5.Count > 0) p = (Pessoa)p5[0];
                if (p6.Count > 0) p = (Pessoa)p6[0];
                if (p7.Count > 0) p = (Pessoa)p7[0];
                if (p8.Count > 0) p = (Pessoa)p8[0];
                if (p9.Count > 0) p = (Pessoa)p9[0];
                if (p10.Count > 0) p = (Pessoa)p10[0];
                if (p11.Count > 0) p = (Pessoa)p11[0];
                if (p12.Count > 0) p = (Pessoa)p12[0];
                if (p != null)
                modelos.Add(p);
            }
            dr.Close();            
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
