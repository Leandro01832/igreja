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
	public partial class ConfirmEnterCell : ContentPage
	{
		public ConfirmEnterCell (Celula celula)
		{
			InitializeComponent ();

            BindingContext = celula;
		}
	}
}