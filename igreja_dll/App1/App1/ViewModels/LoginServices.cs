using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mobile.models;

namespace Mobile.ViewModels
{
    internal class LoginServices
    {
        public LoginServices()
        {
        }

        public async Task<HttpResponseMessage> FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://www.igrejadedeus.somee.com");
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string, string>("password", login.senha)
                    });
                var resultado = await cliente.PostAsync("/Login", camposFormulario);

                return resultado;
            }
        }
    }
}