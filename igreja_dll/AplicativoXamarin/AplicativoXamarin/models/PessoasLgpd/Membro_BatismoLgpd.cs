using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class Membro_BatismoLgpd : MembroLgpd
    {
        public Membro_BatismoLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                NomePessoa = " - "
            });

            return j;
        }

        internal string ReturnJson(Membro_BatismoLgpd msg)
        {
            var j = JsonConvert.SerializeObject(msg);

            return j;
        }
    }
}
