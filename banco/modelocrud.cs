using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.banco
{
     public abstract class  modelocrud
    {
        protected string insert_padrao;
        protected string update_padrao;
        protected string delete_padrao;
        protected string select_padrao;

        private string insert;
        private string update;
        private string delete;
        private string select;

        public BDcomum bd;

        protected string Insert
        {
            get
            {
                return insert;
            }

            set
            {
                insert = value;
            }
        }

        protected string Update
        {
            get
            {
                return update;
            }

            set
            {
                update = value;
            }
        }

        protected string Delete
        {
            get
            {
                return delete;
            }

            set
            {
                delete = value;
            }
        }

        protected string Select
        {
            get
            {
                return select;
            }

            set
            {
                select = value;
            }
        }

        public abstract string salvar();
        public abstract string alterar();
        public abstract string excluir();
        public abstract string recuperar();
      
    }
}
