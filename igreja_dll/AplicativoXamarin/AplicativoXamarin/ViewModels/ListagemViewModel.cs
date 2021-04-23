using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {

        const string URL_GET_MINISTERIOS = "http://www.igrejadedeus.somee.com/api/MinisterioApi";
        const string URL_GET_REUNIOES = "http://www.igrejadedeus.somee.com/api/ReuniaoApi";

        public ObservableCollection<Ministerio> Ministerios { get; set; }
        public ObservableCollection<Reuniao> Reunioes { get; set; }
        public Pessoa resultadoLogin { get; set; }

        Reuniao reuniaoSelecionado;
        public Reuniao ReuniaoSelecionado
        {
            get
            {
                return reuniaoSelecionado;
            }
            set
            {
                reuniaoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(reuniaoSelecionado, "ReuniaoSelecionado");
            }
        }

        Ministerio ministerioSelecionado;
        public Ministerio MinisterioSelecionado
        {
            get
            {
                return ministerioSelecionado;
            }
            set
            {
                ministerioSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(ministerioSelecionado, "VeiculoSelecionado");
            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }


        public ListagemViewModel()
        {
            this.Ministerios = new ObservableCollection<Ministerio>();
            this.Reunioes = new ObservableCollection<Reuniao>();
             
        }

        public async Task GetMinisterios(bool recuperarTodos)
        {
            Aguarde = true;
            try
            {
                List<PessoaMinisterio> listaPessoaMinisterio = new List<PessoaMinisterio>();
                Pessoa resultadoLogin = await GetPessoa();
                listaPessoaMinisterio = resultadoLogin.Ministerios;
                if (!recuperarTodos)
                {
                    this.Ministerios.Clear();
                    foreach (var ministerioJson in listaPessoaMinisterio)
                    {
                        this.Ministerios.Add(new Ministerio
                        {
                            Nome = ministerioJson.Ministerio.Nome,
                            IdMinisterio = ministerioJson.Ministerio.IdMinisterio,
                            Celulas = ministerioJson.Ministerio.Celulas,
                            Maximo_pessoa = ministerioJson.Ministerio.Maximo_pessoa,
                            Ministro_ = ministerioJson.Ministerio.Ministro_,
                            Pessoas = ministerioJson.Ministerio.Pessoas,
                            Proposito = ministerioJson.Ministerio.Proposito
                        });
                    }
                }
                else
                {
                    HttpClient cliente = new HttpClient();
                    var resultado = await cliente.GetStringAsync(URL_GET_MINISTERIOS);

                   var lista = JsonConvert.DeserializeObject<Ministerio[]>(resultado);

                    this.Ministerios.Clear();
                    foreach (var ministerioJson in lista)
                    {
                        if(listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) == null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) == null ||
                           listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) == null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) != null  ||
                           listaPessoaMinisterio.FirstOrDefault(i => i.MinisterioId == ministerioJson.IdMinisterio) != null &&
                           listaPessoaMinisterio.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) == null)
                            this.Ministerios.Add(new Ministerio
                        {
                            Nome = ministerioJson.Nome,
                            IdMinisterio = ministerioJson.IdMinisterio,
                            Celulas = ministerioJson.Celulas,
                            Maximo_pessoa = ministerioJson.Maximo_pessoa,
                            Ministro_ = ministerioJson.Ministro_,
                            Pessoas = ministerioJson.Pessoas,
                            Proposito = ministerioJson.Proposito
                        });
                    }
                }               
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }
            Aguarde = false;
        }        

        public async Task GetReunioes(bool recuperarTodos)
        {
            Aguarde = true; 

            try
            {
                List<ReuniaoPessoa> listaReuniaoPessoa = new List<ReuniaoPessoa>();
                Pessoa resultadoLogin = await GetPessoa();
                listaReuniaoPessoa = resultadoLogin.Reuniao;

                if (!recuperarTodos)
                {
                    
                    this.Ministerios.Clear();
                    foreach (var reuniao in resultadoLogin.Reuniao)
                    {
                        this.Reunioes.Add(new Reuniao
                        {
                            Data_reuniao = reuniao.Reuniao.Data_reuniao,
                            Horario_fim = reuniao.Reuniao.Horario_fim,
                            Horario_inicio = reuniao.Reuniao.Horario_inicio,
                            IdReuniao = reuniao.Reuniao.IdReuniao,
                            Local_reuniao = reuniao.Reuniao.Local_reuniao,
                            Pessoas = reuniao.Reuniao.Pessoas
                        });
                    }
                }
                else
                {
                    HttpClient cliente = new HttpClient();
                    var resultado = await cliente.GetStringAsync(URL_GET_REUNIOES);

                    var lista = JsonConvert.DeserializeObject<Reuniao[]>(resultado);

                    this.Ministerios.Clear();
                    foreach (var reuniao in lista)
                    {
                        //condicao que indica se usuario não pertence a esta reuniao
                        if(listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.IdReuniao) == null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) == null ||
                           listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.IdReuniao) != null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) == null ||
                           listaReuniaoPessoa.FirstOrDefault(i => i.ReuniaoId == reuniao.IdReuniao) == null &&
                           listaReuniaoPessoa.FirstOrDefault(i => i.PessoaId == resultadoLogin.IdPessoa) != null)
                        this.Reunioes.Add(new Reuniao
                        {
                            Data_reuniao = reuniao.Data_reuniao,
                            Horario_fim = reuniao.Horario_fim,
                            Horario_inicio = reuniao.Horario_inicio,
                            IdReuniao = reuniao.IdReuniao,
                            Local_reuniao = reuniao.Local_reuniao,
                            Pessoas = reuniao.Pessoas
                        });
                    }
                }

                
            }
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }
            Aguarde = false;
        }

        private static async Task<Pessoa> GetPessoa()
        {
            var login = new LoginServices();
            var resultado = await login.FazerLogin
            (new Login(App.UserCurrent.Email, App.UserCurrent.Password, false));
            var conteudoResultado = await resultado.Content.ReadAsStringAsync();
            var resultadoLogin =
            JsonConvert.DeserializeObject<Pessoa>(conteudoResultado);
            return resultadoLogin;
        }
    }

    
}
