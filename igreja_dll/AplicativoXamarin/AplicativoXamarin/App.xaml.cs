using AplicativoXamarin.Views;
using AplicativoXamarin.models;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AplicativoXamarin.Infraestructure;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AplicativoXamarin
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static MasterDetailPage Master { get; internal set; }
        public static Pessoa UserCurrent { get; internal set; }
        

        public App()
        {
            InitializeComponent();
           // MainPage = new TabbedPageView();
            var data = new DataAccess();

            var user = data.First();
            if (user != null && user.Lembrar_me)
            {
                var main = MainViewModel.GetInstance();
                main.LoadUser(user);
                App.UserCurrent = user;
                MainPage = new MasterDetail(user);
            }
            else
            {
                MainPage = new ViewLoginView();
            }
        }

        

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Pessoa>(this, "SucessoLogin",
                (usuario) =>
                {
                    var main = MainViewModel.GetInstance();
                    main.LoadUser(usuario);

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
