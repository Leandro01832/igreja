using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Supervisor_Treinamento : Pessoa
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
                    MessageBox.Show("O id de supervisor em treinamento deve ser preenchido");
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

        public Supervisor_Treinamento()
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
            return base.recuperar();
        }

        public override string salvar()
        {
            insert_padrao = "insert into supervisor_treinamento " +
                " (sup_treinamento_pessoa) values ('@id')";
            Insert = insert_padrao.Replace("@id", id.ToString());

           return bd.montar_sql(Insert, null, null);
        }
    }
}
