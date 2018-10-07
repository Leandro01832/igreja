using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igreja2.classes
{
   public class Endereco : Telefone
    {
        private int    id;
        private string pais;
        private string estado;
        private string cidade;
        private string bairro;
        private string rua;
        private int    numero_casa;
        private long   cep;
        private string complemento;

        public string Pais
        {
            get
            {
                return pais;
            }

            set
            {
                if (value != "")
                pais = value;
                else
                {
                    MessageBox.Show("país precisa ser preenchido corretamente!!!");
                    pais = null;
                }
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                if(value != "")
                estado = value;
                else
                {
                    MessageBox.Show("Estado precisa ser preenchido corretamente!!!");
                    estado = null;
                }
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                if(value != "")
                cidade = value;
                else
                {
                    MessageBox.Show("cidade precisa ser preenchido corretamente!!!");
                    cidade = null;
                }
            }
          
        }

        public string Bairro
        {
            get
            {
                return bairro;
            }

            set
            {
                if(value != "")
                bairro = value;
                else
                {
                    MessageBox.Show("bairro precisa ser preenchido corretamente!!!");
                    bairro = null;
                }
            }
        }

        public string Rua
        {
            get
            {
                return rua;
            }

            set
            {
                if (value!= "")
                rua = value;
                else
                {
                    MessageBox.Show("rua precisa ser preenchido corretamente!!!");
                    rua = null;
                }
            }
        }

        public int Numero_casa
        {
            get
            {
                return numero_casa;
            }

            set
            {
                if (value != 0)
                numero_casa = value;
                else
                {
                    MessageBox.Show("numero da casa precisa ser preenchido corretamente!!!");
                    numero_casa = 0;
                }
            }
        }

        public long Cep
        {
            get
            {
                return cep;
            }

            set
            {
                if(value != 0)
                cep = value;
                else
                {
                    MessageBox.Show("Cep precisa ser preenchido corretamente!!!");
                    cep = 0;
                }
            }
        }

        public string Complemento
        {
            get
            {
                return complemento;
            }

            set
            {                
                complemento = value;
            }
        }

        public Endereco()
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
            return base.salvar();
        }

    }
}
