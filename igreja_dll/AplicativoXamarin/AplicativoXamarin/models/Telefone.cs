using AplicativoXamarin.models.Pessoas;
using Newtonsoft.Json;

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

        public string RetornaJson(Telefone tel)
        {
            var j = JsonConvert.SerializeObject(new Telefone
            {
                IdTelefone  = tel.IdTelefone,
                Fone        = tel.Fone,
                Celular     = tel.Celular,
                Whatsapp    = tel.Whatsapp
            });

            return j;
        }

    }
}
