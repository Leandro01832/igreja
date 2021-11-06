using AplicativoXamarin.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.List
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeopleMinistry : ContentPage
	{
		public PeopleMinistry (ObservableCollection<Pessoa> pessoasDoMinisterio)
		{
			InitializeComponent ();
            PessoasDoMinisterio = pessoasDoMinisterio;
            BindingContext = this;
        }

        public ObservableCollection<Pessoa> PessoasDoMinisterio { get; }
    }
}