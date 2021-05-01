using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogoutMeetingView : ContentPage
	{
        public LogoutViewModel viewmodel { get; set; }
        public ApiServices Api { get; set; }

        public LogoutMeetingView (Reuniao reuniao)
		{
			InitializeComponent ();
            viewmodel = new LogoutViewModel();
            viewmodel.Reuniao = reuniao;
            BindingContext = viewmodel;
            Api = new ApiServices();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Reuniao>(this, "SairReuniao",
               async (msg) => {
                    if(await DisplayAlert("Confirmação", "Deseja realmente sair desta reunião?", "SIM", "Cancelar"))
                    Api.SairReuniao(msg);
                });

            MessagingCenter.Subscribe<Reuniao>(this, "SucessoSairReuniao",
              async  (msg) => {
                  await  DisplayAlert("Confirmação", "Você agora não esta mais nesta reuniao", "Ok");
                  await Navigation.PushAsync(new ListMeetingView());
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaSairReuniao",
              async (msg) => {
                  await DisplayAlert("Erro", "Aconteceu um erro." + msg.Message, "Ok");
              });

           
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Reuniao>(this, "SairReuniao");
            MessagingCenter.Unsubscribe<Reuniao>(this, "SucessoSairReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaSairReuniao");
        }
    }
}