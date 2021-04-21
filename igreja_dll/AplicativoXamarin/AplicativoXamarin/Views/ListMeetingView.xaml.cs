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
	public partial class ListMeetingView : ContentPage
	{
        public ListagemViewModel Listagem { get; set; }

        public ListMeetingView ()
		{
			InitializeComponent ();
            Listagem = new ListagemViewModel();
            BindingContext = Listagem;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Reuniao>(this, "ReuniaoSelecionado",
               (msg) =>
               {
                   Navigation.PushAsync(new DetailMeetingView(msg));
               });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de reuniões. Por favor tente novamente mais tarde.", "Ok");
                });

            await this.Listagem.GetReunioes();
        }
    }
}