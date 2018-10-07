using igreja2.banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igreja2.classes
{
    class Chamada : modelocrud
    {
        private int id;
        private DateTime data_inicio;

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

        public Chamada()
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
            DateTime data = DateTime.Now.AddDays(-60);
            select_padrao = "select * from pessoa inner join chamada on pes_id=hist_pessoa where data_inicio<'@data'";
            Select = select_padrao.Replace("@data", data.ToString());
         return   bd.buscar_dados(Select, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null, null, null, null, null,
               null, null, null, null, null, null, null, null);
        }

        public override string salvar()
        {
            throw new NotImplementedException();
        }

    }
}
