using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.List
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeoplesCellView : ContentPage
	{
        public ViewModelCell viewmodel { get; set; }

        public PeoplesCellView ()
		{
			InitializeComponent ();
            viewmodel = new ViewModelCell();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewmodel.GetPessoas();
        }
    }
}