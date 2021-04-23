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
