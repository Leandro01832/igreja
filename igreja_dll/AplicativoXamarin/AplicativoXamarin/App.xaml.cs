using AplicativoXamarin.Views;
using AplicativoXamarin.models;
using AplicativoXamarin.Views.Main;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AplicativoXamarin.Infraestructure;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
using AplicativoXamarin.Services;

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

            var data = new DataAccess();

            var user = data.First();
            if (user != null && user.Lembrar_me)
            {
                var main = MainViewModel.GetInstance();
                main.LoadUser(user);
                
                App.UserCurrent = user;
                MainPage = new Views.Main.MasterDetail(user);
            }
            else
            {
                MainPage = new ViewLoginView();
            }
        }

        

        protected  override void OnStart()
        {
            var main = MainViewModel.GetInstance();
            
            MessagingCenter.Subscribe<Pessoa>(this, "SucessoLogin",
                (usuario) =>
                {
                    
                    main.LoadUser(usuario);

                    MainPage = new Views.Main.MasterDetail(usuario);
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
