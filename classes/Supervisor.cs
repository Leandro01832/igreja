using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Supervisor : Pessoa
    {
        private int id;
        private List<Celula> celulas;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                if(value != 0)
                id = value;
                else
                {
                    MessageBox.Show("O id de supervisor deve ser preenchido");
                    id = 0;
                }
            }
        }

        internal List<Celula> Celulas
        {
            get
            {
                return celulas;
            }

            set
            {
                celulas = value;
            }
        }

        public Supervisor()
        {
            bd = new banco.BDcomum();
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
            select_padrao = "select * from pessoa inner join supervisor on pes_id=super_pessoa where pes_id='@id'";
            Select = select_padrao.Replace("@id", id.ToString());

            return bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {
            insert_padrao = "insert into supervisor " +
                " (super_pessoa) values ('@id')";
            Insert = insert_padrao.Replace("@id", id.ToString());

            return bd.montar_sql(Insert, null, null);
        }
    }
}
