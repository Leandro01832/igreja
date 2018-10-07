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
   public class Membro : Pessoa
    {
        private int data_batismo;
        private bool desligamento;

        public int Data_batismo
        {
            get
            {
                return data_batismo;
            }

            set
            {
                data_batismo = value;
            }
        }

        public bool Desligamento
        {
            get
            {
                return desligamento;
            }

            set
            {
                desligamento = value;
            }
        }

        public Membro()
        {
            bd = new BDcomum();
        }       

        public override string alterar()
        {
             base.alterar();

            update_padrao = "update membro set desligamento = '@desligamento', ano_batismo = '@ano_batismo' " +
                    " from membro as M inner join pessoa as P on P.pes_id=M.memb_pessoa where pes_nome='@nome' or pes_cpf='@cpf' ";
            Update = update_padrao.Replace("@nome", this.Nome);
            Update = Update.Replace("@desligamento", desligamento.ToString());
            Update = Update.Replace("@ano_batismo", data_batismo.ToString());

            return bd.montar_sql(Update, null, null);
        }

        public override string excluir()
        {
            return base.excluir();
        }

        public override string recuperar()
        {
            bd = new BDcomum();
     select_padrao = "select * from pessoa inner join endereco on pes_id=end_pessoa " +
     " inner join telefone on pes_id=tel_pessoa @innerjoin where pes_nome='@nome' or pes_cpf='@cpf'";

            Select = select_padrao.Replace("@nome", this.Nome);
            Select = Select.Replace("@cpf", this.Cpf);
            Select = Select.Replace("@innerjoin", " inner join membro on pes_id=memb_pessoa ");

            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);

        }

        public override string salvar()
        {
             base.salvar();

            insert_padrao = "insert into membro (desligamento, ano_batismo, memb_pessoa) values('@desligamento', '@ano_batismo', IDENT_CURRENT('pessoa'))";
               

            Insert = insert_padrao.Replace("@desligamento", false.ToString() );
            Insert = Insert.Replace("@ano_batismo", Data_batismo.ToString());

            return bd.montar_sql(Insert, null, null);
        }
    }
}
