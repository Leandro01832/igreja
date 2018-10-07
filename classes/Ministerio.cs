using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Ministerio : modelocrud
    {
        private int id;
        private string nome;
        private string lider;
        private string proprosito;

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

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                if(value != "")
                nome = value;
                else
                {
                    MessageBox.Show("informe o nome do ministério");
                    nome = null;
                }
            }
        }

        public string Lider
        {
            get
            {
                return lider;
            }

            set
            {
                if(value != "")
                lider = value;
                else
                {
                    MessageBox.Show("Informe o nome do lider");
                    lider = null;
                }
            }
        }

        public string Proprosito
        {
            get
            {
                return proprosito;
            }

            set
            {
                if(value != "")
                proprosito = value;
                else
                {
                    MessageBox.Show("Informe o proposito do ministerio.");
                    proprosito = null;
                }
            }
        }

        public Ministerio()
        {
            bd = new BDcomum();
        }

        public override string alterar()
        {
            throw new NotImplementedException();
        }

        public override string excluir()
        {
            throw new NotImplementedException();
        }

        public override string recuperar()
        {
            throw new NotImplementedException();
        }

        public override string salvar()
        {
            insert_padrao = "insert into ministerio (minis_nome, minis_lider, minis_proposito) values " +
                " ('@nome', '@lider', '@proposito')";

            Insert = insert_padrao.Replace("@nome", nome);
            Insert = Insert.Replace("@lider", lider);
            Insert = Insert.Replace("@proposito", proprosito);

            return bd.montar_sql(Insert, null, null);
        }

    }
}
