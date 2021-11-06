using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.List;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Confirm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmMeetingView : ContentPage
	{
        public ApiServices Api { get; set; }
        public JoinViewModel viewmodel { get; set; }

        public ConfirmMeetingView (Reuniao reuniao)
		{
			InitializeComponent ();
            viewmodel = new JoinViewModel();
            viewmodel.Reuniao = reuniao;
            BindingContext = viewmodel;
            
            Api = new ApiServices();
		}


        protected override  void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<ObservableCollection<Pessoa>>(this, "PessoasReuniao", async (msg) => {
                await Navigation.PushAsync(new PeopleMeetingView(msg));
            });

            MessagingCenter.Subscribe<Reuniao>(this, "ConfirmaReuniao",
              async (msg) =>
              {
                  if (await DisplayAlert("Confirmação", "Deseja realmente participar desta Reunião?", "SIM", "Cancelar"))
                  {
                      Api.ParticiparReuniao(msg);
                  }

              });

            MessagingCenter.Subscribe<Reuniao>(this, "SucessoParticiparReuniao",
             async (msg2) =>
              {
                await  DisplayAlert("Reunião", "Parabens!!! Você esta participando desta reunião." +
                      " \n Identificação da reunião: " + msg2.Id.ToString(), "ok");

                  await Navigation.PopAsync();
              });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaParticiparReuniao",
               async (msg3) =>
                {
                   await DisplayAlert("Falha", "Falha ao participar da reunião!", "ok");
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaListagemReuniao",
               async (msg3) =>
               {
                   await DisplayAlert("Falha", "Falha de listagem de pessoas da reunião!", "ok");
               });



        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Reuniao>(this, "ConfirmaReuniao");
            MessagingCenter.Unsubscribe<Reuniao>(this, "PessoasReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaParticiparReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagemReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "SucessoParticiparReuniao");
        }
    }
}