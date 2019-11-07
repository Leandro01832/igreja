﻿using business.classes;
using database.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace business.classes
{
        
    public class Ministerio : modelocrud<Ministerio>
    {
        
        

        [Display(Name = "Codigo")]
        [Key]
        public int Ministerioid { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public string Proposito { get; set; }

        public virtual List<Pessoa> Pessoas { get; set;}

        [Display(Name = "Maximo de pessoas")]
        [Required(ErrorMessage = "Este campo precisa ser preenchido")]
        public int Maximo_pessoa { get; set; }

        public virtual Cargo_Lider_Ministerio Cargo_Lider_Ministerio { get; set; }

        public Ministerio()
        {
            bd = new BDcomum();
        }

        public override string alterar(int id)
        {
            update_padrao = "update Ministerio set Nome='@nome',"
              + " lider_ministerio='@lider', Proposito='@proposito'"
              + " where ministerioid='@id'";

            Update = update_padrao.Replace("@nome", Nome);
            Update = Update.Replace("@proposito", Proposito);
            Update = Update.Replace("@id", id.ToString());

            return bd.montar_sql(Update, null, null);
        }

        public override string excluir(int id)
        {
            delete_padrao = "delete from Ministerio where ministerioid='@id'";
            Delete = delete_padrao.Replace("@id", id.ToString());

            return bd.montar_sql(Delete, null, null);
        }

        public override Ministerio recuperar(int id)
        {
            select_padrao = "select * from Ministerio where ministerioid='@id'";
            Select = select_padrao.Replace("@id", id.ToString());
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
                    this.Nome = dr["Nome"].ToString();
                    this.Proposito = dr["Proposito"].ToString();
                    this.Ministerioid = int.Parse(dr["ministerioid"].ToString());
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

        public override string salvar()
        {          
                insert_padrao = "insert into Ministerio (Nome,  Proposito, Maximo_pessoa, lider_ministerio) values " +
                " ('@nome', '@proposito', '@maximo', '@lider')";

                Insert = insert_padrao.Replace("@nome", Nome);
                Insert = Insert.Replace("@proposito", Proposito);
                Insert = Insert.Replace("@maximo", Maximo_pessoa.ToString());
                return bd.montar_sql(Insert, null, null);                      
        }

        public List<Pessoa> preencherministerio(int ID)
        {
            select_padrao = "select * from Pessoa as P inner join MinisterioPessoa as MP" +
                " on P.Id=MP.Pessoa_Id " +
                "  where Ministerio_ministerioid='@id'";
            Select = select_padrao.Replace("@id", Ministerioid.ToString());

            DataTable datatable = bd.lista(Select);

            List<Pessoa> lista = new List<Pessoa>();
            foreach (DataRow dtrow in datatable.Rows)
            {
                var pessoa = new Pessoa();
                pessoa.Id = int.Parse(Convert.ToString(dtrow["Pessoa_id"]));
                pessoa.Nome = Convert.ToString(dtrow["Nome"]);
                pessoa.Email = Convert.ToString(dtrow["Email"]);
                pessoa.Falta = int.Parse(dtrow["Falta"].ToString());
                pessoa.Estado_civil = Convert.ToString(dtrow["Estado_civil"]);
                pessoa.Falescimento = Convert.ToBoolean(Convert.ToString(dtrow["Falescimento"]));
                pessoa.Sexo_feminino = Convert.ToBoolean(Convert.ToString(dtrow["Sexo_feminino"]));
                pessoa.Sexo_masculino = Convert.ToBoolean(Convert.ToString(dtrow["Sexo_masculino"]));
                pessoa.Rg = Convert.ToString(dtrow["Rg"]);
                pessoa.Data_nascimento = Convert.ToDateTime(Convert.ToString(dtrow["Data_nascimento"]));
                pessoa.Cpf = Convert.ToString(dtrow["Cpf"]);
                pessoa.Status = Convert.ToString(dtrow["Status"]);
                pessoa.Telefone.Fone = Convert.ToString(dtrow["Fone"]);
                pessoa.Telefone.Celular = Convert.ToString(dtrow["Celular"]);
                pessoa.Telefone.Whatsapp = Convert.ToString(dtrow["Whatsapp"]);
                pessoa.Endereco.Cep = long.Parse(Convert.ToString(dtrow["Cep"]));
                pessoa.Endereco.Pais = Convert.ToString(dtrow["Pais"]);
                pessoa.Endereco.Estado = Convert.ToString(dtrow["Estado"]);
                pessoa.Endereco.Cidade = Convert.ToString(dtrow["Cidade"]);
                pessoa.Endereco.Bairro = Convert.ToString(dtrow["Bairro"]);
                pessoa.Endereco.Rua = Convert.ToString(dtrow["Rua"]);
                pessoa.Endereco.Complemento = Convert.ToString(dtrow["Complemento"]);
                pessoa.Endereco.Numero_casa = int.Parse(Convert.ToString(dtrow["Numero"]));
                pessoa.Chamada.Data_inicio = Convert.ToDateTime(dtrow["Data_inicio"]);
                pessoa.Chamada.Numero_chamada = int.Parse(dtrow["Numero_chamada"].ToString());
                pessoa.Celula.Celulaid = int.Parse(dtrow["celulaid"].ToString());
                pessoa.Celula.Supervisor_ = int.Parse(dtrow["Supervisor"].ToString());
                pessoa.Celula.Supervisortreinamento_ = int.Parse(dtrow["Supervisortreinamento_"].ToString());
                pessoa.Celula.Pessoas = pessoa.Celula.preenchercelula(pessoa.Celula.Celulaid);
                pessoa.Celula.Maximo_pessoa = int.Parse(dtrow["Maximo_pessoa"].ToString());
                pessoa.Celula.Horario = TimeSpan.Parse(dtrow["Horario"].ToString());
                pessoa.Celula.Nome = dtrow["Nome"].ToString();

                    Historico h = new Historico();
                    h.Data_inicio = Convert.ToDateTime(dtrow["Data_inicio"]);
                    h.Falta = int.Parse(dtrow["Falta"].ToString());
                    pessoa.Historico.Add(h);

                    Ministerio m = new Ministerio();
                    m.Ministerioid = int.Parse(dtrow["ministerioid"].ToString());
                    m.Nome = dtrow["Nome"].ToString();
                    m.Proposito = dtrow["proposito"].ToString();
                    m.Pessoas = m.preencherministerio(m.Ministerioid);
                    pessoa.Ministerios.Add(m);

                    Reuniao r = new Reuniao();
                    r.Data_reuniao = Convert.ToDateTime(dtrow["Data_reuniao"]);
                    r.Horario_inicio = Convert.ToDateTime(dtrow["Horario_inicio"]);
                    r.Horario_fim = Convert.ToDateTime(dtrow["Horario_fim"]);
                    r.Local_reuniao = dtrow["Local_reuniao"].ToString();
                    pessoa.Reuniao.Add(r);
                
                lista.Add(pessoa);
            }

            return lista;
        }

        public override IEnumerable<Ministerio> recuperartodos()
        {
            select_padrao = "select * from Celula";

            SqlCommand comando = new SqlCommand(select_padrao, bd.obterconexao());

            SqlDataReader dr = comando.ExecuteReader();

            List<Ministerio> lista = new List<Ministerio>();

            while (dr.Read())
            {
                Ministerio cl = new Ministerio();

                cl.Nome = dr["Nome"].ToString();
                cl.Proposito = dr["Proposito"].ToString();
                cl.Ministerioid = int.Parse(dr["ministerioid"].ToString());             
                cl.Pessoas = cl.preencherministerio(cl.Ministerioid);
                lista.Add(cl);
            }

            return lista;
        }
    }
}
