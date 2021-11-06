using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.Pessoas
{
    public class Crianca : PessoaDado
    {
        public string Nome_pai { get; set; }
        public string Nome_mae { get; set; }

        public Crianca() : base()
        {
        }

        internal string ReturnJson(Crianca cri)
        {
            var j = JsonConvert.SerializeObject(cri);
            return j;
        }
    }
}
