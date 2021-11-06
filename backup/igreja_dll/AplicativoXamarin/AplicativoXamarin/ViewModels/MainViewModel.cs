
using AplicativoXamarin.models;
using AplicativoXamarin.models.SQLite;
using AplicativoXamarin.Services;
using AplicativoXamarin.Views.Edicao;
using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace AplicativoXamarin.ViewModels
{
   public class MainViewModel : BaseViewModel
    {
        #region properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }
        public RegisterViewModel Register { get; set; }
        public LoginViewModel newLogin { get; set; }
        public ViewModelEdicao Editar { get; set; }
        public UserViewModel UsuarioLogado { get; set; }
        public ApiServices Api { get; set; }

        public MediaFile file { get; set; }

        public ICommand UpdateData { get; set; }
        public ICommand UpdatePicture { get; set; }
        public ICommand SavePicture { get; set; }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }

        private bool visibleButton;
        public bool VisibleButton
        {
            get { return visibleButton; }
            set
            {
                visibleButton = value;
                OnPropertyChanged();
            }
        }


        #endregion



        #region constructs

        public MainViewModel()
        {
            VisibleButton = false;
            

            instance = this;
            Api = new ApiServices();
            Pins = new ObservableCollection<Pin>();            
            Register = new RegisterViewModel();
            Menu = new ObservableCollection<MenuItemViewModel>();
            newLogin = new LoginViewModel();
            UsuarioLogado = new UserViewModel();
            Editar = new ViewModelEdicao();

            UpdateData = new Command(() =>
            {
                MessagingCenter.Send<MainViewModel>(this, "Update");
            });

            SavePicture = new Command(async () =>
            {
                Aguarde = true;
                await  Api.SetPhoto(App.UserCurrent.IdPessoa, file.GetStream());
                Aguarde = false;
                VisibleButton = false;
            });

            UpdatePicture = new Command( async () =>
            {
                Aguarde = true;
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    MessagingCenter.Send<MainViewModel>(this, "SemCamera");
                    return;
                }

                file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Photos",
                    Name = "Pessoa.jpg"
                });

                if (file != null)
                {
                    VisibleButton = true;
                    Foto = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();                        
                        return stream;
                    });
                }
                Aguarde = false;
            });

            LoadMenu();
        }       

        #endregion

        #region Singleton

        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

        #endregion

        #region Methods 

        internal async Task<Position> ExecuteLocator()
        {
            
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            
            var location = await locator.GetPositionAsync();
            
            var position = new Position(location.Latitude, location.Longitude);
            
            return position;
            
        }

        internal async Task<Celula> GetCelula()
        {
            Aguarde = true;
            var cel = await Api.GetCelulaUsuario();
            Aguarde = false;

            return cel;
        }

        internal void GetGeolocation()
        {
            var position1 = new Position(-21.380965, -42.690077);
            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "Igreja PIB Cataguases",
                Address = "Rua Moreira Lima"
            };
            Pins.Add(pin1);

            var position2 = new Position(-21.383045, -42.690513);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = position2,
                Label = "Casa do Leandro",
                Address = "Rua Joaquim Augusto de Almeida",
                 
            };
            Pins.Add(pin2);

            var position3 = new Position(-21.383358, -42.706201);
            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = position3,
                Label = "Celula bairro Granjaria",
                Address = "Granjaria"
            };
            Pins.Add(pin3);

            var position4 = new Position(-21.374916, -42.690923);
            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = position4,
                Label = "Celula bairro Thome",
                Address = "Thome"
            };
            Pins.Add(pin4);

            var position5 = new Position(-21.366249, -42.674797);
            var pin5 = new Pin
            {
                Type = PinType.Place,
                Position = position5,
                Label = "Celula bairro Pampulha",
                Address = "Pampulha"
            };
            Pins.Add(pin5);

            var position6 = new Position(-21.262636, -42.681063);
            var pin6 = new Pin
            {
                Type = PinType.Place,
                Position = position6,
                Label = "Celula bairro Gloria",
                Address = "Gloria"
            };
            Pins.Add(pin6);

            var position7 = new Position(-21.262636, -42.681063);
            var pin7 = new Pin
            {
                Type = PinType.Place,
                Position = position7,
                Label = "Celula bairro Bom Pastor",
                Address = "Bom Pastor"
            };
            Pins.Add(pin7);

            var position8 = new Position(-21.391686, -42.681219);
            var pin8 = new Pin
            {
                Type = PinType.Place,
                Position = position8,
                Label = "Celula Vila Reis",
                Address = "Vila Reis"
            };
            Pins.Add(pin8);

            var position9 = new Position(-21.405012, -42.700488);
            var pin9 = new Pin
            {
                Type = PinType.Place,
                Position = position9,
                Label = "Celula Paraiso",
                Address = "Paraiso"
            };
            Pins.Add(pin9);
        }

        public void LoadUser(Pessoa user)
        {
            UsuarioLogado.Email = user.Email;
            Foto = user.Foto;
            UsuarioLogado.Codigo = user.Codigo;
        }

        private void LoadMenu()
        {
            Menu.Add(new MenuItemViewModel
            {
                icon = "people.png",
                Title = "Minha Celula",
                PageName = "CelView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_roxo.png",
                Title = "Meus Ministérios",
                PageName = "Ministerio"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_people_verde.png",
                Title = "Minhas Reuniões",
                PageName = "Reuniao"
            });           

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_mais_point.png",
                Title = "Participar de Ministérios",
                PageName = "JoinMinistryView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_mais_verde.png",
                Title = "Participar de Reuniões",
                PageName = "JoinMeetingView"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_posts.png",
                Title = "Postagens da igreja",
                PageName = "MasterDetailPosts"
            });

            Menu.Add(new MenuItemViewModel
            {
                icon = "ic_saida_preto.png",
                Title = "Sair",
                PageName = "LogoutPage"
            });
        }

        #endregion

        private ImageSource foto;
        public ImageSource Foto
        {
            set
            {
                if (foto != value)
                {
                    foto = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return foto;
            }
        }


    }
}
