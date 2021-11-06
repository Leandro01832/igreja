using AplicativoXamarin.models;
using AplicativoXamarin.Services;
using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.Join;
using AplicativoXamarin.Views.List;
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
    public partial class CelView : ContentPage
    {
        public ViewModelCell viewmodel { get; set; }
        Button botao;

        public CelView(Celula celula)
        {
            InitializeComponent();

            botao = new Button
            {
                Text = "Participar de uma celula",
                WidthRequest = 200,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            viewmodel = new ViewModelCell();
            viewmodel.celula = celula;

            BindingContext = viewmodel;            

            
            botao.Clicked += Botao_Clicked;
            
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<ViewModelCell>(this, "Geolocation", (msg) =>
            {
                Navigation.PushAsync(new GeolocationView());

            });

            MessagingCenter.Subscribe<ViewModelCell>(this, "ViewPeoples", (msg) =>
            {
                Navigation.PushAsync(new PeoplesCellView());
            });

            MessagingCenter.Subscribe<ViewModelCell>(this, "ViewMinistries", (msg) =>
            {
                Navigation.PushAsync(new MinistriesCellView());

            });

           

            

        }

        

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<ViewModelCell>(this, "ViewMinistries");
            MessagingCenter.Unsubscribe<ViewModelCell>(this, "ViewPeoples");
            MessagingCenter.Unsubscribe<ViewModelCell>(this, "Geolocation");
        }


        private async void Botao_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new EnterCell());
        }

        
    }
}