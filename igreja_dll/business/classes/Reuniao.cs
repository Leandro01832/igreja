using database.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using database;
using business.classes.Abstrato;
using business.classes.Pessoas;

namespace business.classes
{
    
    public class Reuniao : modelocrud, IAddNalista
    {

        private DateTime data_reuniao;
        private DateTime horario_inicio;
        private DateTime horario_fim;
        private string local_reuniao;
        
        [Display(Name = "Data da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data_reuniao
        {
            get
            {
                return data_reuniao;
            }

            set
            {
                if(value >= DateTime.Now)
                data_reuniao = value;
                else
                {
                    MessageBox.Show("A data precisa ser maior ou igual ao dia atual");
                    data_reuniao = DateTime.Now;
                }
            }
        }

        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Horario_inicio
        {
            get
            {
                return horario_inicio;
            }

            set
            {
                horario_inicio = value;
            }
        }

        [Display(Name = "Horário de termino")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public DateTime Horario_fim
        {
            get
            {
                return horario_fim;
            }

            set
            {
                if (value > horario_inicio)
                horario_fim = value;
                else
                {
                    MessageBox.Show("O horario que termina a reunião deve ser maior que o horario de inicio");
                    horario_fim = horario_inicio.AddHours(1);
                }
            }
        }

        [Display(Name = "Local da reunião")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Local_reuniao
        {
            get
            {
                return local_reuniao;
            }

            set
            {
                if(value != "")
                local_reuniao = value;
                else
                {
                    MessageBox.Show("Informe o local da reunião");
                    local_reuniao = null;
                }
            }
        }

        public List<Pessoa> Pessoas { get; set; }

        AddNalista AddNalista;

        public Reuniao() : base()
        {
            AddNalista = new AddNalista();
        }

        public override string alterar(int id)
        {
            Update_padrao = $"update Reuniao set Data_reuniao='{Data_reuniao}', " +
                $"  Horario_inicio='{Horario_inicio}', Horario_fim='{Horario_fim}' where Id='{id}'";
            bd.Editar(this);
            return Update_padrao;
        }

        public override string excluir(int id)
        {
            Delete_padrao = $"delete from Reuniao where Id='{id}' ";
            bd.Excluir(this);
            return Delete_padrao;
        }

        public override List<modelocrud> recuperar(int? id)
        {
            Select_padrao = "select * from Reuniao as M";
            if (id != null)
                Select_padrao += Select_padrao + $" where M.Id='{id}'";

            List<modelocrud> modelos = new List<modelocrud>();
            var conecta = bd.obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(Select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                bd.obterconexao().Close();
                return null;
            }

            if (id != null)
            {
                if (dr.HasRows == false)
                {
                    return null;
                }
                else
                {
                    try
                    {
                        dr.Read();
                        this.Data_reuniao = Convert.ToDateTime(dr["Data_inicio"].ToString());
                        this.Horario_inicio = Convert.ToDateTime(dr["Horario_inicio"].ToString());
                        this.Horario_fim = Convert.ToDateTime(dr["Horario_fim"].ToString());
                        this.Id = int.Parse(Convert.ToString(dr["Id"]));
                        this.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                        modelos.Add(this);
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
            else
            {


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
                            Reuniao r = new Reuniao();
                            r.Data_reuniao = Convert.ToDateTime(dr["Data_inicio"].ToString());
                            r.Horario_inicio = Convert.ToDateTime(dr["Horario_inicio"].ToString());
                            r.Horario_fim = Convert.ToDateTime(dr["Horario_fim"].ToString());
                            r.Id = int.Parse(Convert.ToString(dr["Id"]));
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

        }

        public override string salvar()
        {
            Insert_padrao = $"insert into Reuniao (Data_reuniao," +
        " Horario_inicio, Horario_fim, Local_reuniao) values " +
        $" ('{Data_reuniao.ToString("yyyy-MM-dd")}', '{Horario_inicio.ToString("HH:mm:ss")}', " +
        $" '{Horario_fim.ToString("HH:mm:ss")}', '{Local_reuniao}')" + BDcomum.addNaLista;
            
            bd.SalvarModelo(this);
            BDcomum.addNaLista = "";
            return Insert_padrao;
        }

        public void AdicionarNaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros)
        {
            AddNalista.AdicionarNaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros);
        }

        public void RemoverDaLista(string NomeTabela, string modeloQRecebe, string modeloQPreenche, string numeros, int id)
        {
            AddNalista.RemoverDaLista(NomeTabela, modeloQRecebe, modeloQPreenche, numeros, id);
        }

        public static modelocrud recuperarReuniao(int v)
        {
           var select_padrao = "select * from Reuniao as M";
                select_padrao += select_padrao + $" where M.Id='{v}'";

            var conecta = new BDcomum().obterconexao();
            conecta.Open();
            SqlCommand comando = new SqlCommand(select_padrao, conecta);
            SqlDataReader dr = comando.ExecuteReader();
            if (dr.HasRows == false)
            {
                new BDcomum().obterconexao().Close();
                return null;
            }

            if (dr.HasRows == false)
            {
                return null;
            }
            else
            {
                Reuniao r = new Reuniao();
                try
                {
                    dr.Read();
                    
                    r.Data_reuniao = Convert.ToDateTime(dr["Data_inicio"].ToString());
                    r.Horario_inicio = Convert.ToDateTime(dr["Horario_inicio"].ToString());
                    r.Horario_fim = Convert.ToDateTime(dr["Horario_fim"].ToString());
                    r.Id = int.Parse(Convert.ToString(dr["Id"]));
                    r.Local_reuniao = Convert.ToString(dr["Local_reuniao"]);
                    dr.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                   new BDcomum().obterconexao().Close();
                }
                return r;
            }

        }
    }
}
