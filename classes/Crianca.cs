using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Crianca : Pessoa
    {
        private int id;
        private string nome_pai;
        private string nome_mae;

        public int Id_
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nome_pai
        {
            get
            {
                return nome_pai;
            }

            set
            {
                if(value != "")
                nome_pai = value;
                else
                {
                    MessageBox.Show("informe o nome do pai");
                }
            }
        }

        public string Nome_mae
        {
            get
            {
                return nome_mae;
            }

            set
            {
                if(value != "")
                nome_mae = value;
                else
                {
                    MessageBox.Show("informe o nome da mãe");
                    nome_mae = null;
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
        /// <param name="nome_pai"></param>
        /// <param name="nome_mae"></param>

        public Crianca(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, string imagem_location,
            string nome_pai, string nome_mae)
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
            this.Nome_mae = nome_mae;
            this.Nome_pai = nome_pai;
            this.Img = imagem_location;
        }

        /// <summary>
        /// Construtor sem parametros
        /// </summary>

        public Crianca()
        {

        }

        public override string alterar()
        {
             base.alterar();
            update_padrao = "update crianca set nome_pai='@pai', nome_mae='@mae' " +
                " from crianca inner join pessoa on pes_id=cri_pessoa " +
                "where pes_nome='@nome'";
            Update = update_padrao.Replace("@nome", Nome);
            Update = Update.Replace("@pai", nome_pai);
            Update = Update.Replace("@mae", nome_mae);

           return bd.montar_sql(Update, null, null);
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
            Select = Select.Replace("@innerjoin", "inner join crianca on pes_id=cri_pessoa");

            return Select;
        }

        public override string salvar()
        {
             base.salvar();

            insert_padrao = "insert into crianca (pai, mae, cri_pessoa) values" +
                " ('@pai', '@mae', IDENT_CURRENT('pessoa'))";

            Insert = insert_padrao.Replace("@mae", Nome_mae);
            Insert = Insert.Replace("@pai", Nome_pai);

            return bd.montar_sql(Insert, null, null);
        }

        public override void foto(PictureBox foto)
        {
            base.foto(foto);
        }
    }
}
