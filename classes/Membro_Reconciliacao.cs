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
    class Membro_Reconciliacao : Membro
    {
        private int data_reconciliação;

        public int Data_reconciliação
        {
            get
            {
                return data_reconciliação;
            }

            set
            {
                if(value != 0)
                data_reconciliação = value;
                else
                {
                    MessageBox.Show("O ano de reconciliação deve ser preenchido corretamente");
                    data_reconciliação = 0;
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
        /// <param name="ano_batismo"></param>
        /// <param name="imagem_location"></param>
        /// <param name="data_reconciliacao"></param>

        public Membro_Reconciliacao(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, int ano_batismo,
            string imagem_location, int data_reconciliacao)
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
            this.Data_reconciliação = data_reconciliacao;
            this.Data_batismo = ano_batismo;
            this.Img = imagem_location;
        }      


        /// <summary>
        /// Construtor sem paramentros
        /// </summary>

        public Membro_Reconciliacao()
        {

        }

        public override string alterar()
        {
             base.alterar();
            update_padrao = "update membro_reconciliacao set reco_data = '@data'" +
                " from membro_reconciliacao as MR inner join membro as M on M.id_membro=MR.reco_membro inner join pessoa as P on P.pes_id=M.memb_pessoa where pes_nome = '@nome'";
            Update = update_padrao.Replace("@nome", this.Nome);
            Update = Update.Replace("@data", data_reconciliação.ToString());

            return bd.montar_sql(Update, null, null);
        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            bd = new BDcomum();
            select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa inner join telefone on pes_id=tel_pessoa @innerjoin where pes_nome='@nome' or pes_cpf='@cpf'";

            Select = select_padrao.Replace("@nome", this.Nome);
            Select = Select.Replace("@cpf", this.Cpf);
            Select = Select.Replace("@innerjoin", " inner join membro on pes_id=memb_pessoa inner join membro_reconciliacao on id_membro=reco_membro ");

            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {
             base.salvar();            

            insert_padrao = "insert into membro_reconciliacao (reco_data, reco_membro) values ('@data', IDENT_CURRENT('membro'))";

            Insert = insert_padrao.Replace("@data", data_reconciliação.ToString());

            return bd.montar_sql(Insert, null, null);
        }
    }
}
