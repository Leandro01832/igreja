using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;
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

            Api = new ApiServices();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Reuniao>(this, "SairReuniao",
               async (msg) => {
                    if(await DisplayAlert("Confirmação", "Deseja realmente sair desta reunião", "SIM", "Cancelar"))
                    Api.SairReuniao(msg);
                });

            MessagingCenter.Subscribe<Reuniao>(this, "SucessoSairReuniao",
              async  (msg) => {
                  await  DisplayAlert("Confirmação", "Você agora não esta mais nesta reuniao", "Ok");
                  await Navigation.PushAsync(new ListMeetingView());
                });

            MessagingCenter.Subscribe<Reuniao>(this, "FalhaSairReuniao",
              async (msg) => {
                  await DisplayAlert("Erro", "Aconteceu um erro para sair da reunião", "Ok");
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