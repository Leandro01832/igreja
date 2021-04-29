
using System;
using System.Collections.Generic;

namespace AplicativoXamarin.models
{
    public class EnderecoCelula 
    {
        private string pais;
        private string estado;
        private string cidade;
        private string bairro;
        private string rua;
        private int numero_casa;
        private long cep;
        private string complemento;
        
        public int IdEnderecoCelula { get; set; }
        public virtual Celula Celula { get; set; }
        public string Pais { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public int Numero_casa { get; set; }

        public long Cep { get; set; }

        public string Complemento { get; set; }

        public EnderecoCelula() : base()
        {
        }

    }

}