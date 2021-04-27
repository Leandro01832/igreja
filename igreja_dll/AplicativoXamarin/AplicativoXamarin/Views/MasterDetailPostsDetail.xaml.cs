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
    public partial class MasterDetailPostsDetail : ContentPage
    {
        private static MasterDetailPostsDetail instance;

        public MasterDetailPostsDetail()
        {
            instance = this;
            InitializeComponent();
        }

        public static MasterDetailPostsDetail GetInstance()
        {
            if (instance == null)
            {
                instance = new MasterDetailPostsDetail();
            }

            return instance;
        }
    }
}