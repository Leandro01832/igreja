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

namespace AplicativoXamarin.Views.Confirm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmEnterCell : ContentPage
	{
        public ApiServices Api { get; set; }
        public ViewModelCell viewmodel { get; set; }

        public ConfirmEnterCell (Celula celula)
		{
			InitializeComponent ();
            viewmodel = new ViewModelCell();
            BindingContext = viewmodel;
            Api = new ApiServices();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Celula>(this, "ConfirmJoinCell", (msg) =>
            {
                Api.EntrarCelula(msg);
            });

            MessagingCenter.Subscribe<Celula>(this, "SucessoEntrarCelula",
             async (msg2) =>
             {
                 await DisplayAlert("Celula", "Parabens!!! Você esta participando desta celula." +
                       " \n Identificação da reunião: " + msg2.IdCelula.ToString(), "ok");

                 App.Current.MainPage = new CelView(msg2);
             });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaEntrarCelula",
               async (msg3) =>
               {
                   await DisplayAlert("Falha", "Falha ao participar da celula!", "ok");
               });
        }
    }
}