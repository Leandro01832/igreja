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
    class Membro_Transferencia : Membro
    {
        private int id_memb_transferencia;
        private string nome_cidade_transferencia;
        private string estado_transferencia;
        private string nome_igreja_transferencia;

        public int Id_memb_transferencia
        {
            get
            {
                return id_memb_transferencia;
            }

            set
            {
                id_memb_transferencia = value;
            }
        }

        public string Nome_cidade_transferencia
        {
            get
            {
                return nome_cidade_transferencia;
            }

            set
            {
                if (value != "")
                nome_cidade_transferencia = value;
                else
                {
                    MessageBox.Show("O nome de cidade de transerencia pecisa ser preechido corretamente");
                    nome_cidade_transferencia = null;
                }
            }
        }

        public string Estado_transferencia
        {
            get
            {
                return estado_transferencia;
            }

            set
            {
                if(value != "")
                estado_transferencia = value;
                else
                {
                    MessageBox.Show("O estado de transferencia deve ser preechido corretamente");
                    estado_transferencia = null;
                }
            }
        }

        public string Nome_igreja_transferencia
        {
            get
            {
                return nome_igreja_transferencia;
            }

            set
            {
                if(value != "")
                nome_igreja_transferencia = value;
                else
                {
                    MessageBox.Show("O nome da igreja deve ser preenchido corretamente");
                    nome_igreja_transferencia = null;
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
        /// <param name="nome_cidade_transferencia"></param>
        /// <param name="estado_transferencia"></param>
        /// <param name="nome_igreja_transferencia"></param>
        /// <param name="ano_batismo"></param>
        /// <param name="imagem_location"></param>

        public Membro_Transferencia(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, string nome_cidade_transferencia,
            string estado_transferencia, string nome_igreja_transferencia, int ano_batismo,
            string imagem_location)
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
            this.Nome_cidade_transferencia = nome_cidade_transferencia;
            this.Estado_transferencia = estado_transferencia;
            this.Nome_igreja_transferencia = nome_igreja_transferencia;
            this.Data_batismo = ano_batismo;
            this.Img = imagem_location;

        }      

        /// <summary>
        /// Construtor sem paramentros
        /// </summary>

        public Membro_Transferencia()
        {

        }

        public override string alterar()
        {
             base.alterar();

            update_padrao = "update membro_transferencia set trans_cidade ='@cidade_transferencia', trans_nome_igreja = '@igreja', trans_estado = '@estado'" +
                " from membro_transferencia as MT inner join membro as M on M.id_membro=MT.trans_membro inner join pessoa as P on P.pes_id=M.memb_pessoa where pes_nome='@nome'";

            Update = update_padrao.Replace("@nome", this.Nome);
            Update = Update.Replace("@cidade_transferencia", nome_cidade_transferencia);
            Update = Update.Replace("@igreja", nome_igreja_transferencia);
            Update = Update.Replace("@estado", estado_transferencia);

            return bd.montar_sql(Update, null, null);
        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            bd = new BDcomum();
            select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa inner join telefone on pes_id=tel_pessoa @innerjoin " +
                " where pes_nome='@nome' or pes_cpf='@cpf'";

            Select = select_padrao.Replace("@nome", this.Nome);
            Select = Select.Replace("@cpf", this.Cpf);
            Select = Select.Replace("@innerjoin", " inner join membro on pes_id=memb_pessoa inner join membro_transferencia on id_membro=trans_membro ");

            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {

             base.salvar();

            insert_padrao = "insert into membro_transferencia (trans_cidade, trans_estado, trans_nome_igreja, trans_membro) values" +

              " ('@cidade', '@estado', '@nome_igreja', IDENT_CURRENT('membro'))";

            Insert = insert_padrao.Replace("@cidade", nome_cidade_transferencia);
            Insert = Insert.Replace("@estado", estado_transferencia);
            Insert = Insert.Replace("@nome_igreja", nome_igreja_transferencia);
            

            return bd.montar_sql(Insert, null, null);
            
        }
    }
}
