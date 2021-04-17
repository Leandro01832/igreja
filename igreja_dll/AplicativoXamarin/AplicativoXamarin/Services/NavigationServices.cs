using AplicativoXamarin.models;
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


                default: break;
            }
        }
    }
}
