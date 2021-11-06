using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AplicativoXamarin.iOS;
using AplicativoXamarin.models.Interface;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Config))]
namespace AplicativoXamarin.iOS
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
                    var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = System.IO.Path.Combine(directorio, "..", "Library");
                }

                return directoryDB;
            }
        }
        
    }
}