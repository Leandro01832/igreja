using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.Pessoas
{
    public class Membro_Batismo : Membro
    {
        public Membro_Batismo() : base()
        {
        }

        internal string ReturnJson(Membro_Batismo cri)
        {
            var j = JsonConvert.SerializeObject(cri);
            return j;
        }
    }
}
