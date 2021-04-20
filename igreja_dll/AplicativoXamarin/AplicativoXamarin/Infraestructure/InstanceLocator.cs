using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoXamarin.Infraestructure
{
   public class InstanceLocator
    {
        public MainViewModel Main { get; set; }


        public InstanceLocator()
        {
            //var data = new DataAccess();
            //var user = data.First();
            //if (user != null)
            //{
            //    App.UserCurrent = user;
            //}
            Main = new MainViewModel();
        }
    }
}
