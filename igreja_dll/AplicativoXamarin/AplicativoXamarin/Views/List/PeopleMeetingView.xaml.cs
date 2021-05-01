using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AplicativoXamarin.models;

namespace AplicativoXamarin.Views.List
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeopleMeetingView : ContentPage
	{
		public PeopleMeetingView (ObservableCollection<Pessoa> pessoasDaReuniao)
		{
			InitializeComponent ();
		}
	}
}