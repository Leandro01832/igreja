using AplicativoXamarin.models;
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
	public partial class MinistryListView : ContentPage
	{
        private ListagemViewModel ViewModel;

        public MinistryListView ()
		{
			InitializeComponent ();
             this.ViewModel = new ListagemViewModel();
               BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "MinisterioSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetailMinistryView(msg));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de ministérios. Por favor tente novamente mais tarde.", "Ok");
                });

            await this.ViewModel.GetMinisterios();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "MinisterioSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}