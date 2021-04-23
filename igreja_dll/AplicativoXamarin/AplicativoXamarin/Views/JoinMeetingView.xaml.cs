using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JoinMeetingView : ContentPage
    {
        public ListagemViewModel Listagem { get; set; }

        public JoinMeetingView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Reuniao>(this, "ReuniaoSelecionado",
              async (msg) =>
               {
                   if(await DisplayAlert("Confirmação", "Deseja realmente participar desta reunião?", "SIM", "Cancelar"))
                   {
                       using (var cliente = new HttpClient())
                       {
                           cliente.BaseAddress = new Uri("http://igrejadeusbom.somee.com");
                           var camposFormulario = new FormUrlEncodedContent(new[]
                            {
                        new KeyValuePair<string, string>("ReuniaoId", msg.IdReuniao.ToString()),
                        new KeyValuePair<string, string>("PessoaId", App.UserCurrent.IdPessoa.ToString())
                        });
                           var resultado = await cliente.PostAsync("/Api/ReuniaoPesoaApi", camposFormulario);

                           if (resultado.IsSuccessStatusCode)
                           {
                               await DisplayAlert("Parabens!!!", "Parabens!!! você esta participando desta reunião.", "Ok");
                               await this.Listagem.GetReunioes(true);
                           }
                           else
                           {
                               await DisplayAlert("Erro", "Ocorreu um erro ao enviar o cadastro.Tente novamente mais tarde.", "Ok");
                           }
                       }
                   }
                   
               });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagemReuniao",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de reuniões. Por favor tente novamente mais tarde.", "Ok");
                });

            await this.Listagem.GetReunioes(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Reuniao>(this, "ReuniaoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagemReuniao");
        }
    }
}