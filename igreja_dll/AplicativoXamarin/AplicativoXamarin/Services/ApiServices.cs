using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoXamarin.Services
{
   public class ApiServices
    {
        const string URL_POST_PARTICIPARMINISTERIO = "http://www.igrejadeusbom.somee.com/api/PessoaMinisterioApi";
        const string URL_DELETE_PARTICIPARMINISTERIO = "http://www.igrejadeusbom.somee.com/api/PessoaMinisterioApi";
        const string URL_POST_PARTICIPARREUNIAO = "http://www.igrejadeusbom.somee.com/api/ReuniaoPessoaApi";
        const string URL_DELETE_PARTICIPARREUNIAO = "http://www.igrejadeusbom.somee.com/api/ReuniaoPessoaApi";


        public static async Task<Pessoa> GetPessoa()
        {
            var login = new LoginServices();
            var resultado = await login.FazerLogin
            (new Login(App.UserCurrent.Email, App.UserCurrent.Password, false));
            var conteudoResultado = await resultado.Content.ReadAsStringAsync();
            var resultadoLogin =
            JsonConvert.DeserializeObject<Pessoa>(conteudoResultado);
            return resultadoLogin;
        }

        public async  Task  CadastrarPessoa(RegisterViewModel msg)
        {
            HttpClient cliente = new HttpClient();

            var json = JsonConvert.SerializeObject(new
            {
                Crianca = msg.Crianca,
                Visitante = msg.Visitante,
                MembroAclamacao = msg.MembroAclamacao,
                MembroBatismo = msg.MembroBatismo,
                MembroReconciliacao = msg.MembroReconciliacao,
                MembroTransferencia = msg.MembroTransferencia,
                Email = msg.Email,
                Password = msg.Password
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_PARTICIPARREUNIAO, conteudo);
            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<RegisterViewModel>(msg, "Cadastrado");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaCadastro");
        }

        public async void ParticiparMinisterio(Ministerio Ministerio)
        {
            HttpClient cliente = new HttpClient();           

            var json = JsonConvert.SerializeObject(new
            {
                MinisterioId = Ministerio.IdMinisterio,
                PessoaId = App.UserCurrent.IdPessoa
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_PARTICIPARMINISTERIO, conteudo);
            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Ministerio>(Ministerio, "SucessoParticiparMinisterio");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaParticiparMinisterio");
        }

        internal async void SairMinisterio(Ministerio Ministerio)
        {
            HttpClient cliente = new HttpClient();

            var resultadoLista = await cliente.GetStringAsync
            (URL_DELETE_PARTICIPARMINISTERIO +"$filter=MinisterioId eq " + Ministerio.IdMinisterio.ToString() +
            "&filter=PessoaId eq " + App.UserCurrent.IdPessoa.ToString());
            var listaPessoaMinisterio = JsonConvert.DeserializeObject<PessoaMinisterio[]>(resultadoLista);

            var resposta = await cliente.DeleteAsync(URL_DELETE_PARTICIPARMINISTERIO + "/" +
                 listaPessoaMinisterio[0].IdPessoaMinisterio.ToString());


            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Ministerio>(Ministerio, "SucessoSairMinisterio");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaSairMinisterio");
        }

        public async void ParticiparReuniao(Reuniao Reuniao)
        {
            HttpClient cliente = new HttpClient();

            var json = JsonConvert.SerializeObject(new
            {
                ReuniaoId = Reuniao.IdReuniao,
                PessoaId = App.UserCurrent.IdPessoa
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL_POST_PARTICIPARREUNIAO, conteudo);
            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Reuniao>(Reuniao, "SucessoParticiparReuniao");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaParticiparReuniao");
        }

        internal async void SairReuniao(Reuniao Reuniao)
        {
            HttpClient cliente = new HttpClient();

            var resultadoLista = await cliente.GetStringAsync
            (URL_DELETE_PARTICIPARREUNIAO + "$filter=MinisterioId eq " + Reuniao.IdReuniao.ToString() +
            "&filter=PessoaId eq " + App.UserCurrent.IdPessoa.ToString());
            var listaReuniaoPessoa = JsonConvert.DeserializeObject<ReuniaoPessoa[]>(resultadoLista);

            var resposta = await cliente.DeleteAsync(URL_DELETE_PARTICIPARREUNIAO + "/" +
                 listaReuniaoPessoa[0].IdReuniaoPessoa.ToString());

            if (resposta.IsSuccessStatusCode)
                MessagingCenter.Send<Reuniao>(Reuniao, "SucessoSairReuniao");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaSairReuniao");
        }


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
