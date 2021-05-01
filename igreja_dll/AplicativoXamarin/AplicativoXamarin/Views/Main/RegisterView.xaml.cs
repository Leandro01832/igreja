using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public ApiServices Api { get; set; }
        public RegisterViewModel viewmodel { get; set; }

        public RegisterView()
        {
            InitializeComponent();
            viewmodel = new RegisterViewModel();
           // BindingContext = viewmodel;
            Api = new ApiServices();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<RegisterViewModel>(this, "Cadastrar",
              async (msg) =>
              {                  
                  if (!msg.Crianca && !msg.MembroAclamacao && !msg.MembroBatismo &&
                  !msg.MembroReconciliacao && !msg.MembroTransferencia && !msg.Visitante)
                  { await DisplayAlert("Erro", "Marque quem você é", "Ok"); return; }
                  if (string.IsNullOrEmpty(msg.Email))
                  { await DisplayAlert("Erro", "Digite seu E-mail", "Ok"); return; }
                  if (string.IsNullOrEmpty(msg.Password))
                  { await DisplayAlert("Erro", "Digite sua senha", "Ok"); return; }
                  
                  await Api.CadastrarPessoa(msg);
                  
              });

            MessagingCenter.Subscribe<RegisterViewModel>(this, "SemCamera",
              async (msg) =>
              {
                 await  DisplayAlert("Sem Camera", "Camera não disponível", "Ok");
              });

            MessagingCenter.Subscribe<Pessoa>(this, "Cadastrado",
              async (msg) =>
              {
                  var main = MainViewModel.GetInstance();
                  if(main.Register.file != null)
                  {
                    var  response2 = await Api.SetPhoto(msg.IdPessoa, main.Register.file.GetStream());
                      if (response2)
                      await DisplayAlert("Confimação", "Você foi cadastrado com sucesso!!!", "Ok");
                      else
                      await DisplayAlert("Confimação", " cadastrado com sucesso mas não foi enviado a foto!!!", "Ok");
                      main.Register.file.Dispose();
                  }
                  else
                  {
                      await DisplayAlert("Confimação", " cadastrado com sucesso mas não foi enviado a foto!!!", "Ok");
                  }
                  App.Current.MainPage = new ViewLoginView();
              });

            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaCadastro",
              async (msg) =>
              {
                  await DisplayAlert("Erro!!!", "Ocorreu um erro no cadastro." + msg.Message, "Ok");
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