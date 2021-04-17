
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicativoXamarin.ViewModels
{
   public class MainViewModel
    {
        #region properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public LoginViewModel newLogin { get; set; }
        #endregion



        #region constructs

        public MainViewModel()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();
            newLogin = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                icon = "people.png",
                Title = "Celula",
                PageName = "Celula"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_roxo.png",
                Title = "Ministérios",
                PageName = "Ministerio"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_verde.png",
                Title = "Reuniões",
                PageName = "Reuniao"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_action_exit.png",
                Title = "Sair",
                PageName = "LogoutPage"
            });
        }

        #endregion


    }
}
