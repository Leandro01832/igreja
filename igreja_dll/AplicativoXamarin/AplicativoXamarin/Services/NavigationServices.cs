using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views;
using AplicativoXamarin.Views.Join;
using AplicativoXamarin.Views.List;
using AplicativoXamarin.Views.Main;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoXamarin.Services
{
    public class NavigationServices
    {
        public ApiServices Api { get; set; }

        public async Task Navigate(string pagename)
        {
            App.Master.IsPresented = false;
            Api = new ApiServices();

            switch (pagename)
            {
                case "CelView":
                    var main = MainViewModel.GetInstance();
                    Celula cel = await main.GetCelula();
                    await App.Navigator.PushAsync(new CelView(cel));

                    break;

                case "Ministerio":
                    await App.Navigator.PushAsync(new MinistryListView());

                    break;

                case "Reuniao":
                    await App.Navigator.PushAsync(new ListMeetingView());

                    break;

                case "JoinMinistryView":
                    await App.Navigator.PushAsync(new JoinMinistryView());

                    break;

                case "JoinMeetingView":
                    await App.Navigator.PushAsync(new JoinMeetingView());

                    break;

                case "MasterDetailPosts":
                    await App.Navigator.PushAsync(new PageTeste());

                    break;

                case "LogoutPage":
                    Logout();

                    break;


                default: break;
            }
        }

        private void Logout()
        {
            var data = new DataAccess();
            
                var user = data.First();
                user.Lembrar_me = false;
                data.Update(user); 

            App.Current.MainPage = new ViewLoginView();
        }

        

       
    }
}
