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
    class Membro_Aclamacao : Membro
    {
        private int id_aclamacao;
        private string denominacao;

        public string Denominacao
        {
            get
            {
                return denominacao;
            }

            set
            {
                if(value != "")
                denominacao = value;
                else
                {
                    MessageBox.Show("denominação precisa ser preenchido corretamente");
                    denominacao = null;
                }
            }
        }

        public int Id_aclamacao
        {
            get
            {
                return id_aclamacao;
            }

            set
            {
                id_aclamacao = value;
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
        /// <param name="denominacao"></param>

        public Membro_Aclamacao(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, int ano_batismo,
            string imagem_location, string denominacao)
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
            this.Denominacao = denominacao;
            this.Data_batismo = ano_batismo;
            this.Img = imagem_location;
        }

        /// <summary>
        /// Construtor sem paramentros
        /// </summary>

       public Membro_Aclamacao()
        {

        }

        public override string alterar()
        {
             base.alterar();

            update_padrao = "update membro_aclamacao set acla_denominacao = '@denominacao' " +
                " from membro_aclamacao as MA inner join membro as M on M.id_membro=MA.acla_membro inner join pessoa as P on P.pes_id=M.memb_pessoa where pes_nome = '@nome'";
            Update = update_padrao.Replace("@nome", this.Nome);
            Update = Update.Replace("@denominacao", denominacao);

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
            Select = Select.Replace("@innerjoin", " inner join membro on pes_id=memb_pessoa inner join membro_aclamacao on id_membro=acla_membro ");

            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {
             base.salvar();

            insert_padrao = "insert into membro_aclamacao (acla_denominacao, acla_membro) values ('@denominacao', IDENT_CURRENT('membro'))";
            Insert = insert_padrao.Replace("@denominacao", denominacao);

            return bd.montar_sql(Insert, null, null);
        }
    }
}
