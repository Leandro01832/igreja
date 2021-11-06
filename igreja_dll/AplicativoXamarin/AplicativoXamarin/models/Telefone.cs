using AplicativoXamarin.models.Pessoas;
using Newtonsoft.Json;

namespace AplicativoXamarin.models
{

    public class Telefone 
    {
        public int Id {  get; set; }
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
                Id  = tel.Id,
                Fone        = tel.Fone,
                Celular     = tel.Celular,
                Whatsapp    = tel.Whatsapp
            });

            return j;
        }

    }
}
