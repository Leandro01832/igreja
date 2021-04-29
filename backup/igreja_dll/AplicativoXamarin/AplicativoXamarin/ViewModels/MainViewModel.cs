
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

namespace AplicativoXamarin.ViewModels
{
   public class MainViewModel 
    {
        #region properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public RegisterViewModel Register { get; set; }
        public LoginViewModel newLogin { get; set; }
        public UserViewModel UsuarioLogado { get; set; }
        

        #endregion



        #region constructs

        public MainViewModel()
        {
            instance = this;
            Register = new RegisterViewModel();
            Menu = new ObservableCollection<MenuItemViewModel>();
            newLogin = new LoginViewModel();
            UsuarioLogado = new UserViewModel();
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
                PageName = "Celula"
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
