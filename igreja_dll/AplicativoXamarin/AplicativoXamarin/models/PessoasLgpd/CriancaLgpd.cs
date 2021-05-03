using AplicativoXamarin.models.Pessoas;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;

namespace AplicativoXamarin.models.PessoasLgpd
{
    public class CriancaLgpd : PessoaLgpd
    {
        public string Nome_pai { get; set; }
        public string Nome_mae { get; set; }

        public CriancaLgpd() : base()
        {
        }

        internal string ReturnJson(RegisterViewModel msg)
        {
            var j = JsonConvert.SerializeObject(new
            {
                Email = msg.Email,
                password = msg.Password,
                Nome_pai = " - ",
                Nome_mae = " - ",
                NomePessoa = " - "
            });

            return j;
        }
    }
}
