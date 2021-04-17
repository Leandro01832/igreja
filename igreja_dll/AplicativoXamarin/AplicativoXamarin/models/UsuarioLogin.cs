using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoXamarin.models
{
   public class UsuarioLogin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
