﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PeopleMinistry : ContentPage
	{
		public PeopleMinistry (System.Collections.ObjectModel.ObservableCollection<models.Pessoa> pessoasDoMinisterio)
		{
			InitializeComponent ();
		}
	}
}