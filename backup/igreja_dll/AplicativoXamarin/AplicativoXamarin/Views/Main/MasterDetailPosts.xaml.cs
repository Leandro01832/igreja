using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPosts : MasterDetailPage
    {
        private MasterDetailPostsDetail detail;

        public MasterDetailPosts()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            detail = MasterDetailPostsDetail.GetInstance();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPostsMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            detail.Content = item.content;

           // Detail = new NavigationPage(page);
            Detail = new NavigationPage(detail);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        

        


    }
}