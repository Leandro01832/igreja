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
                      " \n Identificação da reunião: " + msg2.IdReuniao.ToString(), "ok");

                await  Navigation.PushAsync(new ListMeetingView());
              });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaParticiparReuniao",
               async (msg3) =>
                {
                   await DisplayAlert("Falha", "Falha ao participar da reunião!", "ok");
                });

            

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Reuniao>(this, "ConfirmaReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaParticiparReuniao");
            MessagingCenter.Unsubscribe<Exception>(this, "SucessoParticiparReuniao");
        }
    }
}