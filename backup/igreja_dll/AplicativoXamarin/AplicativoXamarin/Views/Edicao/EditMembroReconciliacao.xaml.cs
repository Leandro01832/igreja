using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Edicao
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditMembroReconciliacao : ContentPage
	{
        public ViewModelEdicao viewmodel { get; set; }

        public EditMembroReconciliacao()
        {
            InitializeComponent();
            viewmodel = new ViewModelEdicao();

            BindingContext = viewmodel;
        }
    }
}