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
	public partial class LogoutMinistryView : ContentPage
	{
        public LogoutViewModel viewmodel { get; set; }
        public ApiServices Api { get; set; }

        public LogoutMinistryView (Ministerio ministerio)
		{
			InitializeComponent ();
            viewmodel = new LogoutViewModel();
            viewmodel.Ministerio = ministerio;
            BindingContext = viewmodel;

            Api = new ApiServices();           
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "SairMinisterio",
               async (msg) =>
               {
                   if (await DisplayAlert("Confirmação", "Deseja realmente participar deste Ministério?", "SIM", "Cancelar"))
                   {
                       Api.SairMinisterio(msg);
                   }
               });


            MessagingCenter.Subscribe<Ministerio>(this, "SucessoSairMinisterio",
             async (msg2) =>
             {
                 await DisplayAlert("Ministerio", " Você não esta mais participando deste ministério." +
                         " \n Identificação do ministério: " + msg2.IdMinisterio.ToString(), "ok");

                 await Navigation.PushAsync(new MinistryListView());
             });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaSairMinisterio",
               async (msg3) =>
               {
                   await DisplayAlert("Falha", "Falha ao participar do ministério!", "ok");
               });

            await viewmodel.GetPessoas(true);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "SairMinisterio");
            MessagingCenter.Unsubscribe<Exception>(this, "SucessoSairMinisterio");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaSairMinisterio");
        }
    }
}