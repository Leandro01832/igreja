
using AplicativoXamarin.models;

namespace AplicativoXamarin.models
{
   public class PessoaMinisterio 
    {
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int MinisterioId { get; set; }
        public virtual Ministerio Ministerio { get; set; }
    }
    
}
