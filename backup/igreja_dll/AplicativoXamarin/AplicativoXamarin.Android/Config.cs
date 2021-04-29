using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AplicativoXamarin.Droid;
using AplicativoXamarin.models.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(Config))]
namespace AplicativoXamarin.Droid
{
   public class Config : IConfig
    {
        private string directoryDB;
        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }

                return directoryDB;
            }
        }
        
    }
}