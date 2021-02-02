using Mobile.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(
                async () =>
                {
                    try
                    {
                        var loginService = new LoginServices();
                        var resultado = await loginService.FazerLogin(new Login(usuario, senha));

                        if (resultado.IsSuccessStatusCode)
                        {
                            var conteudoResultado = await resultado.Content.ReadAsStringAsync();
                            var resultadoLogin =
                            JsonConvert.DeserializeObject<LoginResult>(conteudoResultado);

                            MessagingCenter.Send<Pessoa>(resultadoLogin.usuario,
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
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
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
