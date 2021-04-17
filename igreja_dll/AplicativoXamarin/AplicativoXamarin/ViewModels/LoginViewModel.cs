using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace AplicativoXamarin.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand EntrarCommand { get; private set; }
        public DataAccess data { get; set; }

        public void Logout()
        {
            //  App.CurrentUser.
        }

        public LoginViewModel()
        {
            data = new DataAccess();
            Lembrar_me = true;

            EntrarCommand = new Command(
                async () =>
                {
                    try
                    {
                        var loginService = new LoginServices();
                        IsRunning = true;
                        var resultado = await loginService.FazerLogin(new Login(usuario, senha, Lembrar_me));
                        IsRunning = false;

                        if (resultado.IsSuccessStatusCode)
                        {
                            var conteudoResultado = await resultado.Content.ReadAsStringAsync();
                            var resultadoLogin =
                            JsonConvert.DeserializeObject<Pessoa>(conteudoResultado);
                            App.CurrentUser = new UsuarioLogin { Email = usuario, Password = senha };
                            MessagingCenter.Send<Pessoa>(resultadoLogin,
                           "SucessoLogin");
                        }

                        else
                            MessagingCenter.Send<LoginException>(new LoginException(), "FalhaLogin");


                    }
                    catch (Exception exc)
                    {
                        MessagingCenter.Send<LoginException>(new
                            LoginException("Erro de comunicação com o servidor.", exc), "FalhaLogin");
                    }
                },
            () =>
            {
                return !string.IsNullOrEmpty(usuario)
                    && !string.IsNullOrEmpty(senha);
            });
        }

        private string usuario;
        public string Usuario
        {
            get
            {
                var modelo = data.First();
                if (modelo == null)
                {
                    return "";
                }
                return modelo.Email;
            }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get {
                var modelo = data.First();
                if (modelo == null)
                {
                    return "";
                }
                return  modelo.Password;
            }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private bool lembrar_me;
        public bool Lembrar_me
        {
            get { return lembrar_me; }
            set
            {
                lembrar_me = value;
               // ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private bool isRunning;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRunning
        {
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsRunning"));
                    }
                }
            }
            get
            {
                return isRunning;
            }
        }
    }


   

    public class LoginException : Exception
    {
        public LoginException() : base() { }

        public LoginException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
