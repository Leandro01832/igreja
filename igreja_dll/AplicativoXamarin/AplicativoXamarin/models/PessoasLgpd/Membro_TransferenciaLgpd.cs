using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class Membro_TransferenciaLgpd : MembroLgpd
    {  
        public string Nome_cidade_transferencia { get; set; }        
        public string Estado_transferencia { get; set; }
        public string Nome_igreja_transferencia { get; set; }

        public Membro_TransferenciaLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Nome_cidade_transferencia = " - ",
                Estado_transferencia = " - ",
                Nome_igreja_transferencia = " - ",
                NomePessoa = " - "
            });

            return j;
        }

        internal string ReturnJson(Membro_TransferenciaLgpd msg)
        {
            var j = JsonConvert.SerializeObject(msg);

            return j;
        }
    }
}
