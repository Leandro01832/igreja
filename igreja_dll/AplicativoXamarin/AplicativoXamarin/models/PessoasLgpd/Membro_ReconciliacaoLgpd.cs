using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class Membro_ReconciliacaoLgpd : MembroLgpd
    {        
        public int Data_reconciliacao { get; set; }

        public Membro_ReconciliacaoLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Data_reconciliacao = 0,
                NomePessoa = " - "
            });

            return j;
        }
    }
}
