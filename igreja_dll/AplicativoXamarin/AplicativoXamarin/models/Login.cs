using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoXamarin.models
{
   public class Login
    {
        public string email { get; private set; }
        public string senha { get; private set; }
        public bool lembrar { get; set; }

        public Login(string email, string senha, bool lembrar)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException(nameof(senha));

            this.email = email;
            this.senha = senha;
            this.lembrar = lembrar;
        }
    }
}
