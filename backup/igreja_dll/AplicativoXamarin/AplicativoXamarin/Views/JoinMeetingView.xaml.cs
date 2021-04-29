using AplicativoXamarin.models;
using AplicativoXamarin.Services;
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

        public ApiServices Api { get; set; }

        public JoinMeetingView()
        {
            InitializeComponent();
            Listagem = new ListagemViewModel();
            BindingContext = Listagem;
            Api = new ApiServices();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Reuniao>(this, "ReuniaoSelecionado",
              async (msg) =>
               {
                   await Navigation.PushAsync(new ConfirmMeetingView(msg));
               });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagemReuniao",
               async (msg) =>
                {
                   await DisplayAlert("Erro", @"Ocorreu um erro ao obter a listagem de reuniões.
                    Por favor tente novamente mais tarde.", "Ok");
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