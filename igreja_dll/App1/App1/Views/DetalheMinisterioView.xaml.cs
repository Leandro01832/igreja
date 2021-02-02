using Mobile.models;
using Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheMinisterioView : ContentPage
	{
		public DetalheMinisterioView (models.Ministerio msg)
		{
			InitializeComponent ();
            this.BindingContext = new DetalheMinisterioViewModel(msg);
        }
        

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Ministerio>(this, "Participar", (msg) =>
            {
                Navigation.PushAsync(new DetalheMinisterioView(msg));
            });

            MessagingCenter.Subscribe<Ministerio>(this, "Celulas", (msg) =>
            {
                Navigation.PushAsync(new DetalheMinisterioView(msg));
            });

            MessagingCenter.Subscribe<Ministerio>(this, "Pessoas", (msg) =>
            {
                Navigation.PushAsync(new DetalheMinisterioView(msg));
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