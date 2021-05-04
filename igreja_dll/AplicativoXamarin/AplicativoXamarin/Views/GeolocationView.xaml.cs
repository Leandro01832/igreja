using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.List;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeolocationView : ContentPage
	{

        public GeolocationView ()
		{
			InitializeComponent ();

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.GetGeolocation();
            foreach (Pin item in mainViewModel.Pins)
            {
                MyMap.Pins.Add(item);
            }

             Locator();

        }

        


        

        private async void Locator()
        {
            var main = MainViewModel.GetInstance();
           var position = await main.ExecuteLocator();
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.3)));
        }
    }
}