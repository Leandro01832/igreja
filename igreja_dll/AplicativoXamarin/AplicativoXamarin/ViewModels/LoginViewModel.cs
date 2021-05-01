using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using AplicativoXamarin.Views;
using GalaSoft.MvvmLight.Command;
using AplicativoXamarin.Views.Main;

namespace AplicativoXamarin.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand EntrarCommand { get; private set; }
        public ICommand FazerCadastroCommand { get { return new RelayCommand(Register); } }

        private void Register()
        {
             App.Current.MainPage = new RegisterView();
        }

        public LoginViewModel()
        {
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
                            resultadoLogin.password = Senha;
                            

                            var data = new DataAccess();
                            if (Lembrar_me && data.First() == null)
                            {
                                var p = new Pessoa
                                {
                                    celula_ = resultadoLogin.celula_,
                                    Codigo = resultadoLogin.Codigo,
                                    Img = resultadoLogin.Img,
                                    IdPessoa = resultadoLogin.IdPessoa,
                                    Falta = resultadoLogin.Falta,
                                    Email = resultadoLogin.Email,
                                    Lembrar_me = Lembrar_me,
                                    NomePessoa = resultadoLogin.NomePessoa,
                                    password = senha
                                };
                                data.Insert(p);
                                App.UserCurrent = p;
                            }
                            else if (Lembrar_me && data.First() != null)
                            {
                                if (data.First().Email != usuario || 
                                data.First().password != senha ||
                                data.First().Lembrar_me != Lembrar_me)
                                {
                                    var user = new Pessoa
                                    {
                                        Id = data.First().Id,
                                        celula_ = resultadoLogin.celula_,
                                        Codigo = resultadoLogin.Codigo,
                                        Img = resultadoLogin.Img,
                                        IdPessoa = resultadoLogin.IdPessoa,
                                        Falta = resultadoLogin.Falta,
                                        Email = resultadoLogin.Email,
                                        Lembrar_me = lembrar_me,
                                        NomePessoa = resultadoLogin.NomePessoa,
                                        password = senha
                                    };
                                    data.Update(user);
                                    App.UserCurrent = user;
                                }
                            }                                              

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
                }
                ,
            () =>
            {
                return !string.IsNullOrEmpty(usuario)
                    && !string.IsNullOrEmpty(senha);
            }
            );
        }

        private string usuario;
        public string Usuario
        {
            get
            {
                var data = new DataAccess();
                
                    var modelo = data.First();
                    if (modelo == null || !modelo.Lembrar_me)
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
                var data = new DataAccess();
                
                    var modelo = data.First();
                    if (modelo == null || !modelo.Lembrar_me)
                    {
                        return "";
                    }
                    return modelo.password;
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
