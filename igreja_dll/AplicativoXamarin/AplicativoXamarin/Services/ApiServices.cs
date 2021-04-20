using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace AplicativoXamarin.Services
{
   public class ApiServices
    {

        public TRetorno Post<TEnvio, TRetorno>(TEnvio data, Stream arquivo)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("")
                };

                var content = new MultipartFormDataContent();

                content.Add(new StreamContent(arquivo), "file", "filename");

                httpRequest.Content = content;

                using (var response = httpClient.SendAsync(httpRequest).Result)
                {
                    return JsonConvert.DeserializeObject<TRetorno>(response.Content.ReadAsStringAsync().Result);
                }
            }
        }
    }
}
