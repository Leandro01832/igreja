﻿using AplicativoXamarin.models.Interface;
using AplicativoXamarin.UWP;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(Config))]
namespace AplicativoXamarin.UWP
{
   public class Config : IConfig
    {
        
        private string directoryDB;
        private ISQLitePlatform platform;
        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = ApplicationData.Current.LocalFolder.Path;
                }

                return directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }

                return platform;
            }
        }
    }
}
