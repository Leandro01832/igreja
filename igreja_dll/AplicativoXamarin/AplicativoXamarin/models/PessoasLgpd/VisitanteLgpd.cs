
using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class VisitanteLgpd : PessoaLgpd
    {       
        public DateTime Data_visita { get; set; }
        
        public string Condicao_religiosa { get; set; }

        public VisitanteLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Data_visita = DateTime.Now,
                Condicao_religiosa = " - ",
                NomePessoa = " - "
            });

            return j;
        }

        internal string ReturnJson(VisitanteLgpd msg)
        {
            var j = JsonConvert.SerializeObject(msg);

            return j;
        }
    }
}
