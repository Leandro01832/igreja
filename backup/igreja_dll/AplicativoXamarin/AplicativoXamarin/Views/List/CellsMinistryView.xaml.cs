﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.List
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CellsMinistryView : ContentPage
	{
		public CellsMinistryView (System.Collections.ObjectModel.ObservableCollection<models.Celula> celulasDoMinisterio)
		{
			InitializeComponent ();
		}
	}
}