using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using igreja2.banco;
using System.Windows.Forms;

namespace igreja2.classes
{
    class Endereco_Celula : modelocrud
    {
        private int cel_cep;
        private string cel_bairro;
        private string cel_rua;
        private int cel_numero;

        public int Cel_cep
        {
            get
            {
                return cel_cep;
            }

            set
            {                
                cel_cep = value;               
            }
        }

        public string Cel_bairro
        {
            get
            {
                return cel_bairro;
            }

            set
            {
                if(value != "")
                cel_bairro = value;
                else
                {
                    MessageBox.Show("Informe o bairro para reunião de celula");
                    cel_bairro = null;
                }
            }
        }

        public string Cel_rua
        {
            get
            {
                return cel_rua;
            }

            set
            {
                if(value != "")
                cel_rua = value;
                else
                {
                    MessageBox.Show("Informe a rua para reunião de celula");
                    cel_rua = null;
                }
            }
        }

        public int Cel_numero
        {
            get
            {
                return cel_numero;
            }

            set
            {
                if(value != 0)
                cel_numero = value;
                else
                {
                    MessageBox.Show("Informe o numero da casa para reunião de celula");
                    cel_numero = 0;
                }
            }
        }

        public Endereco_Celula()
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
