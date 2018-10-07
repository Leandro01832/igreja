using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igreja2.banco;

namespace igreja2.classes
{
   public class Telefone : modelocrud
    {
        private int    id;
        private string fone;
        private string celular;
        private string whatsapp;

        public string Fone
        {
            get
            {
                return fone;
            }

            set
            {
                fone = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Whatsapp
        {
            get
            {
                return whatsapp;
            }

            set
            {
                whatsapp = value;
            }
        }

        public Telefone()
        {
          
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
            throw new NotImplementedException();
        }

    }
}
