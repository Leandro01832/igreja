using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;



namespace AplicativoXamarin.ViewModels
{
    public class LoginServices
    {

        public LoginServices()
        {
        }

        public async Task<HttpResponseMessage> FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://igrejadeusbom.somee.com");
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("Email", login.email),
                        new KeyValuePair<string, string>("Password", login.senha)
                    });
                var resultado = await cliente.PostAsync("/Login", camposFormulario);

                return resultado;
            }
        }
    }
}