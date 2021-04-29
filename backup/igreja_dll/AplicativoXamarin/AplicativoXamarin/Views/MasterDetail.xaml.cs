using AplicativoXamarin.models;
using AplicativoXamarin.ViewModels;
using Newtonsoft.Json;
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
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail(Pessoa Usuario)
        {
            InitializeComponent();
            this.user = Usuario;
            //  user = Usuario;

        }

        public Pessoa user { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            App.Navigator = Navigator;
        }
    }

    
}