using AplicativoXamarin.models;
using AplicativoXamarin.models.Pessoas;
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
            
            var pessoa = await GetPessoa();
            if(pessoa.Celula != null)
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync(URL_GET_CELULA_USUARIO + pessoa.celula_);
                var cel = JsonConvert.DeserializeObject<Celula>(resultado);
                return cel;
            }
            else
            {
                return null;
            }           
        }

        internal async void EntrarCelula(Celula msg)
        {
            HttpClient cliente = new HttpClient();

            var id = App.UserCurrent.IdPessoa;

            var resultado = await cliente.GetStringAsync(URL + "api/PessoaApi/" + id);
            var p = JsonConvert.DeserializeObject<Pessoa>(resultado);

            var cel = new Pessoa
            {
                Celula = p.Celula,
                celula_ = msg.IdCelula,
                Chamada = p.Chamada,
                Codigo = p.Codigo,
                Email = p.Email,
                Falta = p.Falta,
                Historico = p.Historico,
                password = p.password,
                IdPessoa = p.IdPessoa,
                Img = p.Img,
                Lembrar_me = p.Lembrar_me,
                Ministerios = p.Ministerios,
                NomePessoa = p.NomePessoa,
                Reuniao = p.Reuniao
            };

            var request = JsonConvert.SerializeObject(cel);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var result = await cliente.PutAsync(URL + "api/PessoaApi/" + p.IdPessoa, body);

            if (result.IsSuccessStatusCode)
                MessagingCenter.Send<Celula>(msg, "SucessoEntrarCelula");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaEntrarCelula");
        }

        public static async Task<Pessoa> GetPessoa()
        {
            HttpClient cliente = new HttpClient();
            var resultado = await cliente.GetStringAsync(URL + "api/PessoaApi/" + App.UserCurrent.IdPessoa);            

            var pessoadado = JsonConvert.DeserializeObject<PessoaDado>(resultado);
            var pessoalgpd = JsonConvert.DeserializeObject<PessoaLgpd>(resultado);
            

            if (pessoadado.Endereco == null && pessoadado.Telefone == null && pessoadado.Cpf == null &&
                pessoadado.Rg == null && pessoadado.Status == null && pessoadado.Estado_civil == null)
            {
                if (resultado.Contains("Nome_mae"))
                    return JsonConvert.DeserializeObject<CriancaLgpd>(resultado);
                if (resultado.Contains("Estado_transferencia"))
                    return JsonConvert.DeserializeObject<Membro_TransferenciaLgpd>(resultado);
                if (resultado.Contains("Data_reconciliacao"))
                    return JsonConvert.DeserializeObject<Membro_ReconciliacaoLgpd>(resultado);
                if (resultado.Contains("Denominacao"))
                    return JsonConvert.DeserializeObject<Membro_AclamacaoLgpd>(resultado);
                if (resultado.Contains("Data_visita"))
                    return JsonConvert.DeserializeObject<VisitanteLgpd>(resultado);
                else return JsonConvert.DeserializeObject<Membro_BatismoLgpd>(resultado);
            }
            else
            {
                if (resultado.Contains("Nome_mae"))
                    return JsonConvert.DeserializeObject<Crianca>(resultado);
                if (resultado.Contains("Estado_transferencia"))
                    return JsonConvert.DeserializeObject<Membro_Transferencia>(resultado);
                if (resultado.Contains("Data_reconciliacao"))
                    return JsonConvert.DeserializeObject<Membro_Reconciliacao>(resultado);
                if (resultado.Contains("Denominacao"))
                    return JsonConvert.DeserializeObject<Membro_Aclamacao>(resultado);
                if (resultado.Contains("Data_visita"))
                    return JsonConvert.DeserializeObject<Visitante>(resultado);
                else return JsonConvert.DeserializeObject<Membro_Batismo>(resultado);
            }
            
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
        
        internal async Task<List<Pessoa>> RecuperarTodasPessoas()
        {
            HttpClient cliente = new HttpClient();
            var resultadoLista = await cliente.GetStringAsync
            (URL + "api/PessoaApi");
            var lista = JsonConvert.DeserializeObject<List<Pessoa>>(resultadoLista);
            return lista;
        }

        internal async void ExcluirPessoa(int idVelhoEstado)
        {
            HttpClient cliente = new HttpClient();

            var resposta = await cliente.DeleteAsync(URL + "api/PessoaApi/" + idVelhoEstado);
        }

        internal async Task<Pessoa> salvarPessoaMudancaEstado(modelocrud pessoa)
        {
            Pessoa p = (Pessoa)pessoa;
            var json = "";
            var UrlCadastrar = "";

            if (p is CriancaLgpd)
            { var cri = (CriancaLgpd)p; json = cri.ReturnJson(cri); UrlCadastrar = "CriancaCadastroApi"; }
            if (p is VisitanteLgpd)
            {
                var v = (VisitanteLgpd)p;
                json = v.ReturnJson(v);
                UrlCadastrar = "VisitanteCadastroApi";
            }

            if (p is Membro_AclamacaoLgpd)
            {
                var cri = (Membro_AclamacaoLgpd)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "MembroAclamacaoCadastroApi";
            }
            if (p is Membro_BatismoLgpd)
            {
                var cri = (Membro_BatismoLgpd)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "MembroBatismoCadastroApi";
            }
            if (p is Membro_ReconciliacaoLgpd)
            {
                var cri = (Membro_ReconciliacaoLgpd)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "MembroReconciliacaoCadastroApi";
            }
            if (p is Membro_TransferenciaLgpd)
            {
                var cri = (Membro_TransferenciaLgpd)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "MembroTransferenciaCadastroApi";
            }


            if (p is Crianca)
            { var cri = (Crianca)p; json = cri.ReturnJson(cri); UrlCadastrar = "api/CriancaApi"; }
            if (p is Visitante)
            {
                var v = (Visitante)p;
                json = v.ReturnJson(v);
                UrlCadastrar = "api/VisitanteApi";
            }

            if (p is Membro_Aclamacao)
            {
                var cri = (Membro_Aclamacao)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "api/MembroAclamacaoApi";
            }
            if (p is Membro_Batismo)
            {
                var cri = (Membro_Batismo)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "api/MembroBatismoApi";
            }
            if (p is Membro_Reconciliacao)
            {
                var cri = (Membro_Reconciliacao)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "api/MembroReconciliacaoApi";
            }
            if (p is Membro_Transferencia)
            {
                var cri = (Membro_Transferencia)p; json = cri.ReturnJson(cri);
                UrlCadastrar = "api/MembroTransferenciaApi";
            }

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(URL + UrlCadastrar, conteudo);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Pessoa pes = JsonConvert.DeserializeObject<Pessoa>(result);
                return pes;
            }
            return null;
        }

        internal async void salvarMudancaEstado(MudancaEstado mudanca)
        {
            var request = JsonConvert.SerializeObject(mudanca);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var urlSet = "api/MudancaEstadoApi";
            var response = await client.PostAsync(URL + urlSet, body);
        }

        internal async Task<PessoaMinisterio> retornaPessoaMinsterio(int idPessoaMinisterio)
        {
            HttpClient cliente = new HttpClient();
            var resultadoLista = await cliente.GetStringAsync
            (URL + "api/PessoaMinisterioApi/" + idPessoaMinisterio);
            return JsonConvert.DeserializeObject<PessoaMinisterio>(resultadoLista);
        }

        internal async Task<ReuniaoPessoa> retornaReuniaoPessoa(int idReuniaoPessoa)
        {
            HttpClient cliente = new HttpClient();
            var resultadoLista = await cliente.GetStringAsync
            (URL + "api/ReuniaoPessoaApi/" + idReuniaoPessoa);
            return JsonConvert.DeserializeObject<ReuniaoPessoa>(resultadoLista);
        }

        internal async void salvarEndereco(Endereco endereco)
        {
            var request = JsonConvert.SerializeObject(endereco);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var urlSet = "api/EnderecoApi";
            var response = await client.PostAsync(URL + urlSet, body);
        }

        internal async void salvarTelefone(Telefone telefone)
        {
            var request = JsonConvert.SerializeObject(telefone);
            var body = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var urlSet = "api/TelefoneApi";
            var response = await client.PostAsync(URL + urlSet, body);
        }
    }
}
