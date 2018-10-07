using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igreja2.classes
{
    class Historico : modelocrud
    {
        private int id;
        private DateTime data_inicio;
        private DateTime data_fim;
        private int falta;

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

        public DateTime Data_inicio
        {
            get
            {
                return data_inicio;
            }

            set
            {
                data_inicio = value;
            }
        }

        public int Falta
        {
            get
            {
                return falta;
            }

            set
            {
                falta = value;
            }
        }

        public DateTime Data_fim
        {
            get
            {
                return data_fim;
            }

            set
            {
                data_fim = value;
            }
        }

        public Historico()
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
            insert_padrao = "insert into historico (data_inicio, data_fim, falta, histo_pessoa)"+
            " values (@data-inicio, @data_fim, @falta, @id_pessoa)";
            return bd.buscar_dados(insert_padrao, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }




    }
}
