using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoXamarin.Services
{
    public class NavigationServices
    {
        public async Task Navigate(string pagename)
        {
            App.Master.IsPresented = false;

            switch (pagename)
            {
                case "Celula":
                    await App.Navigator.PushAsync(new CelView());

                    break;

                case "Ministerio":
                    await App.Navigator.PushAsync(new MinistryView());

                    break;

                case "Reuniao":
                    await App.Navigator.PushAsync(new MeetingView());

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

        public void SetMainPage(Pessoa user)
        {
            App.UserCurrent = user;
            App.Current.MainPage = new MasterDetail(user);
        }

       
    }
}
