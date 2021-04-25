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
    public partial class RegisterView : ContentPage
    {
        public ApiServices Api { get; set; }

        public RegisterView()
        {
            InitializeComponent();
            Api = new ApiServices();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<RegisterViewModel>(this, "Cadastrar",
              async (msg) =>
              {
                await Api.CadastrarPessoa(msg);
              });

            MessagingCenter.Subscribe<RegisterViewModel>(this, "Cadastrado",
              async (msg) =>
              {
                  await DisplayAlert("Confimação", "Você foi cadastrado com sucesso!!!.", "Ok");
                  await Navigation.PushAsync(new ViewLoginView());
              });

            MessagingCenter.Subscribe<RegisterViewModel>(this, "FalhaCadastro",
              async (msg) =>
              {
                  await DisplayAlert("Erro!!!", "Ocorreu um erro no cadastro.", "Ok");
              });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<RegisterViewModel>(this, "Cadastrar");
            MessagingCenter.Unsubscribe<RegisterViewModel>(this, "Cadastrado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaCadastro");
        }
    }
}