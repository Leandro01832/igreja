
using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AplicativoXamarin.ViewModels
{
   public class MainViewModel 
    {
        #region properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }
        public RegisterViewModel Register { get; set; }
        public LoginViewModel newLogin { get; set; }
        public UserViewModel UsuarioLogado { get; set; }
        public ViewModelCell CelulaUsuario { get; set; }


        #endregion



        #region constructs

        public MainViewModel()
        {
            instance = this;
            
            Pins = new ObservableCollection<Pin>();            
            Register = new RegisterViewModel();
            Menu = new ObservableCollection<MenuItemViewModel>();
            newLogin = new LoginViewModel();
            UsuarioLogado = new UserViewModel();
            CelulaUsuario = new ViewModelCell();

            LoadMenu();
        }       

        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Methods 

        internal void GetGeolocation()
        {
            var position1 = new Position(-23.536937, -46.779427);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Pin1",
                Address = "Local Pino 01"
            };
            Pins.Add(pin1);

            var position2 = new Position(-18.753730, -44.430406);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Pin2",
                Address = "Local Pino 02"
            };
            Pins.Add(pin2);

            var position3 = new Position(-12.971687, -38.475612);
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Pin3",
                Address = "Local Pino 03"
            };
            Pins.Add(pin3);
        }

        public void LoadUser(Pessoa user)
        {
            UsuarioLogado.Email = user.Email;
            UsuarioLogado.Foto = user.Foto;
            UsuarioLogado.Codigo = user.Codigo;
        }

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                icon = "people.png",
                Title = "Minha Celula",
                PageName = "CelView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_roxo.png",
                Title = "Meus Ministérios",
                PageName = "Ministerio"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_verde.png",
                Title = "Minhas Reuniões",
                PageName = "Reuniao"
            });           

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_mais_point.png",
                Title = "Participar de Ministérios",
                PageName = "JoinMinistryView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_mais_verde.png",
                Title = "Participar de Reuniões",
                PageName = "JoinMeetingView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_posts.png",
                Title = "Postagens da igreja",
                PageName = "MasterDetailPosts"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_saida_preto.png",
                Title = "Sair",
                PageName = "LogoutPage"
            });
        }

        #endregion


    }
}
