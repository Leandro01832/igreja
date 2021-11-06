using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.List
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
            MessagingCenter.Subscribe<Ministerio>(this, "MinisterioSelecionadoUsuario",
               async (msg) =>
                {
                   await Navigation.PushAsync(new LogoutMinistryView(msg));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
               async (msg) =>
                {
                   await DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de ministérios. Por favor tente novamente mais tarde.", "Ok");
                });

            await this.ViewModel.GetMinisterios(false);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "MinisterioSelecionadoUsuario");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}