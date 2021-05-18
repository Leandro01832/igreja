﻿using AplicativoXamarin.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewLoginView : ContentPage
	{
        

        public ViewLoginView ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin",
            async (exc) =>
            {
                await DisplayAlert("Login", @"Falha ao efetuar o login. 
                Verifique os dados e tente novamente mais tarde.", "Ok");
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
        }
    }
}