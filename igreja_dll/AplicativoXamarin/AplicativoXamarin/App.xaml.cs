using AplicativoXamarin.Views;
using AplicativoXamarin.models;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AplicativoXamarin
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterDetailPage Master { get; internal set; }
        public static UsuarioLogin CurrentUser { get; internal set; }

        public App()
        {
            InitializeComponent();

            MainPage = new ViewLoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Pessoa>(this, "SucessoLogin",
                (usuario) =>
                {
                    //MainPage = new NavigationPage(new ListagemView());
                    MainPage = new MasterDetail(usuario);
                });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

       
    }
}
