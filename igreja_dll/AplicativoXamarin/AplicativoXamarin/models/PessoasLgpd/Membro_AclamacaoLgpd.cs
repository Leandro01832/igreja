using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class Membro_AclamacaoLgpd : MembroLgpd
    {
        public string Denominacao { get; set; }

        public Membro_AclamacaoLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Denominacao = " - ",
                NomePessoa = " - "
            });

            return j;
        }

        internal string ReturnJson(Membro_AclamacaoLgpd msg)
        {
            var j = JsonConvert.SerializeObject(msg);

            return j;
        }
    }
}
