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

namespace AplicativoXamarin.Views.Confirm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmMinistryView : ContentPage
	{
        public ApiServices Api { get; set; }
        public JoinViewModel viewmodel { get; set; }

        public ConfirmMinistryView (Ministerio ministerio)
		{
			InitializeComponent ();
            viewmodel = new JoinViewModel();
            viewmodel.Ministerio = ministerio;
            BindingContext = viewmodel;

            Api = new ApiServices();
		}

        protected  override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "ConfirmaMinisterio",
               async (msg) =>
               {
                   if (await DisplayAlert("Confirmação", "Deseja realmente participar deste Ministério?", "SIM", "Cancelar"))
                   {
                       Api.ParticiparMinisterio(msg);                       
                   }
               });


            MessagingCenter.Subscribe<Ministerio>(this, "SucessoParticiparMinisterio",
             async (msg2) =>
               {
               await DisplayAlert("Ministerio", "Parabens!!! Você esta participando deste ministério." +
                       " \n Identificação do ministério: " + msg2.IdMinisterio.ToString(), "ok");

                   await Navigation.PushAsync(new MinistryListView());
               });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaParticiparMinisterio",
               async (msg3) =>
                {
                   await DisplayAlert("Falha", "Falha ao participar do ministério!", "ok");
                });

           

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "ConfirmaMinisterio");
            MessagingCenter.Unsubscribe<Exception>(this, "SucessoParticiparMinisterio");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaParticiparMinisterio");
        }
    }
}