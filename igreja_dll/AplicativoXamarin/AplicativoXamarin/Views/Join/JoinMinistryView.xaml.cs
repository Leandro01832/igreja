using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.Confirm;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Join
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JoinMinistryView : ContentPage
	{
        public ListagemViewModel Listagem { get; set; }
        

        public JoinMinistryView ()
		{            
			InitializeComponent ();
            Listagem = new ListagemViewModel();
            BindingContext = this.Listagem;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "MinisterioSelecionado",
               async (msg) =>
                {
                    await Navigation.PushAsync(new ConfirmMinistryView(msg));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagemMinisterio",
                (msg) =>
                {
                    DisplayAlert("Erro", @"Ocorreu um erro ao obter a listagem de ministérios.
                    Por favor tente novamente mais tarde.", "Ok");
                });

            await this.Listagem.GetMinisterios(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "MinisterioSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagemMinisterio");
        }
    }
}