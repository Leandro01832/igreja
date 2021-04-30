using AplicativoXamarin.models;
using AplicativoXamarin.models.PessoasLgpd;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using Plugin.Media.Abstractions;
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

        const string URL = "http://www.igrejadeusbom.somee.com/";
         string URL_POST_PARTICIPARMINISTERIO = URL + "api/PessoaMinisterioApi";
         string URL_DELETE_PARTICIPARMINISTERIO = URL + "api/PessoaMinisterioApi/";        

         string URL_POST_PARTICIPARREUNIAO = URL + "api/ReuniaoPessoaApi";
         string URL_DELETE_PARTICIPARREUNIAO = URL + "api/ReuniaoPessoaApi/";
         

         string URL_GET_CELULA_USUARIO = URL + "api/CelulaApi/";

        internal async Task<Celula> GetCelulaUsuario()
        {
            HttpClient cliente = new HttpClient();
            var pessoa = await GetPessoa();
            if(pessoa.Celula != null)
            {
                var resultado = await cliente.GetStringAsync(URL_GET_CELULA_USUARIO + pessoa.celula_);
                var cel = JsonConvert.DeserializeObject<Celula>(resultado);
                return cel;
            }
            else
            {
                return null;
            }           
        }


        public static async Task<Pessoa> GetPessoa()
        {
            var login = new LoginServices();
            var resultado = await login.FazerLogin
            (new Login(App.UserCurrent.Email, App.UserCurrent.password, false));
            var conteudoResultado = await resultado.Content.ReadAsStringAsync();
            var resultadoLogin =
            JsonConvert.DeserializeObject<Pessoa>(conteudoResultado);
            return resultadoLogin;
        }

        public async  Task  CadastrarPessoa(RegisterViewModel msg)
        {
            HttpClient cliente = new HttpClient();

            Pessoa m = new Pessoa();
            string json = "";
            string UrlCadastrar = "";

            if (msg.Crianca)
            { m = new CriancaLgpd(); var cri = (CriancaLgpd)m; json = cri.ReturnJson(msg); UrlCadastrar = "api/CriancaLgpdApi"; }
            if (msg.Visitante)
            {
                m = new VisitanteLgpd();
                var v = (VisitanteLgpd)m;
                json = v.ReturnJson(msg);
                UrlCadastrar = "api/VisitanteLgpdApi";
            }

            if (msg.MembroAclamacao)
            { m = new Membro_AclamacaoLgpd(); var cri = (Membro_AclamacaoLgpd)m; json = cri.ReturnJson(msg);
                UrlCadastrar = "api/MembroAclamacaoLgpdApi"; }
            if (msg.MembroBatismo)
            { m = new Membro_BatismoLgpd(); var cri = (Membro_BatismoLgpd)m; json = cri.ReturnJson(msg);
                UrlCadastrar = "api/MembroBatismoLgpdApi"; }
            if (msg.MembroReconciliacao)
            { m = new Membro_ReconciliacaoLgpd(); var cri = (Membro_ReconciliacaoLgpd)m; json = cri.ReturnJson(msg);
                UrlCadastrar = "api/MembroReconciliacaoLgpdApi"; }
            if (msg.MembroTransferencia)
            { m = new Membro_TransferenciaLgpd(); var cri = (Membro_TransferenciaLgpd)m; json = cri.ReturnJson(msg);
                UrlCadastrar = "api/MembroTransferenciaLgpdApi"; }            

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            var resposta = await cliente.PostAsync(URL + UrlCadastrar, conteudo);
            if (resposta.IsSuccessStatusCode)
            {
                var result = await resposta.Content.ReadAsStringAsync();
                Pessoa p = JsonConvert.DeserializeObject<Pessoa>(result);
                MessagingCenter.Send<Pessoa>(p, "Cadastrado");
            }                
            else  MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaCadastro");
        }

        internal async Task<bool> SetPhoto(int idPessoa, Stream stream)
        {
            try
            {
                var array = ReadFully(stream);

                var photoRequest = new PhotoRequest
                {
                    Id = idPessoa,
                    Array = array,
                };

                var request = JsonConvert.SerializeObject(photoRequest);
                var body = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                var urlSetfoto = "SetFoto";
                var response = await client.PostAsync(URL + urlSetfoto, body);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                return true;
            }
            catch{ return false;}

        }

        private static byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[4 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
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
            (URL_POST_PARTICIPARMINISTERIO + "?$filter=MinisterioId eq " + Ministerio.IdMinisterio.ToString() +
            "&$filter=PessoaId eq " + App.UserCurrent.IdPessoa.ToString());
            var listaPessoaMinisterio = JsonConvert.DeserializeObject<PessoaMinisterio[]>(resultadoLista);

            var resposta = await cliente.DeleteAsync(URL_DELETE_PARTICIPARMINISTERIO + 
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
            (URL_POST_PARTICIPARREUNIAO + "?$filter=ReuniaoId eq " + Reuniao.IdReuniao.ToString() +
            "&$filter=PessoaId eq " + App.UserCurrent.IdPessoa.ToString());
            var listaReuniaoPessoa = JsonConvert.DeserializeObject<ReuniaoPessoa[]>(resultadoLista);

            var resposta = await cliente.DeleteAsync(URL_DELETE_PARTICIPARREUNIAO + 
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
