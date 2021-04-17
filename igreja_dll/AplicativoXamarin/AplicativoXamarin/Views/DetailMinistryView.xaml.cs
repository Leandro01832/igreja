
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
	public partial class DetailMinistryView : ContentPage
	{
		public DetailMinistryView (Ministerio ministerio)
		{
			InitializeComponent ();
            BindingContext = ministerio;

        }

         

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "Participar", (msg) =>
            {
                Navigation.PushAsync(new DetailMinistryView(msg));
            });

            MessagingCenter.Subscribe<Ministerio>(this, "Celulas", (msg) =>
            {
                Navigation.PushAsync(new DetailMinistryView(msg));
            });

            MessagingCenter.Subscribe<Ministerio>(this, "Pessoas", (msg) =>
            {
                Navigation.PushAsync(new DetailMinistryView(msg));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Ministerio>(this, "Participar");
            MessagingCenter.Unsubscribe<Ministerio>(this, "Celulas");
            MessagingCenter.Unsubscribe<Ministerio>(this, "Pessoas");
        }
    }
}