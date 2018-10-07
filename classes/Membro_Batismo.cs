using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igreja2.classes
{
    public class Membro_Batismo : Membro
    {
        private int id;

        public int Id
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

        public Membro_Batismo(string nome, bool sexo_masculino, bool sexo_feminino,
            string data_nascimento, string rg, bool falescimento, string email, string cpf,
            int falta, string pais, string cidade, string bairro, string rua, string estado,
            int numero_casa, int cep, string complemento, string estado_civil, string status,
            string telefone, string celular, string whatsapp, int ano_batismo,
            string imagem_location)
        {
            bd = new banco.BDcomum();

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
            this.Data_batismo = ano_batismo;
            this.Img = imagem_location;
        }

        /// <summary>
        /// Construtor sem parametros
        /// </summary>

        public Membro_Batismo()
        {

        }

        public override string alterar()
        {
            return base.alterar();
        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa inner join telefone on pes_id=tel_pessoa @innerjoin " +
                " where pes_nome='@nome' or pes_cpf='@cpf'";

            Select = select_padrao.Replace("@nome", this.Nome);
            Select = Select.Replace("@cpf", this.Cpf);
            Select = Select.Replace("@innerjoin", " inner join membro on pes_id=memb_pessoa inner join membro_batismo on id_membro=bat_membro ");

            return Select;
        }

        public override string salvar()
        {
             base.salvar();

            insert_padrao = "insert into membro_batismo (bat_membro) values (IDENT_CURRENT('membro'))";          

            return bd.montar_sql(insert_padrao, null, null);
        }
    }
}
