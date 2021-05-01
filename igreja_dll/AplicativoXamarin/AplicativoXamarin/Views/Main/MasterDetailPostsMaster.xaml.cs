using AplicativoXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoXamarin.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPostsMaster : ContentPage
    {
        public ListView ListView;
        

        public MasterDetailPostsMaster()
        {
            InitializeComponent();
            BindingContext = new MasterDetailPostsMasterViewModel();
            ListView = MenuItemsListView;
            
        }

        class MasterDetailPostsMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPostsMenuItem> MenuItems { get; set; }
            public ObservableCollection<PageViewDinamic> Items0 { get; set; }
            public ObservableCollection<PageViewDinamic> Items1 { get; set; }
            public ObservableCollection<PageViewDinamic> Items2 { get; set; }
            public ObservableCollection<PageViewDinamic> Items3 { get; set; }
            public ObservableCollection<PageViewDinamic> Items4 { get; set; }
            public ObservableCollection<PageViewDinamic> Items5 { get; set; }
            public ObservableCollection<PageViewDinamic> Items6 { get; set; }
            public ObservableCollection<PageViewDinamic> Items7 { get; set; }
            

            public MasterDetailPostsMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPostsMenuItem>(new[]
                {
                    new MasterDetailPostsMenuItem { Id = 0, Title = "Estudos biblicos - NT",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Estudos biblicos - NT",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                     
                                      ItemsSource = Items0
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 0, Title = "Estudos biblicos - VT",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Estudos biblicos - VT",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items1
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 1, Title = "Programações final de ano",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Programações final de ano",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items2
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 2, Title = "Retiro",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Retiro",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items3
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 3, Title = "Musicas Gospel",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Musicas Gospel",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items4
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 4, Title = "Pregações",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Pregações",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items5
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 5, Title = "Cantina",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Cantina",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items6
                                 } }
                            }
                        }
                },
                    new MasterDetailPostsMenuItem { Id = 6, Title = "Celula",
                        content = new ContentView
                        {
                            Content = new StackLayout
                            {
                                Padding = 10,
                                BackgroundColor = Color.Gray,
                                 Children = {
                                    new Label
                                    {
                                         Text = "Celula",
                                         FontSize = 24,
                                         HorizontalOptions = LayoutOptions.Center
                                    },
                                    new ListView
                                 {
                                      ItemsSource = Items7
                                 } }
                            }
                        }
                }
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }

    public class PageViewDinamic
    {
        public string Tag { get; set; }
        public string Category { get; set; }
    }
}