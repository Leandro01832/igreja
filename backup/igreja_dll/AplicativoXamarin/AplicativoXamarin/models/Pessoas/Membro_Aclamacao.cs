using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.Pessoas
{
    public class Membro_Aclamacao : Membro
    {
        public string Denominacao { get; set; }

        public Membro_Aclamacao() : base()
        {
        }

        internal string ReturnJson(Membro_Aclamacao cri)
        {
            var j = JsonConvert.SerializeObject(cri);
            return j;
        }
    }
}
