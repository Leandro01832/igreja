
using System;

namespace AplicativoXamarin.models.Pessoas
{
    public  class PessoaDado : Pessoa 
    {
        public PessoaDado() : base()
        {
           
        }

        //propriedades
        #region
        public DateTime Data_nascimento { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        
        public string Estado_civil { get; set; }
        public bool Sexo_masculino { get; set; }        
        public bool Sexo_feminino { get; set; }        
        public bool Falescimento { get; set; }
        public string Status { get; set; }        
        public virtual Endereco Endereco { get; set; }        
        public virtual Telefone Telefone { get; set; }

        #endregion
        


    }
}
