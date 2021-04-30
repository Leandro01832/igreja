using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CelView : ContentPage
    {

        public CelView(Celula celula)
        {
            InitializeComponent();
                        
            var botao = new Button
            {
                Text = "Participar de uma celula",
                WidthRequest = 200,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            botao.Clicked += Botao_Clicked;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.CelulaUsuario.Celula = celula;
            //mainViewModel.GetGeolocation();
            //foreach (Pin item in mainViewModel.Pins)
            //{
            //    MyMap.Pins.Add(item);
            //}
           // Locator();

            if (mainViewModel.CelulaUsuario.Celula == null)
            {
                this.Content = new ContentView
                {
                    Content = new StackLayout
                    {
                        Padding = 20,
                        Spacing = 20,
                        Children =
                        {
                            new Label
                            {
                                Text = "Você ainda não tem uma celula.",
                                 FontSize = 24,
                                 HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center
                            },
                            botao
                        }
                    }
                };
            }
        }
        

        private async void Botao_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new EnterCell());
        }

        //private async void Locator()
        //{
        //    var locator = CrossGeolocator.Current;
        //    locator.DesiredAccuracy = 50;

        //    var location = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
        //    var position = new Position(location.Latitude, location.Longitude);
        //    MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(.3)));
        //}
    }
}