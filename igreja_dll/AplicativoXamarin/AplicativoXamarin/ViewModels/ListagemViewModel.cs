using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoXamarin.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {       

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

        public async Task GetMinisterios()
        {
            Aguarde = true;
            try
            {
                Pessoa resultadoLogin = await GetPessoa();
                this.Ministerios.Clear();
                foreach (var ministerioJson in resultadoLogin.Ministerios)
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
            catch (Exception exc)
            {
                MessagingCenter.Send<Exception>(exc, "FalhaListagem");
            }
            Aguarde = false;
        }        

        public async Task GetReunioes()
        {
            Aguarde = true; 

            try
            {
                Pessoa resultadoLogin = await GetPessoa();
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
