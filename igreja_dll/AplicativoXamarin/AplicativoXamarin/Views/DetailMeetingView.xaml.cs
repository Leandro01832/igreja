using AplicativoXamarin.models;
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
	public partial class DetailMeetingView : ContentPage
	{
		public DetailMeetingView (Reuniao reuniao)
		{
			InitializeComponent ();
            BindingContext = reuniao;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Reuniao>(this, "NaoParticipar",
               (msg) =>
               {
                   Navigation.PushAsync(new DetailMeetingView(msg));
               });

           
        }
    }
}