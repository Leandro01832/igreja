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
    public partial class EnterCell : ContentPage
    {
        public ViewModelCell viewmodel { get; set; }

        public EnterCell()
        {
            InitializeComponent();
            viewmodel = new ViewModelCell();
            BindingContext = viewmodel;
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Celula>(this, "CelulaSelecionado",
              async  (msg) =>
                {
                   await Navigation.PushAsync(new ConfirmEnterCell(msg));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
              async  (msg) =>
                {
                    await DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de celulas. Por favor tente novamente mais tarde.", "Ok");
                });

           await  this.viewmodel.GetCelulas();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Ministerio>(this, "CelulaSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}