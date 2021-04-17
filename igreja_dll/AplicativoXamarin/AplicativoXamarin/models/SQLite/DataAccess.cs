using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AplicativoXamarin.models.Interface;
using AplicativoXamarin.models;

namespace AplicativoXamarin.models.SQLite
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(System.IO.Path.Combine(config.DirectoryDB, "Database.db3"), false);
            connection.CreateTable<UsuarioLogin>();
        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }

        public UsuarioLogin First()
        {
            return connection.Table<UsuarioLogin>().FirstOrDefault();
        }

        public List<UsuarioLogin> GetList()
        {
            return connection.Table<UsuarioLogin>().ToList();
        }


        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
