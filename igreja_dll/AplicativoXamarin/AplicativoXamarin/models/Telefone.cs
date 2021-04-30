using AplicativoXamarin.models.Pessoas;

namespace AplicativoXamarin.models
{

    public class Telefone 
    {
        public int IdTelefone {  get; set; }
        public virtual PessoaDado Pessoa { get; set; }

        public string Fone { get; set; }

        public string Celular { get; set; }

        public string Whatsapp { get; set; }

        public Telefone()
        {
        }

    }
}
