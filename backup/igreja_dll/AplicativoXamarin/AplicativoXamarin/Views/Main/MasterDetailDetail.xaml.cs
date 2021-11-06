using AplicativoXamarin.ViewModels;
using AplicativoXamarin.Views.Edicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailDetail : ContentPage
    {

        public MasterDetailDetail()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<MainViewModel>(this, "Update", (msg) => {
                Navigation.PushAsync(new ChooseClass());
            });

            MessagingCenter.Subscribe<MainViewModel>(this, "SemCamera", (msg) => {
                DisplayAlert("Erro", "Você não tem camera.", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainViewModel>(this, "Update");
        }

    }
}