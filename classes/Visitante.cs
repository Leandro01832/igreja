using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Visitante : Pessoa
    {
        private DateTime data_visita;
        private string condicao_religiosa;

        public DateTime Data_visita
        {
            get
            {
                string sqlTimeAsString = data_visita.ToString("yyyy-MM-dd HH:mm:ss.fff");
                return Convert.ToDateTime(sqlTimeAsString);
            }

            set
            {
                string sqlTimeAsString = value.ToString("yyyy-MM-dd HH:mm:ss.fff");
                data_visita = Convert.ToDateTime(sqlTimeAsString);
            }
        }

        public string Condicao_religiosa
        {
            get
            {
                return condicao_religiosa;
            }

            set
            {
                if(value != "")
                condicao_religiosa = value;
                else
                {
                    MessageBox.Show("indique a condição religiiosa");
                    condicao_religiosa = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="sexo_masculino"></param>
        /// <param name="sexo_feminino"></param>
        /// <param name="data_nascimento"></param>
        /// <param name="rg"></param>
        /// <param name="falescimento"></param>
        /// <param name="email"></param>
        /// <param name="cpf"></param>
        /// <param name="falta"></param>
        /// <param name="pais"></param>
        /// <param name="cidade"></param>
        /// <param name="bairro"></param>
        /// <param name="rua"></param>
        /// <param name="estado"></param>
        /// <param name="numero_casa"></param>
        /// <param name="cep"></param>
        /// <param name="complemento"></param>
        /// <param name="estado_civil"></param>
        /// <param name="status"></param>
        /// <param name="telefone"></param>
        /// <param name="celular"></param>
        /// <param name="whatsapp"></param>
        /// <param name="imagem_location"></param>
        /// <param name="data_visita"></param>
        /// <param name="condicao_religiosa"></param>

        public Visitante(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, string imagem_location,
            string data_visita, string condicao_religiosa)
        {
            bd = new BDcomum();

            this.Nome = nome;
            this.Sexo_masculino = sexo_masculino;
            this.Sexo_feminino = sexo_feminino;
            this.Data_nascimento = Convert.ToDateTime(data_nascimento);
            this.Rg = rg;
            this.Falescimento = false;
            this.Email = email;
            this.Cpf = cpf;
            this.Falta = falta;
            this.Pais = pais;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Rua = rua;
            this.Estado = estado;
            this.Numero_casa = numero_casa;
            this.Cep = cep;
            this.Complemento = complemento;
            this.Estado_civil = estado_civil;
            this.Status = status;
            this.Fone = telefone;
            this.Celular = celular;
            this.Whatsapp = whatsapp;
            this.Data_visita = Convert.ToDateTime(data_visita);
            this.Condicao_religiosa = condicao_religiosa;
            this.Img = imagem_location;
        }

        /// <summary>
        /// Construtor sem paramentros
        /// </summary>

        public Visitante()
        {

        }

        public DateTime freguentar()
        {


            DateTime frequencia = DateTime.Today.AddDays(30);

            return data_visita;
        }

      

        public override string alterar()
        {
             base.alterar();
            update_padrao = "update visitante set visita = @data, condicao_religiosa = @condicao_religiosa inner join pessoa on pes_id=visi_pessoa " +
                "where pes_nome = @nome";
            Update = update_padrao.Replace("@nome", Nome);
            Update = Update.Replace("@data", data_visita.ToString());
            Update = Update.Replace("@condicao_religiosa",  condicao_religiosa);

         return   bd.montar_sql(Update, null, null);
        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa inner join telefone on pes_id=tel_pessoa @innerjoin where pes_nome='@nome' or pes_cpf='@cpf'";

            Select = select_padrao.Replace("@nome", this.Nome);
            Select = Select.Replace("@cpf", this.Cpf);
            Select = Select.Replace("@innerjoin", "inner join visitante on pes_id=visi_pessoa");

            return Select;
        }

        public override string salvar()
        {
             base.salvar();

            insert_padrao = "insert into visitante (visita, condicao_religiosa, visi_pessoa) values" +
                " ('@data', '@condicao_religiosa', IDENT_CURRENT('pessoa'))";

            Insert = insert_padrao.Replace("@data", data_visita.ToString());
            Insert = Insert.Replace("@condicao_religiosa", condicao_religiosa);

           return bd.montar_sql(Insert, null, null);
        }

        public override void foto(PictureBox foto)
        {
            base.foto(foto);
        }
    }
}
