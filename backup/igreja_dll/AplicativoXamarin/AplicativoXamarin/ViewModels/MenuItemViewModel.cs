using AplicativoXamarin.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace AplicativoXamarin.ViewModels
{
   public class MenuItemViewModel
    {
        private NavigationServices navigationServices;

        public MenuItemViewModel()
        {
            navigationServices = new NavigationServices();
            
        }

        #region Properties
        public string icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private async void Navigate()
        {
           await navigationServices.Navigate(PageName);
        } 
        #endregion
    }
}
